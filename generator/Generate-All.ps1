###############################################################################
# Generate-All-v2.ps1 – Reliable generator using file-based template approach
###############################################################################
$ErrorActionPreference = 'Stop'
$root   = Split-Path $PSScriptRoot -Parent
$spRoot = Join-Path (Split-Path $root -Parent) 'aeropuerto_be-SP\aeropuerto_be-SP'
$modDir = Join-Path $root 'Models'
$ifDir  = Join-Path $root 'Interfaces'
$svDir  = Join-Path $root 'Services'
$ctDir  = Join-Path $root 'Controllers'

foreach ($d in @($ifDir,$svDir,$ctDir)) {
    if (-not (Test-Path $d)) { New-Item $d -ItemType Directory -Force | Out-Null }
}

# ─── 1. Build model map: TABLE_NAME → { ClassName, KeyPropName, KeyPropType, DbSetName, Props[] } ───
$modelMap = @{}
$dbCtx = Get-Content (Join-Path $root 'Data\DBContext.cs') -Raw

foreach ($f in (Get-ChildItem $modDir -Filter '*.cs')) {
    $c = Get-Content $f.FullName -Raw
    if ($c -notmatch '\[Table\("([^"]+)"\)\]') { continue }
    $tbl = $Matches[1]
    if ($c -notmatch 'public\s+class\s+(\w+)') { continue }
    $clsName = $Matches[1]

    # DbSet name
    $dsName = $null
    if ($dbCtx -match "DbSet<${clsName}>\s+(\w+)\s*\{") { $dsName = $Matches[1] }
    if (-not $dsName) { continue }

    # Properties
    $propsList = @()
    $keyName = $null; $keyType = 'int'
    $lines = $c -split "`n"
    $prevHasKey = $false
    for ($i = 0; $i -lt $lines.Count; $i++) {
        $line = $lines[$i].Trim()
        if ($line -match '^\[Key\]') { $prevHasKey = $true; continue }
        if ($line -match '^\[Column\("([^"]+)"\)\]') {
            $colName = $Matches[1]
            # Look ahead for property
            for ($j = $i+1; $j -lt [Math]::Min($i+5, $lines.Count); $j++) {
                if ($lines[$j] -match 'public\s+([\w\?\[\]]+)\s+(\w+)\s*\{') {
                    $pType = $Matches[1]; $pName = $Matches[2]
                    $propsList += [pscustomobject]@{Column=$colName;Type=$pType;Name=$pName}
                    if ($prevHasKey) { $keyName = $pName; $keyType = $pType -replace '\?',''; $prevHasKey = $false }
                    break
                }
            }
            $prevHasKey = $false
        } else {
            if ($line -notmatch '^\[') { $prevHasKey = $false }
        }
    }

    if (-not $keyName) { continue }

    $modelMap[$tbl] = [pscustomobject]@{
        ClassName = $clsName
        KeyName   = $keyName
        KeyType   = $keyType
        DbSet     = $dsName
        Props     = $propsList
    }
}
Write-Host "Models loaded: $($modelMap.Count)"

