# ?? PoneLaFecha - Sistema de Gestión de Eventos

Sistema completo para la gestión de solicitudes de eventos, incluyendo reserva de salones, contratación de DJs, servicios de barra y gastronómicos.

---

## ?? Inicio Rápido

### ? Ejecutar la Aplicación (MÁS FÁCIL)

**Doble click en:**
```
start-both-projects.bat
```

Espera 15 segundos y abre tu navegador en: **https://localhost:7200**

¡Eso es todo! ??

---

## ?? Guías Disponibles

| Archivo | Para Quién | Descripción |
|---------|-----------|-------------|
| **[CHECKLIST.txt](CHECKLIST.txt)** | ?? Principiantes | Lista paso a paso visual |
| **[INICIO-RAPIDO.md](INICIO-RAPIDO.md)** | ?? Todos | Guía de inicio rápida |
| [SOLUCION-RAPIDA.md](SOLUCION-RAPIDA.md) | ?? Problema específico | Fix para "No se encontró la página" |
| [README-EJECUCION.md](README-EJECUCION.md) | ?? Detalles completos | Guía exhaustiva |
| [RESUMEN-SOLUCION.md](RESUMEN-SOLUCION.md) | ?? Técnicos | Resumen técnico |
| [INDICE-DOCUMENTACION.md](INDICE-DOCUMENTACION.md) | ?? Índice | Guía de todas las guías |

---

## ?? URLs de la Aplicación

| Servicio | URL | Descripción |
|----------|-----|-------------|
| **Web App** | https://localhost:7200 | Aplicación principal |
| **API Swagger** | https://localhost:7296/swagger | Documentación API |
| **Login** | https://localhost:7200/Auth/Login | Página de inicio de sesión |

---

## ? Características

- ?? **Autenticación completa** (Login/Register)
- ?? **Gestión de perfiles** de usuario
- ?? **Solicitudes de eventos**
- ?? **Catálogo de salones**
- ?? **Gestión de barras**
- ?? **Directorio de DJs**
- ??? **Servicios gastronómicos**
- ?? **Reportes y estadísticas**

---

## ??? Tecnologías

- **.NET 8**
- **ASP.NET Core Web API**
- **Razor Pages**
- **Entity Framework Core**
- **SQL Server**
- **Bootstrap 5**

---

## ?? Estructura del Proyecto

```
PoneLaFecha/
??? ?? Entidades/              # Modelos de datos
??? ?? Datos/                  # Contexto EF Core y Migrations
??? ?? Negocio/                # Lógica de negocio
??? ?? PoneLaFecha.API/        # Web API (Backend)
??? ?? UI.Web/                 # Aplicación Web (Frontend)
??? ?? UI.Desktop/             # Aplicación de escritorio
??? ?? start-both-projects.bat # Script de ejecución ?
??? ?? CHECKLIST.txt           # Guía paso a paso ?
??? ?? INICIO-RAPIDO.md        # Guía rápida ?
```

---

## ?? Verificar Estado

Para verificar si todo está funcionando:

```powershell
.\verificar-estado.ps1
```

---

## ?? Modos de Ejecución

### 1?? Script Automático (? Recomendado)
```bash
# Doble click o ejecutar:
start-both-projects.bat
```

### 2?? Visual Studio
1. Abrir `PoneLaFecha.sln`
2. Configurar "Varios proyectos de inicio"
3. Seleccionar `PoneLaFecha.API` y `UI.Web`
4. Presionar F5

### 3?? Manual (2 terminales)
```powershell
# Terminal 1 - API
cd PoneLaFecha.API
dotnet run

# Terminal 2 - Web
cd UI.Web
dotnet run
```

---

## ?? Solución de Problemas

### ? Error: "No se encontró la página"
**Causa:** La API no está ejecutándose

**Solución:** Lee [SOLUCION-RAPIDA.md](SOLUCION-RAPIDA.md)

### ? Error: "Puerto ya en uso"
```powershell
netstat -ano | findstr :7296
taskkill /PID <PID> /F
```

### ? Error: "Certificado SSL no confiable"
```powershell
dotnet dev-certs https --trust
```

---

## ?? Pruebas Rápidas

### Test 1: Crear Cuenta
1. Ve a: https://localhost:7200/Auth/Register
2. Completa el formulario
3. Click en "Registrarse"
4. ? Debería redirigir al Login

### Test 2: Iniciar Sesión
1. Ve a: https://localhost:7200/Auth/Login
2. Ingresa las credenciales
3. Click en "Iniciar Sesión"
4. ? Debería entrar al sistema

### Test 3: Explorar
- Ver salones disponibles
- Ver servicios de barra
- Ver DJs disponibles
- Crear una solicitud

---

## ?? Importante

**SIEMPRE debes ejecutar AMBOS proyectos:**
1. ? **PoneLaFecha.API** (Puerto 7296) - Backend
2. ? **UI.Web** (Puerto 7200) - Frontend

Si solo ejecutas uno, la aplicación no funcionará.

---

## ?? Estado del Proyecto

| Componente | Estado |
|------------|--------|
| API | ? Funcionando |
| UI.Web | ? Funcionando |
| Login/Register | ? Funcionando |
| Base de Datos | ? Configurada |
| Migrations | ? Aplicadas |

---

## ?? Contribuir

Este es un proyecto educativo. Si encuentras algún problema:

1. Revisa [SOLUCION-RAPIDA.md](SOLUCION-RAPIDA.md)
2. Consulta [README-EJECUCION.md](README-EJECUCION.md)
3. Ejecuta `verificar-estado.ps1`

---

## ?? Notas de Desarrollo

### Cambios Recientes

#### v1.1.0 - Corrección de Login/Register
- ? Corregido error en parámetros de `AuthController`
- ? Agregado campo `Telefono` al registro
- ? Corregido nombre de parámetro `nombreUsuario`
- ? Mejorados mensajes de error
- ? Creados scripts de ejecución automática

Ver detalles en: [RESUMEN-SOLUCION.md](RESUMEN-SOLUCION.md)

---

## ?? Para Aprender Más

- [?? Guía Completa de Ejecución](README-EJECUCION.md)
- [?? Solución Rápida a Problemas](SOLUCION-RAPIDA.md)
- [?? Índice de Documentación](INDICE-DOCUMENTACION.md)
- [? Checklist de Inicio](CHECKLIST.txt)

---

## ?? Licencia

Este proyecto es de uso educativo.

---

## ?? ¡Listo para Empezar!

**Ejecuta:**
```
start-both-projects.bat
```

**Abre:**
```
https://localhost:7200
```

**¡Disfruta!** ??

---

## ?? Ayuda

¿Necesitas ayuda? Revisa estos archivos en orden:

1. [CHECKLIST.txt](CHECKLIST.txt) - Lista paso a paso
2. [INICIO-RAPIDO.md](INICIO-RAPIDO.md) - Guía rápida
3. [SOLUCION-RAPIDA.md](SOLUCION-RAPIDA.md) - Problemas comunes
4. [README-EJECUCION.md](README-EJECUCION.md) - Guía completa

O ejecuta: `.\verificar-estado.ps1` para diagnosticar problemas.

---

**¡Desarrollado con ?? para la gestión de eventos!**
