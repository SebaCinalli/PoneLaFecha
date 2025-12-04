@echo off
echo ========================================
echo  Iniciando PoneLaFecha
echo ========================================
echo.
echo Iniciando API en https://localhost:7296
start "PoneLaFecha API" cmd /k "cd PoneLaFecha.API && dotnet run"

echo Esperando 5 segundos para que la API se inicie...
timeout /t 5 /nobreak > nul

echo.
echo Iniciando UI.Web en https://localhost:7200
start "PoneLaFecha UI.Web" cmd /k "cd UI.Web && dotnet run"

echo.
echo ========================================
echo  Proyectos iniciandose...
echo ========================================
echo.
echo  API:    https://localhost:7296/swagger
echo  Web UI: https://localhost:7200
echo.
echo Presiona cualquier tecla para cerrar esta ventana...
pause > nul