# ─── Alias map: SP pkg table key → actual Model table name ───
$aliasMap = @{
    'ENVIOS_CARGA'                  = 'ENVIO_CARGA'
    'INSPECTORES_ADUANAS'           = 'INSPECTOR_ADUANA'
    'MANIFIESTOS_CARGA'             = 'MANIFIESTO_CARGA'
    'MANIFIESTOS_DETALLE'           = 'MANIFIESTO_DETALLE'
    'MENORES_NO_ACOMPANADOS'        = 'MENOR_NO_ACOMPANADO'
    'MOVIMIENTOS_BANCARIOS'         = 'MOVIMIENTO_BANCARIO'
    'ORDENES_COMPRA'                = 'ORDEN_COMPRA'
    'ORDENES_DETALLE'               = 'ORDEN_DETALLE'
    'ORDENES_MP'                    = 'ORDEN_MANTENIMIENTO_PREDICTIVO'
    'PASAJEROS_MASCOTAS'            = 'PASAJERO_MASCOTA'
    'PASAJEROS_MENORES'             = 'PASAJERO_MENOR'
    'PIEZAS_REEMPLAZO'              = 'PIEZA_REEMPLAZO'
    'PRESUPUESTOS'                  = 'PRESUPUESTO'
    'PROGRAMAS_COMPENSACION'        = 'PROGRAMAS_COMPENSACION_AMBIENTAL'
    'PROVEEDORES'                   = 'PROVEEDOR'
    'PROVEEDORES_REPUESTOS'         = 'PROVEEDOR_REPUESTO'
    'PROYECTOS_EFICIENCIA'          = 'PROYECTOS_EFICIENCIA_ENERGETICA'
    'TAREAS_EJECUTADAS'             = 'TAREA_EJECUTADA'
    'TASAS_AEROPORTUARIAS'          = 'TASA_AEROPORTUARIA'
    'TASAS_APLICADAS'               = 'TASA_APLICADA'
    'UNIFORMES_EQUIPAMIENTO'        = 'UNIFORME_EQUIPAMIENTO'
    'USUARIOS_ROLES'                = 'USUARIOS_ROLES'
    'ASISTENCIAS'                   = 'ASISTENCIA'
    'EMPLEADOS_CAPACITACION'        = 'EMPLEADOS_CAPACITACION'
    'PUESTOS_TRABAJO'               = 'PUESTO_TRABAJO'
    'AUTORIZACIONES_MENORES'        = 'AUTORIZACION_MENOR'
    'BODEGAS_CARGA'                 = 'BODEGA_CARGA'
    'CERTIFICACIONES_AMBIENTALES'   = 'CERTIFICACIONES_AMBIENTALES_AEROPUERTO'
    'CHECKLISTS_MANTENIMIENTO'      = 'CHECKLIST_MANTENIMIENTO'
    'ASIGNACION_SERVICIOS'          = 'ASIGNACION_SERVICIOS_TRANSPORTE'
    'CONVENIOS_HOTELES'             = 'CONVENIOS_HOTELES_TRANSPORTE'
    'DOCUMENTOS_REQUERIDOS'         = 'DOCUMENTOS_REQUERIDOS_OPERACION'
    'EVALUACIONES_POST'             = 'EVALUACIONES_POST_EMERGENCIA'
    'INCIDENTES_SEGURIDAD'          = 'INCIDENTES_SEGURIDAD_INFORMATICA'
    'LICENCIAS_OPERATIVAS'          = 'LICENCIAS_OPERATIVAS_AEROPUERTO'
    'PASAJEROS_SEGMENTOS'           = 'PASAJEROS_SEGMENTOS'
    'QUEJAS_TRANSPORTE'             = 'QUEJAS_TRANSPORTE_TERRESTRE'
    'RESERVAS_TRANSPORTE'           = 'RESERVAS_TRANSPORTE_TERRESTRE'
    'ROLES_PERMISOS_MODULOS'        = 'ROLES_PERMISOS_MODULOS'
    'RUTAS_TRANSPORTE'              = 'RUTAS_TRANSPORTE_TERRESTRE'
    'SERIES_VUELO'                  = 'SERIES_VUELO_ASIGNADAS'
    'TARIFAS_TRANSPORTE'            = 'TARIFAS_TRANSPORTE_TERRESTRE'
}

# ─── 2. Collect SQL packages ───
$sqlFiles = Get-ChildItem $spRoot -Recurse -Filter '*.sql' |
    Where-Object { (Get-Content $_.FullName -Raw) -match 'CREATE OR REPLACE PACKAGE\s+pkg_' }
Write-Host "SQL packages found: $($sqlFiles.Count)"

# ─── 3. Parse each package & generate ───
$diLines = @()
$generated = 0

