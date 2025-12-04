# ?? SOLUCIÓN RÁPIDA - Error "No se encontró la página"

## ?? PROBLEMA
Al intentar usar la aplicación web, recibes el error **"No se encontró la página"** porque la **API NO ESTÁ EJECUTÁNDOSE**.

---

## ? SOLUCIÓN MÁS RÁPIDA

### Opción A: Doble Click en el archivo `.bat`

1. Navega a la carpeta del proyecto
2. Haz **doble click** en: `start-both-projects.bat`
3. Se abrirán **2 ventanas de consola** (API y Web)
4. Espera 10-15 segundos
5. Abre tu navegador en: `https://localhost:7200`

---

### Opción B: Desde Visual Studio

1. **Abre Visual Studio** con `PoneLaFecha.sln`
2. **Clic derecho** en la solución (en el Explorador de soluciones)
3. Selecciona: **"Configurar proyectos de inicio..."**
4. Marca: **"Varios proyectos de inicio"**
5. Configura:
   - `PoneLaFecha.API` ? **Iniciar**
   - `UI.Web` ? **Iniciar**
   - Todo lo demás ? **Ninguno**
6. Click en **Aceptar**
7. Presiona **F5**

---

## ?? VERIFICAR QUE LA API FUNCIONA

Abre en tu navegador: `https://localhost:7296/swagger`

? Si ves la interfaz de Swagger ? **API funcionando correctamente**
? Si no carga ? La API no está ejecutándose

---

## ?? URLs IMPORTANTES

| Servicio | URL |
|----------|-----|
| **Swagger (API)** | https://localhost:7296/swagger |
| **Aplicación Web** | https://localhost:7200 |
| **Login** | https://localhost:7200/Auth/Login |

---

## ?? IMPORTANTE

**SIEMPRE debes tener ejecutándose:**
1. ? PoneLaFecha.API (Puerto 7296)
2. ? UI.Web (Puerto 7200)

Si cierras la API, la aplicación web dejará de funcionar.

---

## ?? Si algo falla

### Error: "Puerto ya en uso"
```powershell
# Ver qué está usando el puerto 7296
netstat -ano | findstr :7296

# Cerrar el proceso (reemplaza 12345 con el PID que aparece)
taskkill /PID 12345 /F
```

### Error: "Certificado SSL no confiable"
```powershell
dotnet dev-certs https --trust
```

---

## ?? ORDEN DE EJECUCIÓN

```
1. Ejecutar API (PoneLaFecha.API)
   ?? Esperar mensaje: "Now listening on: https://localhost:7296"

2. Ejecutar UI.Web
   ?? Esperar mensaje: "Now listening on: https://localhost:7200"

3. Abrir navegador en: https://localhost:7200
```

---

¡Eso es todo! ??
