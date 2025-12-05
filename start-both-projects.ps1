# Script para iniciar tanto la API como la aplicación Web
Write-Host "Iniciando PoneLaFecha API y UI.Web..." -ForegroundColor Green

# Inicia la API en una nueva ventana de PowerShell
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd 'C:\repositorios-tp\PoneLaFecha\PoneLaFecha.API'; Write-Host 'Iniciando API en https://localhost:7296' -ForegroundColor Cyan; dotnet run"

# Espera 5 segundos para que la API se inicie
Write-Host "Esperando 5 segundos para que la API se inicie..." -ForegroundColor Yellow
Start-Sleep -Seconds 5

# Inicia UI.Web en otra ventana de PowerShell
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd 'C:\repositorios-tp\PoneLaFecha\UI.Web'; Write-Host 'Iniciando UI.Web en https://localhost:7200' -ForegroundColor Cyan; dotnet run"

Write-Host "`n? Ambos proyectos están iniciándose en ventanas separadas" -ForegroundColor Green
Write-Host "?? API: https://localhost:7296/swagger" -ForegroundColor Cyan
Write-Host "?? Web: https://localhost:7200" -ForegroundColor Cyan
Write-Host "`nPresiona cualquier tecla para cerrar esta ventana..." -ForegroundColor Yellow
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
