# ?? Índice de Documentación - PoneLaFecha

## ?? Archivos de Ejecución

### ?? Para Ejecutar la Aplicación

| Archivo | Descripción | Uso |
|---------|-------------|-----|
| **`start-both-projects.bat`** ? | Script Windows para ejecutar API + Web | Doble click |
| `start-both-projects.ps1` | Script PowerShell alternativo | `.\start-both-projects.ps1` |
| `verificar-estado.ps1` | Verifica si los servicios están corriendo | `.\verificar-estado.ps1` |

---

## ?? Documentación

### ?? Guías de Inicio

| Archivo | Para Quién | Contenido |
|---------|-----------|-----------|
| **`CHECKLIST.txt`** ? | Principiantes | Lista paso a paso visual |
| **`INICIO-RAPIDO.md`** ? | Todos | Guía de inicio rápida |
| `SOLUCION-RAPIDA.md` | Quien tiene el problema | Solución específica al error |
| `README-EJECUCION.md` | Quien quiere detalles | Guía completa y detallada |
| `RESUMEN-SOLUCION.md` | Técnicos | Resumen técnico completo |

---

## ?? ¿Qué Archivo Usar?

### Si eres nuevo:
1. Lee: **`CHECKLIST.txt`** ??
2. Ejecuta: **`start-both-projects.bat`** ??
3. Si falla, lee: **`INICIO-RAPIDO.md`** ??

### Si tienes el error "No se encontró la página":
1. Lee: **`SOLUCION-RAPIDA.md`** ??
2. Ejecuta: `verificar-estado.ps1` ??

### Si quieres entender todo:
1. Lee: **`RESUMEN-SOLUCION.md`** ??
2. Lee: `README-EJECUCION.md` ??

---

## ?? Contenido de Cada Archivo

### `start-both-projects.bat` ? (MÁS USADO)
```
Script Windows Batch que:
- Ejecuta PoneLaFecha.API en una ventana
- Ejecuta UI.Web en otra ventana
- Muestra las URLs de acceso

USO: Doble click en el archivo
```

### `start-both-projects.ps1`
```
Script PowerShell que:
- Hace lo mismo que el .bat pero con más funcionalidad
- Abre ventanas separadas de PowerShell
- Muestra mensajes de progreso

USO: .\start-both-projects.ps1
```

### `verificar-estado.ps1`
```
Script de diagnóstico que:
- Verifica si la API está corriendo
- Verifica si UI.Web está corriendo
- Muestra el estado de los puertos
- Da recomendaciones si algo falla

USO: .\verificar-estado.ps1
```

### `CHECKLIST.txt` ? (PRINCIPIANTES)
```
Lista visual paso a paso de:
- Cómo ejecutar la aplicación (3 opciones)
- Cómo verificar que funciona
- Cómo probar el login/register
- Qué hacer si algo falla

LEER: Con cualquier editor de texto
```

### `INICIO-RAPIDO.md` ? (TODOS)
```
Guía rápida con:
- 3 formas de ejecutar la app
- URLs de acceso
- Solución de problemas comunes
- Verificación rápida

LEER: Con Visual Studio, VS Code, o navegador
```

### `SOLUCION-RAPIDA.md` (PROBLEMA ESPECÍFICO)
```
Solución al problema:
"No se encontró la página" / Login no funciona

Incluye:
- Explicación del problema
- Solución paso a paso
- Verificación de la API
- Orden de ejecución

LEER: Si tienes el error específico
```

### `README-EJECUCION.md` (COMPLETA)
```
Guía completa con:
- 3 métodos de ejecución detallados
- Verificación paso a paso
- Solución de problemas exhaustiva
- URLs importantes
- Credenciales de prueba

LEER: Si quieres todos los detalles
```

### `RESUMEN-SOLUCION.md` (TÉCNICO)
```
Documento técnico con:
- Diagnóstico del problema original
- Cambios realizados en el código
- Estado de compilación
- Tests de verificación
- Checklist completo

LEER: Si quieres entender qué se cambió
```

---

## ?? Flujo Recomendado

### Primera Vez Usando la App:

```
1. Leer: CHECKLIST.txt
   ?
2. Ejecutar: start-both-projects.bat
   ?
3. Si funciona ? ¡Usar la app! ?
   Si falla ? Ir al paso 4
   ?
4. Ejecutar: verificar-estado.ps1
   ?
5. Leer: SOLUCION-RAPIDA.md
   ?
6. Si sigue fallando: README-EJECUCION.md
```

### Ya Usaste la App Antes:

```
1. Ejecutar: start-both-projects.bat
   ?
2. Esperar 15 segundos
   ?
3. Ir a: https://localhost:7200
   ?
4. ¡Listo! ?
```

### Si Algo Falla:

```
1. Ejecutar: verificar-estado.ps1
   ?
2. Ver qué servicio no está corriendo
   ?
3. Leer: SOLUCION-RAPIDA.md
   ?
4. Aplicar la solución
   ?
5. Ejecutar: start-both-projects.bat de nuevo
```

---

## ?? Acceso Rápido por Necesidad

| Necesidad | Archivo |
|-----------|---------|
| ?? **Ejecutar rápido** | `start-both-projects.bat` |
| ?? **Guía paso a paso** | `CHECKLIST.txt` |
| ?? **Verificar estado** | `verificar-estado.ps1` |
| ? **Tengo un error** | `SOLUCION-RAPIDA.md` |
| ?? **Quiero entender** | `RESUMEN-SOLUCION.md` |
| ?? **Primera vez** | `INICIO-RAPIDO.md` |
| ?? **Todos los detalles** | `README-EJECUCION.md` |

---

## ?? Leyenda de Archivos

### ? = Más Importante / Más Usado
- `start-both-projects.bat` ?
- `CHECKLIST.txt` ?
- `INICIO-RAPIDO.md` ?

### ?? = Guía Rápida
- `CHECKLIST.txt`
- `INICIO-RAPIDO.md`
- `SOLUCION-RAPIDA.md`

### ?? = Documentación Completa
- `README-EJECUCION.md`
- `RESUMEN-SOLUCION.md`

### ?? = Herramientas
- `start-both-projects.bat`
- `start-both-projects.ps1`
- `verificar-estado.ps1`

---

## ?? Recomendación Final

### Para la mayoría de usuarios:

1. **Ejecutar:** `start-both-projects.bat`
2. **Si falla, leer:** `CHECKLIST.txt`
3. **Si sigue fallando, ejecutar:** `verificar-estado.ps1`

**¡Eso es todo lo que necesitas!** ??

---

## ?? Si Necesitas Más Ayuda

Todos los archivos mencionados están en la carpeta raíz del proyecto:
```
C:\repositorios-tp\PoneLaFecha\
```

Abre cualquiera de ellos con:
- Visual Studio
- Visual Studio Code
- Notepad
- Cualquier editor de texto

---

¡Feliz coding! ??
