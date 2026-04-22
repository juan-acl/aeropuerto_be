<#
.SYNOPSIS Fix services with missing model properties by replacing references with DBNull.Value
#>
$beRoot = "C:\Users\joseb\Downloads\AeroLaAurora\AeroLaAurora\aeropuerto_be-develop"

$filesToFix = @(
    "HistorialPreciosCombustibleService.cs",
    "OfertaPersonalizadaService.cs",
    "PedidoCombustibleService.cs",
    "PlanEmergenciaService.cs",
    "QuejasSugerenciasService.cs",
    "RutaTransporteService.cs",
    "SeguridadControlesService.cs",
    "TiposIncidentesService.cs"
)

# Build a lookup of valid properties per model
$modelFiles = Get-ChildItem "$beRoot\Models" -Filter "*.cs"
$validProps = @{}
foreach ($mf in $modelFiles) {
    $content = Get-Content $mf.FullName -Raw
    if ($content -match 'class\s+(\w+)') {
        $className = $matches[1]
        $props = @()
        $propMatches = [regex]::Matches($content, 'public\s+[\w\?\[\]]+\s+(\w+)\s*\{')
        foreach ($pm in $propMatches) {
            $props += $pm.Groups[1].Value
        }
        $validProps[$className] = $props
    }
}

foreach ($fileName in $filesToFix) {
    $filePath = "$beRoot\Services\$fileName"
    if (-not (Test-Path $filePath)) { Write-Host "SKIP: $fileName not found"; continue }
    
    $lines = Get-Content $filePath
    $newLines = @()
    
    foreach ($line in $lines) {
        # Check if line has m.PropertyName pattern
        if ($line -match 'm\.(\w+)') {
            $propName = $matches[1]
            # Try to find what model class this service uses
            $modelClass = ""
            foreach ($l in $lines) {
                if ($l -match 'Task<bool>\s+Insertar\((\w+)\s+m\)') {
                    $modelClass = $matches[1]
                    break
                }
            }
            
            if ($modelClass -and $validProps.ContainsKey($modelClass)) {
                if ($propName -notin $validProps[$modelClass]) {
                    # This property doesn't exist - replace with DBNull.Value
                    $line = $line -replace [regex]::Escape("(object?)m.$propName ?? DBNull.Value"), "DBNull.Value /* $propName no existe en modelo */"
                    $line = $line -replace [regex]::Escape("m.$propName"), "DBNull.Value /* $propName */"
                    Write-Host "  FIX $fileName : m.$propName -> DBNull.Value"
                }
            }
        }
        $newLines += $line
    }
    
    Set-Content -Path $filePath -Value $newLines -Encoding UTF8
    Write-Host "Fixed: $fileName"
}

Write-Host "`nDone fixing property mismatches."
