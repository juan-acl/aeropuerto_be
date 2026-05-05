<#
.SYNOPSIS
  Generates C# Service/Interface/Controller files from Oracle SP SQL packages.
.DESCRIPTION
  1. Parses all Model files to build a column-to-property mapping
  2. Parses DBContext to build table-to-DbSet mapping
  3. Parses all SP SQL files to extract package names, procedures, and parameters
  4. Matches SPs to existing models/services
  5. Generates updated C# files with SP calls for Insert/Update/Delete
#>

$ErrorActionPreference = "Continue"

$spRoot  = "c:\Users\joseb\Downloads\aero\aeropuerto_be-SP\aeropuerto_be-SP"
$beRoot  = "c:\Users\joseb\Downloads\aero\aeropuerto_be"
$logFile = "$beRoot\generator\generation_log.txt"

"" | Out-File $logFile
function Log($msg) { $msg | Tee-Object -FilePath $logFile -Append }

# ═══════════════════════════════════════════════════════════════════════════════
# STEP 1: Parse all Model files → build column→property mapping per table
# ═══════════════════════════════════════════════════════════════════════════════
Log "=== STEP 1: Parsing Model files ==="

$modelFiles = Get-ChildItem "$beRoot\Models" -Filter "*.cs"
$models = @{}  # key = TABLE_NAME (uppercase), value = { ClassName, Properties:[{ColName,PropName,PropType,IsNullable}] }

foreach ($mf in $modelFiles) {
    $content = Get-Content $mf.FullName -Raw
    
    # Extract [Table("TABLE_NAME")] and class name
    if ($content -match '\[Table\("(\w+)"\)\]\s*(?:\r?\n\s*)?(?:public\s+)?class\s+(\w+)') {
        $tableName = $matches[1].ToUpper()
        $className = $matches[2]
        
        # Extract properties with [Column("COL")] attributes
        $props = @()
        $colMatches = [regex]::Matches($content, '\[Column\("(\w+)"\)\]\s*(?:\r?\n\s*)?(?:\[.*?\]\s*(?:\r?\n\s*)?)*public\s+([\w\?\[\]]+)\s+(\w+)\s*\{')
        foreach ($cm in $colMatches) {
            $colName = $cm.Groups[1].Value.ToUpper()
            $propType = $cm.Groups[2].Value
            $propName = $cm.Groups[3].Value
            $isNullable = $propType.Contains("?")
            $props += @{ ColName=$colName; PropName=$propName; PropType=$propType; IsNullable=$isNullable }
        }
        
        $models[$tableName] = @{ ClassName=$className; Properties=$props; FilePath=$mf.FullName }
        Log "  Model: $className -> Table: $tableName ($($props.Count) props)"
    }
}

Log "  Total models found: $($models.Count)"

# ═══════════════════════════════════════════════════════════════════════════════
# STEP 2: Parse DBContext → build table→DbSet property name mapping
# ═══════════════════════════════════════════════════════════════════════════════
Log "`n=== STEP 2: Parsing DBContext ==="

$ctxContent = Get-Content "$beRoot\Data\DBContext.cs" -Raw
$dbSets = @{}  # key = ClassName, value = DbSetPropertyName

$dsMatches = [regex]::Matches($ctxContent, 'DbSet<(\w+)>\s+(\w+)\s*\{')
foreach ($dm in $dsMatches) {
    $modelClass = $dm.Groups[1].Value
    $dbSetProp = $dm.Groups[2].Value
    $dbSets[$modelClass] = $dbSetProp
    # Also map without "Model" suffix for lookup
}
Log "  Total DbSets: $($dbSets.Count)"

# ═══════════════════════════════════════════════════════════════════════════════
# STEP 3: Scan existing services to find which service uses which model
# ═══════════════════════════════════════════════════════════════════════════════
Log "`n=== STEP 3: Scanning existing services ==="

$serviceFiles = Get-ChildItem "$beRoot\Services" -Filter "*.cs" | Where-Object { $_.Name -ne "Seguridad" }
$serviceMap = @{}  # key = TABLE_NAME, value = { ServiceFile, ServiceClass, InterfaceName }

