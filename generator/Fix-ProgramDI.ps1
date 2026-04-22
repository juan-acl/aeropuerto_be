<#
.SYNOPSIS
  Fix Program.cs DI registrations where the Interface name doesn't match the Service's implemented Interface name.
#>
$beRoot = "C:\Users\joseb\Downloads\AeroLaAurora\AeroLaAurora\aeropuerto_be-develop"
$programFile = "$beRoot\Program.cs"

# 1. Parse all services to find exactly what interface they implement
$serviceFiles = Get-ChildItem "$beRoot\Services" -Filter "*Service.cs"
$serviceToInterface = @{}

foreach ($sf in $serviceFiles) {
    $content = Get-Content $sf.FullName -Raw
    if ($content -match 'class\s+(\w+Service)\s*:\s*(I\w+Service)') {
        $serviceName = $matches[1]
        $interfaceName = $matches[2]
        $serviceToInterface[$serviceName] = $interfaceName
    }
}

# 2. Update Program.cs
$lines = Get-Content $programFile
$newLines = @()

foreach ($line in $lines) {
    if ($line -match 'AddScoped<I\w+Service,\s*(\w+Service)>') {
        $serviceName = $matches[1]
        if ($serviceToInterface.ContainsKey($serviceName)) {
            $correctInterface = $serviceToInterface[$serviceName]
            # Replace the generic arguments
            $line = $line -replace 'AddScoped<[I\w]+,\s*' + $serviceName + '>', "AddScoped<$correctInterface, $serviceName>"
        }
    }
    # Deal with IDocumentosImportantesService which might be a typo in Program.cs
    if ($line -match 'IDocumentosImportantesService') {
        $line = $line -replace 'IDocumentosImportantesService', 'IDocumentoImportanteService'
    }
    $newLines += $line
}

Set-Content -Path $programFile -Value $newLines -Encoding UTF8
Write-Host "Fixed Program.cs exact interfaces"