foreach ($sqlFile in $sqlFiles) {
    $raw = Get-Content $sqlFile.FullName -Raw
    if ($raw -notmatch 'CREATE\s+OR\s+REPLACE\s+PACKAGE\s+(pkg_\w+)\s') { continue }
    $pkg = $Matches[1]
    $tblKey = ($pkg -replace '^pkg_','').ToUpper()

    # Find model
    $mdl = $null
    foreach ($k in $modelMap.Keys) {
        if ($k -eq $tblKey) { $mdl = $modelMap[$k]; break }
    }
    if (-not $mdl -and $aliasMap.ContainsKey($tblKey)) {
        $mapped = $aliasMap[$tblKey]
        if ($modelMap.ContainsKey($mapped)) { $mdl = $modelMap[$mapped] }
    }
    if (-not $mdl) {
        # Try common variations
        foreach ($k in $modelMap.Keys) {
            $k2 = $k -replace '_',''
            $t2 = $tblKey -replace '_',''
            if ($k2 -eq $t2) { $mdl = $modelMap[$k]; break }
        }
    }
    if (-not $mdl) {
        Write-Host "  SKIP $pkg (no model for $tblKey)" -ForegroundColor Yellow
        continue
    }

    $clsN    = $mdl.ClassName
    $keyN    = $mdl.KeyName
    $keyT    = $mdl.KeyType
    $dsN     = $mdl.DbSet
    $allP    = $mdl.Props
    $keyCST  = if ($keyT -eq 'string') { 'string' } else { 'int' }

    # Derive names
    $base = $clsN -replace 'Model$',''
    $svc  = "${base}Service"
    $ifc  = "I${svc}"
    $ctrl = "${base}Controller"

    # Parse insert proc params from PACKAGE SPEC (first occurrence)
    $insertProc = $null; $insertPms = @()
    if ($raw -match 'PROCEDURE\s+(insert_\w+)\s*\(') { $insertProc = $Matches[1] }
    if ($insertProc -and $raw -match "(?s)PROCEDURE\s+${insertProc}\s*\((.*?)\)\s*;") {
        $block = $Matches[1]
        foreach ($m in ([regex]'(p_\w+)\s+IN\s+(\w+)').Matches($block)) {
            $insertPms += $m.Groups[1].Value
        }
    }

    # Parse update proc params
    $updateProc = $null; $updatePms = @()
    if ($raw -match 'PROCEDURE\s+(update_\w+)\s*\(') { $updateProc = $Matches[1] }
    if ($updateProc -and $raw -match "(?s)PROCEDURE\s+${updateProc}\s*\((.*?)\)\s*;") {
        $block = $Matches[1]
        foreach ($m in ([regex]'(p_\w+)\s+IN\s+(\w+)').Matches($block)) {
            $updatePms += $m.Groups[1].Value
        }
    }

    # Parse delete proc
    $deleteProc = $null
    if ($raw -match 'PROCEDURE\s+(delete_\w+)\s*\(') { $deleteProc = $Matches[1] }

    if (-not $insertProc -or -not $updateProc -or -not $deleteProc) {
        Write-Host "  SKIP $pkg (missing CRUD procs)" -ForegroundColor Yellow
        continue
    }

    # ─── Helper: param name → model property ───
    function MapParam($pn) {
        $col = ($pn -replace '^p_','').ToUpper()
        foreach ($pr in $allP) {
            if ($pr.Column -eq $col) { return $pr }
        }
        # fuzzy
        foreach ($pr in $allP) {
            if (($pr.Column -replace '_','') -eq ($col -replace '_','')) { return $pr }
        }
        return $null
    }

    # Build insert param arrays
    $iNames = @(); $iOra = @()
    foreach ($pn in $insertPms) {
        $iNames += ":$pn"
        $mp = MapParam $pn
        if ($mp) {
            $nullable = $mp.Type.EndsWith('?') -or $mp.Type -eq 'string' -or $mp.Type -eq 'byte[]'
            if ($nullable) {
                $iOra += "                    new OracleParameter(`"$pn`", (object?)m.$($mp.Name) ?? DBNull.Value)"
            } else {
                $iOra += "                    new OracleParameter(`"$pn`", m.$($mp.Name))"
            }
        } else {
            $iOra += "                    new OracleParameter(`"$pn`", DBNull.Value)"
        }
    }

    # Build update param arrays
    $uNames = @(); $uOra = @()
    $isFirst = $true
    foreach ($pn in $updatePms) {
        $uNames += ":$pn"
        $mp = MapParam $pn
        if ($isFirst) {
            $uOra += "                    new OracleParameter(`"$pn`", id)"
            $isFirst = $false
        } elseif ($mp) {
            $nullable = $mp.Type.EndsWith('?') -or $mp.Type -eq 'string' -or $mp.Type -eq 'byte[]'
            if ($nullable) {
                $uOra += "                    new OracleParameter(`"$pn`", (object?)m.$($mp.Name) ?? DBNull.Value)"
            } else {
                $uOra += "                    new OracleParameter(`"$pn`", m.$($mp.Name))"
            }
        } else {
            $uOra += "                    new OracleParameter(`"$pn`", DBNull.Value)"
        }
    }

    $iSqlStr = $iNames -join ', '
    $uSqlStr = $uNames -join ', '
    $iOraStr = $iOra -join ",`r`n"
    $uOraStr = $uOra -join ",`r`n"

    # ══════════ Write Interface ══════════
    $ifContent = @"
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface $ifc
    {
        Task<List<$clsN>> ListarTodo();
        Task<$clsN ?> ObtenerPorId($keyCST id);
        Task<bool> Insertar($clsN m);
        Task<bool> Actualizar($keyCST id, $clsN m);
        Task<bool> Eliminar($keyCST id);
    }
}
"@
    [System.IO.File]::WriteAllText((Join-Path $ifDir "$ifc.cs"), $ifContent, [System.Text.Encoding]::UTF8)

    # ══════════ Write Service ══════════
    # Build service file content using .NET string builder to avoid PS interpolation issues
    $sb = [System.Text.StringBuilder]::new()
    [void]$sb.AppendLine('using Aeropuerto.Backend.Interfaces;')
    [void]$sb.AppendLine('using Aeropuerto.Backend.Models;')
    [void]$sb.AppendLine('using Aeropuerto.Backend.Data;')
    [void]$sb.AppendLine('using Microsoft.EntityFrameworkCore;')
    [void]$sb.AppendLine('using Oracle.ManagedDataAccess.Client;')
    [void]$sb.AppendLine('using System.Data;')
    [void]$sb.AppendLine('')
    [void]$sb.AppendLine('namespace Aeropuerto.Backend.Services')
    [void]$sb.AppendLine('{')
    [void]$sb.AppendLine("    public class $svc : $ifc")
    [void]$sb.AppendLine('    {')
    [void]$sb.AppendLine('        private readonly DBContext _primary;')
    [void]$sb.AppendLine('        private readonly ReplicaDBContext _replica;')
    [void]$sb.AppendLine("        public $svc(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }")
    [void]$sb.AppendLine('')
    [void]$sb.AppendLine("        public async Task<List<$clsN>> ListarTodo()")
    [void]$sb.AppendLine('        {')
    [void]$sb.AppendLine("            try { return await _replica.$dsN.ToListAsync(); }")
    [void]$sb.AppendLine('            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ' + $clsN + ': {ex.Message}"); return new List<' + $clsN + '>(); }')
    [void]$sb.AppendLine('        }')
    [void]$sb.AppendLine('')
    [void]$sb.AppendLine("        public async Task<$clsN ?> ObtenerPorId($keyCST id)")
    [void]$sb.AppendLine('        {')
    [void]$sb.AppendLine("            try { return await _replica.$dsN.FindAsync(id); }")
    [void]$sb.AppendLine('            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ' + $clsN + ': {ex.Message}"); return null; }')
    [void]$sb.AppendLine('        }')
    [void]$sb.AppendLine('')
    [void]$sb.AppendLine("        public async Task<bool> Insertar($clsN m)")
    [void]$sb.AppendLine('        {')
    [void]$sb.AppendLine('            try')
    [void]$sb.AppendLine('            {')
    [void]$sb.AppendLine("                string sql = ""BEGIN $pkg.$insertProc($iSqlStr); END;"";")
    [void]$sb.AppendLine('                var p = new OracleParameter[] {')
    [void]$sb.AppendLine($iOraStr)
    [void]$sb.AppendLine('                };')
    [void]$sb.AppendLine('                await _primary.Database.ExecuteSqlRawAsync(sql, p);')
    [void]$sb.AppendLine('                return true;')
    [void]$sb.AppendLine('            }')
    [void]$sb.AppendLine('            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ' + $clsN + ': {ex.Message}"); throw; }')
    [void]$sb.AppendLine('        }')
    [void]$sb.AppendLine('')
    [void]$sb.AppendLine("        public async Task<bool> Actualizar($keyCST id, $clsN m)")
    [void]$sb.AppendLine('        {')
    [void]$sb.AppendLine('            try')
    [void]$sb.AppendLine('            {')
    [void]$sb.AppendLine("                string sql = ""BEGIN $pkg.$updateProc($uSqlStr); END;"";")
    [void]$sb.AppendLine('                var p = new OracleParameter[] {')
    [void]$sb.AppendLine($uOraStr)
    [void]$sb.AppendLine('                };')
    [void]$sb.AppendLine('                await _primary.Database.ExecuteSqlRawAsync(sql, p);')
    [void]$sb.AppendLine('                return true;')
    [void]$sb.AppendLine('            }')
    [void]$sb.AppendLine('            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ' + $clsN + ': {ex.Message}"); throw; }')
    [void]$sb.AppendLine('        }')
    [void]$sb.AppendLine('')
    [void]$sb.AppendLine("        public async Task<bool> Eliminar($keyCST id)")
    [void]$sb.AppendLine('        {')
    [void]$sb.AppendLine('            try')
    [void]$sb.AppendLine('            {')
    [void]$sb.AppendLine("                string sql = ""BEGIN $pkg.${deleteProc}(:p_id); END;"";")
    [void]$sb.AppendLine("                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter(""p_id"", id));")
    [void]$sb.AppendLine('                return true;')
    [void]$sb.AppendLine('            }')
    [void]$sb.AppendLine('            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ' + $clsN + ': {ex.Message}"); throw; }')
    [void]$sb.AppendLine('        }')
    [void]$sb.AppendLine('    }')
    [void]$sb.AppendLine('}')

    [System.IO.File]::WriteAllText((Join-Path $svDir "$svc.cs"), $sb.ToString(), [System.Text.Encoding]::UTF8)

    # ══════════ Write Controller ══════════
    $cb = [System.Text.StringBuilder]::new()
    [void]$cb.AppendLine('using Microsoft.AspNetCore.Mvc;')
    [void]$cb.AppendLine('using Aeropuerto.Backend.Interfaces;')
    [void]$cb.AppendLine('using Aeropuerto.Backend.Models;')
    [void]$cb.AppendLine('')
    [void]$cb.AppendLine('namespace Aeropuerto.Backend.Controllers')
    [void]$cb.AppendLine('{')
    [void]$cb.AppendLine('    [ApiController]')
    [void]$cb.AppendLine('    [Route("api/[controller]")]')
    [void]$cb.AppendLine("    public class $ctrl : ControllerBase")
    [void]$cb.AppendLine('    {')
    [void]$cb.AppendLine("        private readonly $ifc _svc;")
    [void]$cb.AppendLine("        public $ctrl($ifc svc) { _svc = svc; }")
    [void]$cb.AppendLine('')
    [void]$cb.AppendLine('        [HttpGet]')
    [void]$cb.AppendLine('        public async Task<IActionResult> GetAll() => Ok(await _svc.ListarTodo());')
    [void]$cb.AppendLine('')
    [void]$cb.AppendLine('        [HttpGet("{id}")]')
    [void]$cb.AppendLine("        public async Task<IActionResult> GetById($keyCST id)")
    [void]$cb.AppendLine('        {')
    [void]$cb.AppendLine('            var item = await _svc.ObtenerPorId(id);')
    [void]$cb.AppendLine('            return item == null ? NotFound() : Ok(item);')
    [void]$cb.AppendLine('        }')
    [void]$cb.AppendLine('')
    [void]$cb.AppendLine('        [HttpPost]')
    [void]$cb.AppendLine("        public async Task<IActionResult> Create([FromBody] $clsN m)")
    [void]$cb.AppendLine('        {')
    [void]$cb.AppendLine('            await _svc.Insertar(m);')
    [void]$cb.AppendLine('            return Ok(new { mensaje = "Registro creado correctamente." });')
    [void]$cb.AppendLine('        }')
    [void]$cb.AppendLine('')
    [void]$cb.AppendLine('        [HttpPut("{id}")]')
    [void]$cb.AppendLine("        public async Task<IActionResult> Update($keyCST id, [FromBody] $clsN m)")
    [void]$cb.AppendLine('        {')
    [void]$cb.AppendLine('            await _svc.Actualizar(id, m);')
    [void]$cb.AppendLine('            return Ok(new { mensaje = "Registro actualizado correctamente." });')
    [void]$cb.AppendLine('        }')
    [void]$cb.AppendLine('')
    [void]$cb.AppendLine('        [HttpDelete("{id}")]')
    [void]$cb.AppendLine("        public async Task<IActionResult> Delete($keyCST id)")
    [void]$cb.AppendLine('        {')
    [void]$cb.AppendLine('            await _svc.Eliminar(id);')
    [void]$cb.AppendLine('            return Ok(new { mensaje = "Registro eliminado correctamente." });')
    [void]$cb.AppendLine('        }')
    [void]$cb.AppendLine('    }')
    [void]$cb.AppendLine('}')

    [System.IO.File]::WriteAllText((Join-Path $ctDir "$ctrl.cs"), $cb.ToString(), [System.Text.Encoding]::UTF8)

    $diLines += "builder.Services.AddScoped<$ifc, $svc>();"
    $generated++
    Write-Host "  OK  $pkg -> $svc" -ForegroundColor Green
}

# Save DI lines
$diLines | Sort-Object -Unique | Set-Content (Join-Path $root 'generator\di_lines.txt') -Encoding UTF8

Write-Host ""
Write-Host "=== Generated: $generated service triplets (Interface + Service + Controller) ===" -ForegroundColor Cyan
Write-Host "=== Skipped packages listed above in yellow ===" -ForegroundColor Yellow
Write-Host "=== DI lines saved to generator\di_lines.txt ===" -ForegroundColor Cyan