foreach ($sf in $serviceFiles) {
    $sContent = Get-Content $sf.FullName -Raw
    $serviceClassName = ""
    if ($sContent -match 'class\s+(\w+Service)\s*:') {
        $serviceClassName = $matches[1]
    }
    
    # Check which model this service references
    foreach ($tbl in $models.Keys) {
        $mc = $models[$tbl].ClassName
        if ($sContent -match [regex]::Escape($mc) -and -not $serviceMap.ContainsKey($tbl)) {
            # Find the interface
            $interfaceName = "I$serviceClassName"
            $serviceMap[$tbl] = @{
                ServiceFile = $sf.FullName
                ServiceClass = $serviceClassName
                InterfaceName = $interfaceName
                ServiceFileName = $sf.Name
            }
        }
    }
}
Log "  Mapped $($serviceMap.Count) services to tables"

# ═══════════════════════════════════════════════════════════════════════════════
# STEP 4: Parse SP SQL files
# ═══════════════════════════════════════════════════════════════════════════════
Log "`n=== STEP 4: Parsing SP SQL files ==="

$sqlFiles = Get-ChildItem -Path $spRoot -Filter "*.sql" -Recurse
$spInfos = @()

foreach ($sqlFile in $sqlFiles) {
    $sql = Get-Content $sqlFile.FullName -Raw
    
    # Extract package name
    $pkgMatch = [regex]::Match($sql, 'CREATE\s+OR\s+REPLACE\s+PACKAGE\s+(pkg_\w+)\s+AS', [System.Text.RegularExpressions.RegexOptions]::IgnoreCase)
    if (-not $pkgMatch.Success) { 
        Log "  SKIP (no package): $($sqlFile.Name)"
        continue 
    }
    $pkgName = $pkgMatch.Groups[1].Value.ToLower()
    
    # Extract table name from INSERT INTO in the body
    $insertIntoMatch = [regex]::Match($sql, 'INSERT\s+INTO\s+(\w+)\s*\(', [System.Text.RegularExpressions.RegexOptions]::IgnoreCase)
    $tableName = if ($insertIntoMatch.Success) { $insertIntoMatch.Groups[1].Value.ToUpper() } else { "" }
    
    # Extract procedure signatures from the PACKAGE SPEC (before the first /)
    $specMatch = [regex]::Match($sql, 'CREATE\s+OR\s+REPLACE\s+PACKAGE\s+\w+\s+AS(.*?)END\s+\w+;', [System.Text.RegularExpressions.RegexOptions]::IgnoreCase -bor [System.Text.RegularExpressions.RegexOptions]::Singleline)
    $specContent = if ($specMatch.Success) { $specMatch.Groups[1].Value } else { "" }
    
    if (-not $specContent) { Log "  WARN: Spec content not found for $($sqlFile.Name)" }

    # Parse insert procedure from spec
    $insertProcMatch = [regex]::Match($specContent, 'PROCEDURE\s+(insert_\w+)\s*\((.*?)\)\s*;', [System.Text.RegularExpressions.RegexOptions]::IgnoreCase -bor [System.Text.RegularExpressions.RegexOptions]::Singleline)
    $insertProc = if ($insertProcMatch.Success) { $insertProcMatch.Groups[1].Value } else { "" }
    $insertParamsRaw = if ($insertProcMatch.Success) { $insertProcMatch.Groups[2].Value } else { "" }
    
    # Parse update procedure from spec
    $updateProcMatch = [regex]::Match($specContent, 'PROCEDURE\s+(update_\w+)\s*\((.*?)\)\s*;', [System.Text.RegularExpressions.RegexOptions]::IgnoreCase -bor [System.Text.RegularExpressions.RegexOptions]::Singleline)
    $updateProc = if ($updateProcMatch.Success) { $updateProcMatch.Groups[1].Value } else { "" }
    $updateParamsRaw = if ($updateProcMatch.Success) { $updateProcMatch.Groups[2].Value } else { "" }
    
    # Parse delete procedure from spec
    $deleteProcMatch = [regex]::Match($specContent, 'PROCEDURE\s+(delete_\w+)\s*\((.*?)\)\s*;', [System.Text.RegularExpressions.RegexOptions]::IgnoreCase -bor [System.Text.RegularExpressions.RegexOptions]::Singleline)
    $deleteProc = if ($deleteProcMatch.Success) { $deleteProcMatch.Groups[1].Value } else { "" }
    $deleteParamsRaw = if ($deleteProcMatch.Success) { $deleteProcMatch.Groups[2].Value } else { "" }

    if (-not $deleteProc) { Log "  WARN: Delete procedure not found in spec for $($sqlFile.Name)" }

    
    # Parse parameter names from raw parameter string
    function Parse-Params($raw) {
        $params = @()
        if ([string]::IsNullOrWhiteSpace($raw)) { return $params }
        # Split by comma, handling multiline
        $parts = $raw -split ','
        foreach ($part in $parts) {
            $part = $part.Trim()
            # Match: p_name [IN|OUT|IN OUT] type
            if ($part -match '(p_\w+)\s+(?:IN|OUT|IN\s+OUT)?\s*(.+?)(?:\s+DEFAULT\s+.*)?$') {
                $pName = $matches[1].ToLower()
                $pTypeRaw = $matches[2].Trim()
                
                # Determine if BLOB
                $isBlob = $pTypeRaw -match 'BLOB'
                $isTimestamp = $pTypeRaw -match 'TIMESTAMP'
                $isDate = $pTypeRaw -match '\bDATE\b'
                $isNumber = $pTypeRaw -match 'NUMBER'
                
                # Convert p_xxx to COLUMN_NAME: remove p_ prefix, uppercase
                $colName = ($pName -replace '^p_', '').ToUpper()
                
                $params += @{ ParamName=$pName; ColName=$colName; IsBlob=$isBlob; IsTimestamp=$isTimestamp; IsDate=$isDate; IsNumber=$isNumber }
            }
        }
        return $params
    }
    
    $insertParams = Parse-Params $insertParamsRaw
    $updateParams = Parse-Params $updateParamsRaw
    $deleteParams = Parse-Params $deleteParamsRaw
    
    $spInfos += @{
        File = $sqlFile.Name
        FilePath = $sqlFile.FullName
        Package = $pkgName
        TableName = $tableName
        InsertProc = $insertProc
        InsertParams = $insertParams
        UpdateProc = $updateProc
        UpdateParams = $updateParams
        DeleteProc = $deleteProc
        DeleteParams = $deleteParams
    }
    
    Log "  SP: $pkgName -> Table: $tableName | insert=$insertProc($(($insertParams | ForEach-Object {$_.ParamName}) -join ',')) | update=$updateProc | delete=$deleteProc($(($deleteParams | ForEach-Object {$_.ParamName}) -join ','))"
}

