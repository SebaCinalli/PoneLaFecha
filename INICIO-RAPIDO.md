# ?? INICIO RÁPIDO - PoneLaFecha

## ?? Ejecutar la Aplicación (3 opciones)

### ?? Opción 1: Script Automático (MÁS FÁCIL)
```bash
# Haz doble click en:
start-both-projects.bat
```

### ?? Opción 2: Visual Studio
1. Abre `PoneLaFecha.sln`
2. Clic derecho en la solución ? **"Configurar proyectos de inicio..."**
3. Selecciona **"Varios proyectos de inicio"**
4. Marca `PoneLaFecha.API` y `UI.Web` como **Iniciar**
5. Presiona **F5**

### ?? Opción 3: Manual (2 terminales)
```powershell
# Terminal 1 - API
cd PoneLaFecha.API
dotnet run

# Terminal 2 - Web
cd UI.Web
dotnet run
```

---

## ?? URLs de Acceso

| Servicio | URL | Descripción |
|----------|-----|-------------|
| **Web** | https://localhost:7200 | Aplicación principal |
| **API** | https://localhost:7296/swagger | Documentación API |
| **Login** | https://localhost:7200/Auth/Login | Página de login |

---

## ?? Verificar Estado

Para verificar si todo está funcionando:

```powershell
.\verificar-estado.ps1
```

O visita: https://localhost:7296/swagger

---

## ?? IMPORTANTE

**SIEMPRE necesitas ejecutar AMBOS proyectos:**
- ? **PoneLaFecha.API** (Puerto 7296) - Backend
- ? **UI.Web** (Puerto 7200) - Frontend

Si solo ejecutas UI.Web sin la API, verás el error: **"No se encontró la página"**

---

## ?? Solución de Problemas

### Error: "No se encontró la página"
**Causa:** La API no está ejecutándose

**Solución:** Ejecuta la API primero
```powershell
cd PoneLaFecha.API
dotnet run
```

### Error: "Puerto ya en uso"
```powershell
# Ver qué proceso usa el puerto
netstat -ano | findstr :7296

# Matar el proceso (reemplaza PID)
taskkill /PID <PID> /F
```

### Error: "Certificado SSL no confiable"
```powershell
dotnet dev-certs https --trust
```

---

## ?? Documentación Adicional

- ?? [Guía Completa de Ejecución](README-EJECUCION.md)
- ?? [Solución Rápida](SOLUCION-RAPIDA.md)

---

## ? Características

- ?? Sistema de autenticación (Login/Register)
- ?? Perfil de usuario
- ?? Gestión de solicitudes de eventos
- ?? Catálogo de salones
- ?? Gestión de barras
- ?? Directorio de DJs
- ??? Servicios gastronómicos

---

## ??? Tecnologías

- **.NET 8**
- **ASP.NET Core Web API**
- **Razor Pages**
- **Entity Framework Core**
- **SQL Server**

---

## ?? Notas

- La primera vez que ejecutes, se crearán datos de ejemplo automáticamente
- Puedes crear una cuenta nueva desde el link "Regístrate aquí"
- La API usa Swagger para documentación interactiva

---

¡Listo para comenzar! ??

Para ejecutar la aplicación, simplemente haz doble click en `start-both-projects.bat` o sigue cualquiera de las opciones anteriores.
