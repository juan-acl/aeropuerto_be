<#
.SYNOPSIS
  Aggressive fix for Program.cs DI registrations
#>
$beRoot = "C:\Users\joseb\Downloads\AeroLaAurora\AeroLaAurora\aeropuerto_be-develop"
$programFile = "$beRoot\Program.cs"

$serviceToInterface = @{}
Get-ChildItem "$beRoot\Services" -Filter "*Service.cs" | ForEach-Object {
    $content = Get-Content $_.FullName -Raw
    if ($content -match 'class\s+(\w+?Service)\s*:\s*(I\w+?Service)') {
        $serviceToInterface[$matches[1]] = $matches[2]
    }
}

$content = Get-Content $programFile -Raw
foreach ($key in $serviceToInterface.Keys) {
    $iface = $serviceToInterface[$key]
    $content = [regex]::Replace($content, "AddScoped<I\w+?Service,\s*$key>", "AddScoped<$iface, $key>")
}
Set-Content -Path $programFile -Value $content -Encoding UTF8
Write-Host "Aggressive Program.cs fix done."