Log "`n  Total SPs parsed: $($spInfos.Count)"

# ═══════════════════════════════════════════════════════════════════════════════
# STEP 5: Generate C# files
# ═══════════════════════════════════════════════════════════════════════════════
Log "`n=== STEP 5: Generating C# files ==="

$generated = 0
$skipped = 0

function To-PascalCase($snakeCase) {
    # convert COLUMN_NAME or column_name to PascalCase
    $parts = $snakeCase.ToLower() -split '_'
    $result = ""
    foreach ($p in $parts) {
        if ($p.Length -gt 0) {
            $result += $p.Substring(0,1).ToUpper() + $p.Substring(1)
        }
    }
    return $result
}

function Find-PropName($modelInfo, $colName) {
    # Find the C# property name for a given column name
    foreach ($prop in $modelInfo.Properties) {
        if ($prop.ColName -eq $colName) {
            return $prop.PropName
        }
    }
    # Fallback: convert to PascalCase
    return (To-PascalCase $colName)
}

function Find-PropType($modelInfo, $colName) {
    foreach ($prop in $modelInfo.Properties) {
        if ($prop.ColName -eq $colName) {
            return $prop.PropType
        }
    }
    return "object"
}

function Find-PkProp($modelInfo) {
    # Find the property marked with [Key]
    $content = Get-Content $modelInfo.FilePath -Raw
    if ($content -match '\[Key\]\s*(?:\r?\n\s*)?(?:\[.*?\]\s*(?:\r?\n\s*)?)*\[Column\("(\w+)"\)\]') {
        $pkCol = $matches[1].ToUpper()
        foreach ($prop in $modelInfo.Properties) {
            if ($prop.ColName -eq $pkCol) {
                return @{ PropName=$prop.PropName; ColName=$pkCol; PropType=$prop.PropType }
            }
        }
    }
    # Fallback: first property
    if ($modelInfo.Properties.Count -gt 0) {
        $first = $modelInfo.Properties[0]
        return @{ PropName=$first.PropName; ColName=$first.ColName; PropType=$first.PropType }
    }
    return @{ PropName="Id"; ColName="ID"; PropType="int" }
}

