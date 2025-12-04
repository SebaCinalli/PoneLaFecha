# ?? Guía de Ejecución - PoneLaFecha

## ?? Problema: "No se encontró la página" al acceder a la API

Este error ocurre porque la **API no está ejecutándose**. Para que la aplicación web funcione correctamente, necesitas ejecutar **DOS proyectos simultáneamente**:

1. **PoneLaFecha.API** (Backend - Puerto 7296)
2. **UI.Web** (Frontend - Puerto 7200)

---

## ? Solución 1: Configurar Visual Studio (RECOMENDADO)

### Pasos:

1. **Abre Visual Studio** con la solución `PoneLaFecha.sln`

2. **Clic derecho** en la solución "PoneLaFecha" en el **Explorador de soluciones**

3. Selecciona **"Configurar proyectos de inicio..."** o **"Set Startup Projects..."**

4. Selecciona la opción **"Varios proyectos de inicio"** o **"Multiple startup projects"**

5. Configura los proyectos así:
   ```
   ? PoneLaFecha.API  ?  Iniciar (Start)
   ? UI.Web           ?  Iniciar (Start)
   ? UI.Desktop       ?  Ninguno (None)
   ? Entidades        ?  Ninguno (None)
   ? Datos            ?  Ninguno (None)
   ? Negocio          ?  Ninguno (None)
   ```

6. Click en **"Aceptar"** o **"OK"**

7. Presiona **F5** o click en **"Iniciar"** / **"Start"**

### Resultado:
Se abrirán **dos ventanas de navegador**:
- ?? API Swagger: `https://localhost:7296/swagger`
- ?? Aplicación Web: `https://localhost:7200`

---

## ? Solución 2: Usar el Script PowerShell

### Ejecución rápida:

1. Abre **PowerShell** en la carpeta raíz del proyecto

2. Ejecuta:
   ```powershell
   .\start-both-projects.ps1
   ```

3. Se abrirán dos ventanas de PowerShell:
   - Una con la **API** ejecutándose
   - Otra con **UI.Web** ejecutándose

4. Espera a que ambas se inicien completamente

5. Abre tu navegador en: `https://localhost:7200`

---

## ? Solución 3: Ejecutar Manualmente (Dos Terminales)

### Terminal 1 - Ejecutar la API:

```powershell
cd C:\repositorios-tp\PoneLaFecha\PoneLaFecha.API
dotnet run
```

**Espera** hasta ver:
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7296
```

### Terminal 2 - Ejecutar UI.Web:

Abre **otra terminal** PowerShell:

```powershell
cd C:\repositorios-tp\PoneLaFecha\UI.Web
dotnet run
```

**Espera** hasta ver:
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7200
```

### Acceder a la aplicación:

Abre tu navegador en: `https://localhost:7200`

---

## ?? Verificar que la API está funcionando

### Opción 1: Acceder a Swagger UI
Abre en tu navegador: `https://localhost:7296/swagger`

Deberías ver la interfaz de Swagger con todos los endpoints disponibles.

### Opción 2: Probar un endpoint
Abre en tu navegador: `https://localhost:7296/api/Salon`

Deberías ver una respuesta JSON con la lista de salones.

---

## ?? Solución de Problemas

### Problema: "Puerto ya está en uso"

Si recibes el error `Address already in use`:

```powershell
# Verificar qué proceso usa el puerto 7296
netstat -ano | findstr :7296

# Matar el proceso (reemplaza PID con el número que aparece)
taskkill /PID <PID> /F
```

### Problema: Certificado SSL no válido

Si el navegador muestra advertencia de certificado:

```powershell
dotnet dev-certs https --trust
```

---

## ?? URLs de la Aplicación

| Servicio | URL | Descripción |
|----------|-----|-------------|
| **API** | `https://localhost:7296` | Backend REST API |
| **Swagger** | `https://localhost:7296/swagger` | Documentación API |
| **Web UI** | `https://localhost:7200` | Aplicación Web |
| **Login** | `https://localhost:7200/Auth/Login` | Página de inicio de sesión |

---

## ?? Credenciales de Prueba

Una vez que ambos proyectos estén ejecutándose, puedes:

1. **Crear una nueva cuenta** desde el enlace "Regístrate aquí"
2. O usar credenciales de prueba si existen en la base de datos

---

## ?? Notas Importantes

- ?? **SIEMPRE** debes ejecutar la API **ANTES** de usar la aplicación web
- ?? Si cierras la API, la aplicación web dejará de funcionar
- ? La API debe estar ejecutándose en `https://localhost:7296`
- ? UI.Web debe estar ejecutándose en `https://localhost:7200`

---

## ? Resumen de Comandos Rápidos

```powershell
# Método más rápido - Script automático
.\start-both-projects.ps1

# O manualmente en dos terminales diferentes:
# Terminal 1:
cd PoneLaFecha.API; dotnet run

# Terminal 2:
cd UI.Web; dotnet run
```

---

¡Listo! Ahora tu aplicación debería funcionar correctamente. ??
