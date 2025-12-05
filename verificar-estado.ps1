# Script para verificar el estado de los servicios
Write-Host "`n========================================" -ForegroundColor Cyan
Write-Host "  Verificador de Estado - PoneLaFecha" -ForegroundColor Cyan
Write-Host "========================================`n" -ForegroundColor Cyan

function Test-ServiceRunning {
    param(
        [string]$Url,
        [string]$ServiceName
    )
    
    try {
        $response = Invoke-WebRequest -Uri $Url -UseBasicParsing -TimeoutSec 3 -ErrorAction Stop
        if ($response.StatusCode -eq 200) {
            Write-Host "? $ServiceName está EJECUTÁNDOSE" -ForegroundColor Green
            Write-Host "   URL: $Url" -ForegroundColor Gray
            return $true
        }
    }
    catch {
        Write-Host "? $ServiceName NO está ejecutándose" -ForegroundColor Red
        Write-Host "   URL: $Url" -ForegroundColor Gray
        Write-Host "   Error: $($_.Exception.Message)" -ForegroundColor Yellow
        return $false
    }
}

# Verificar API
Write-Host "`n?? Verificando API..." -ForegroundColor Yellow
$apiRunning = Test-ServiceRunning -Url "https://localhost:7296/swagger/index.html" -ServiceName "PoneLaFecha.API"

# Verificar UI.Web
Write-Host "`n?? Verificando UI.Web..." -ForegroundColor Yellow
$webRunning = Test-ServiceRunning -Url "https://localhost:7200" -ServiceName "UI.Web"

# Verificar puertos en uso
Write-Host "`n?? Verificando puertos..." -ForegroundColor Yellow
$port7296 = netstat -ano | findstr ":7296" | Select-Object -First 1
$port7200 = netstat -ano | findstr ":7200" | Select-Object -First 1

if ($port7296) {
    Write-Host "? Puerto 7296 (API) está en USO" -ForegroundColor Green
} else {
    Write-Host "??  Puerto 7296 (API) está LIBRE" -ForegroundColor Yellow
}

if ($port7200) {
    Write-Host "? Puerto 7200 (Web) está en USO" -ForegroundColor Green
} else {
    Write-Host "??  Puerto 7200 (Web) está LIBRE" -ForegroundColor Yellow
}

# Resumen final
Write-Host "`n========================================" -ForegroundColor Cyan
Write-Host "  RESUMEN" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan

if ($apiRunning -and $webRunning) {
    Write-Host "? TODO ESTÁ FUNCIONANDO CORRECTAMENTE" -ForegroundColor Green
    Write-Host "`n?? Puedes acceder a:" -ForegroundColor Cyan
    Write-Host "   • Aplicación Web: https://localhost:7200" -ForegroundColor White
    Write-Host "   • API Swagger:    https://localhost:7296/swagger" -ForegroundColor White
}
elseif ($apiRunning -and -not $webRunning) {
    Write-Host "??  API funcionando, pero UI.Web NO" -ForegroundColor Yellow
    Write-Host "`n?? Ejecuta:" -ForegroundColor Cyan
    Write-Host "   cd UI.Web" -ForegroundColor White
    Write-Host "   dotnet run" -ForegroundColor White
}
elseif (-not $apiRunning -and $webRunning) {
    Write-Host "??  UI.Web funcionando, pero API NO" -ForegroundColor Yellow
    Write-Host "`n?? Ejecuta:" -ForegroundColor Cyan
    Write-Host "   cd PoneLaFecha.API" -ForegroundColor White
    Write-Host "   dotnet run" -ForegroundColor White
}
else {
    Write-Host "? NINGÚN SERVICIO ESTÁ EJECUTÁNDOSE" -ForegroundColor Red
    Write-Host "`n?? Ejecuta:" -ForegroundColor Cyan
    Write-Host "   .\start-both-projects.bat" -ForegroundColor White
    Write-Host "   O usa Visual Studio con proyectos de inicio múltiples" -ForegroundColor White
}

Write-Host "`n========================================`n" -ForegroundColor Cyan
Write-Host "Presiona cualquier tecla para salir..." -ForegroundColor Gray
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