function Build-OracleParam($paramName, $propName, $spParam, $propType) {
    if ($spParam.IsBlob) {
        return "                new OracleParameter(`"$paramName`", OracleDbType.Blob) { Value = (object?)m.$propName ?? DBNull.Value }"
    }
    # For nullable types, wrap with null coalescing
    if ($propType -and ($propType.Contains("?") -or $propType -eq "string")) {
        return "                new OracleParameter(`"$paramName`", (object?)m.$propName ?? DBNull.Value)"
    }
    return "                new OracleParameter(`"$paramName`", m.$propName)"
}

foreach ($sp in $spInfos) {
    $tableName = $sp.TableName
    
    if (-not $tableName -or -not $models.ContainsKey($tableName)) {
        Log "  SKIP (no model for table '$tableName'): $($sp.File)"
        $skipped++
        continue
    }
    
    $modelInfo = $models[$tableName]
    $modelClass = $modelInfo.ClassName
    
    if (-not $serviceMap.ContainsKey($tableName)) {
        Log "  SKIP (no service for table '$tableName'): $($sp.File)"
        $skipped++
        continue
    }
    
    $svcInfo = $serviceMap[$tableName]
    $serviceClass = $svcInfo.ServiceClass
    $interfaceName = $svcInfo.InterfaceName
    
    # Get DbSet property name
    $dbSetProp = if ($dbSets.ContainsKey($modelClass)) { $dbSets[$modelClass] } else { $tableName }
    
    # Get PK info
    $pkInfo = Find-PkProp $modelInfo
    $pkPropName = $pkInfo.PropName
    $pkType = if ($pkInfo.PropType -match 'int|decimal') { "int" } else { $pkInfo.PropType -replace '\?','' }
    if ($pkType -eq "string") { $pkType = "string" }
    elseif ($pkType -notmatch 'int|string') { $pkType = "int" }
    
    # ─── Build INSERT parameter list ────────────────────────────────────────
    $insertParamBindings = @()
    $insertParamNames = @()
    foreach ($ip in $sp.InsertParams) {
        $propName = Find-PropName $modelInfo $ip.ColName
        $propType = Find-PropType $modelInfo $ip.ColName
        $insertParamBindings += (Build-OracleParam $ip.ParamName $propName $ip $propType)
        $insertParamNames += ":$($ip.ParamName)"
    }
    $insertSql = "BEGIN $($sp.Package).$($sp.InsertProc)($($insertParamNames -join ', ')); END;"
    
    # ─── Build UPDATE parameter list ────────────────────────────────────────
    $updateParamBindings = @()
    $updateParamNames = @()
    $firstUpdateParam = $true
    foreach ($up in $sp.UpdateParams) {
        $propName = Find-PropName $modelInfo $up.ColName
        $propType = Find-PropType $modelInfo $up.ColName
        if ($firstUpdateParam) {
            # First param of update is the PK - use the 'id' method parameter
            $updateParamBindings += "                new OracleParameter(`"$($up.ParamName)`", id)"
            $firstUpdateParam = $false
        } else {
            $updateParamBindings += (Build-OracleParam $up.ParamName $propName $up $propType)
        }
        $updateParamNames += ":$($up.ParamName)"
    }
    $updateSql = "BEGIN $($sp.Package).$($sp.UpdateProc)($($updateParamNames -join ', ')); END;"
    
    # ─── Build DELETE ───────────────────────────────────────────────────────
    if ($sp.Package -eq "pkg_usuarios_sistema") { 
        Log "  DEBUG: pkg_usuarios_sistema DeleteParams count=$($sp.DeleteParams.Count)"
        foreach ($dp in $sp.DeleteParams) { Log "  DEBUG: ParamName='$($dp.ParamName)'" }
    }
    $deletePkParam = if ($sp.DeleteParams.Count -gt 0) { $sp.DeleteParams[0].ParamName } else { "p_id" }
    $deleteSql = "BEGIN $($sp.Package).$($sp.DeleteProc)(:$deletePkParam); END;"

    
    # ─── Derive controller name ─────────────────────────────────────────────
    $controllerClass = $serviceClass -replace 'Service$', 'Controller'
    $controllerFileName = "$controllerClass.cs"
    # Find actual controller file
    $controllerFile = Get-ChildItem "$beRoot\Controllers" -Filter "*.cs" | Where-Object {
        $c = Get-Content $_.FullName -Raw
        $c -match [regex]::Escape($interfaceName)
    } | Select-Object -First 1
    $controllerFilePath = if ($controllerFile) { $controllerFile.FullName } else { "$beRoot\Controllers\$controllerFileName" }
    $actualControllerClass = ""
    if ($controllerFile) {
        $cc = Get-Content $controllerFile.FullName -Raw
        if ($cc -match 'class\s+(\w+Controller)\s*:') { $actualControllerClass = $matches[1] }
    }
    if (-not $actualControllerClass) { $actualControllerClass = $controllerClass }
    
    # ═══════════════════════════════════════════════════════════════════════════
    # GENERATE INTERFACE
    # ═══════════════════════════════════════════════════════════════════════════
    $interfaceCode = @"
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface $interfaceName
    {
        Task<List<$modelClass>> ListarTodo();
        Task<${modelClass}?> ObtenerPorId($pkType id);
        Task<bool> Insertar($modelClass modelo);
        Task<bool> Actualizar($pkType id, $modelClass modelo);
        Task<bool> Eliminar($pkType id);
    }
}
"@
    
    # Find interface file
    $ifaceFile = Get-ChildItem "$beRoot\Interfaces" -Filter "*.cs" | Where-Object {
        $c = Get-Content $_.FullName -Raw
        $c -match "interface\s+$([regex]::Escape($interfaceName))\b"
    } | Select-Object -First 1
    $ifaceFilePath = if ($ifaceFile) { $ifaceFile.FullName } else { "$beRoot\Interfaces\$interfaceName.cs" }
    
    Set-Content -Path $ifaceFilePath -Value $interfaceCode -Encoding UTF8
    
    # ═══════════════════════════════════════════════════════════════════════════
    # GENERATE SERVICE
    # ═══════════════════════════════════════════════════════════════════════════
    $insertParamBlock = $insertParamBindings -join ",`n"
    $updateParamBlock = $updateParamBindings -join ",`n"
    
    $serviceCode = @"
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class $serviceClass : $interfaceName
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ${serviceClass}(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<$modelClass>> ListarTodo()
        {
            try { return await _replica.$dbSetProp.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine(`$"ERROR ListarTodo ${modelClass}: {ex.Message}"); return new List<${modelClass}>(); }
        }

        public async Task<${modelClass}?> ObtenerPorId($pkType id)
        {
            try { return await _replica.$dbSetProp.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine(`$"ERROR ObtenerPorId ${modelClass}: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar($modelClass m)
        {
            try
            {
                string sql = "$insertSql";
                var p = new OracleParameter[] {
$insertParamBlock
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine(`$"ERROR Insertar ${modelClass}: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar($pkType id, $modelClass m)
        {
            try
            {
                string sql = "$updateSql";
                var p = new OracleParameter[] {
$updateParamBlock
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine(`$"ERROR Actualizar ${modelClass}: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar($pkType id)
        {
            try
            {
                string sql = "$deleteSql";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("$deletePkParam", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine(`$"ERROR Eliminar ${modelClass}: {ex.Message}"); return false; }
        }
    }
}
"@
    
    Set-Content -Path $svcInfo.ServiceFile -Value $serviceCode -Encoding UTF8

    
    # ═══════════════════════════════════════════════════════════════════════════
    # GENERATE CONTROLLER
    # ═══════════════════════════════════════════════════════════════════════════
    $ctrlLines = @()
    $ctrlLines += 'using Microsoft.AspNetCore.Mvc;'
    $ctrlLines += 'using Aeropuerto.Backend.Interfaces;'
    $ctrlLines += 'using Aeropuerto.Backend.Models;'
    $ctrlLines += ''
    $ctrlLines += 'namespace Aeropuerto.Backend.Controllers'
    $ctrlLines += '{'
    $ctrlLines += '    [Route("api/[controller]")]'
    $ctrlLines += '    [ApiController]'
    $ctrlLines += "    public class $actualControllerClass : ControllerBase"
    $ctrlLines += '    {'
    $ctrlLines += "        private readonly $interfaceName _service;"
    $ctrlLines += "        public ${actualControllerClass}($interfaceName service) => _service = service;"
    $ctrlLines += ''
    $ctrlLines += '        [HttpGet]'
    $ctrlLines += '        public async Task<IActionResult> Get() => Ok(await _service.ListarTodo());'
    $ctrlLines += ''
    $ctrlLines += '        [HttpGet("{id}")]'
    $ctrlLines += "        public async Task<IActionResult> GetById($pkType id)"
    $ctrlLines += '        {'
    $ctrlLines += '            var item = await _service.ObtenerPorId(id);'
    $ctrlLines += '            return item != null ? Ok(item) : NotFound(new { mensaje = "No encontrado" });'
    $ctrlLines += '        }'
    $ctrlLines += ''
    $ctrlLines += '        [HttpPost]'
    $ctrlLines += "        public async Task<IActionResult> Post([FromBody] $modelClass m)"
    $ctrlLines += '            => await _service.Insertar(m) ? Ok(new { mensaje = "Creado" }) : BadRequest(new { mensaje = "Error al crear" });'
    $ctrlLines += ''
    $ctrlLines += '        [HttpPut("{id}")]'
    $ctrlLines += "        public async Task<IActionResult> Put($pkType id, [FromBody] $modelClass m)"
    $ctrlLines += '            => await _service.Actualizar(id, m) ? Ok(new { mensaje = "Actualizado" }) : BadRequest(new { mensaje = "Error al actualizar" });'
    $ctrlLines += ''
    $ctrlLines += '        [HttpDelete("{id}")]'
    $ctrlLines += "        public async Task<IActionResult> Delete($pkType id)"
    $ctrlLines += '            => await _service.Eliminar(id) ? Ok(new { mensaje = "Eliminado" }) : BadRequest(new { mensaje = "Error al eliminar" });'
    $ctrlLines += '    }'
    $ctrlLines += '}'
    
    $controllerCode = $ctrlLines -join "`r`n"
    
    Set-Content -Path $controllerFilePath -Value $controllerCode -Encoding UTF8
    
    $generated++
    Log "  GENERATED [$generated]: $serviceClass | $interfaceName | $actualControllerClass (pkg=$($sp.Package), table=$tableName)"
}

# ═══════════════════════════════════════════════════════════════════════════════
# SUMMARY
# ═══════════════════════════════════════════════════════════════════════════════
Log "`n════════════════════════════════════════════════════"
Log "GENERATION COMPLETE"
Log "  Generated: $generated service+interface+controller sets"
Log "  Skipped:   $skipped (no matching model/service)"
Log "  Total SPs: $($spInfos.Count)"
Log "════════════════════════════════════════════════════"

Write-Host "`n✅ Generation complete! $generated sets generated, $skipped skipped." -ForegroundColor Green
Write-Host "Log: $logFile" -ForegroundColor Cyan
