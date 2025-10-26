# PoneLaFecha

Sistema de gestión de eventos con aplicación web (Razor Pages) y aplicación de escritorio (Windows Forms).

## ?? Requisitos Previos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) o [SQL Server Express](https://www.microsoft.com/sql-server/sql-server-editions-express)
- Visual Studio 2022 (opcional, pero recomendado)

## ??? Estructura del Proyecto

```
PoneLaFecha/
??? Entidades/          # Modelos de dominio
??? Datos/              # Capa de acceso a datos (Entity Framework Core)
??? Negocio/            # Lógica de negocio
??? UI.Web/             # Aplicación web Razor Pages
??? UI.Desktop/         # Aplicación de escritorio Windows Forms
```

## ?? Configuración Inicial

### 1. Clonar el Repositorio

```bash
git clone https://github.com/SebaCinalli/PoneLaFecha
cd PoneLaFecha
```

### 2. Restaurar Dependencias

```bash
dotnet restore
```

### 3. Configurar la Base de Datos

#### Opción A: Usando la Cadena de Conexión por Defecto

La aplicación usa LocalDB por defecto. Asegúrate de tener SQL Server LocalDB instalado.

#### Opción B: Configurar tu Propia Cadena de Conexión

Edita el archivo `Datos/AppDbContext.cs` y modifica la cadena de conexión según tu configuración de SQL Server.

### 4. Aplicar Migraciones

```bash
dotnet ef database update --project Datos --startup-project UI.Web
```

### 5. Eliminar y Recrear la Base de Datos (si es necesario)

Si experimentas problemas con la base de datos existente o necesitas empezar desde cero:

```bash
# Eliminar la base de datos existente
dotnet ef database drop --project Datos --startup-project UI.Web --force

# Recrear la base de datos con todas las migraciones
dotnet ef database update --project Datos --startup-project UI.Web
```

**Nota:** Esto eliminará todos los datos existentes en la base de datos. Los datos de ejemplo se crearán automáticamente al ejecutar la aplicación por primera vez.

## ?? Ejecutar la Aplicación Web

### Opción 1: Usando dotnet CLI

1. Navega al directorio del proyecto web:
   ```bash
   cd UI.Web
   ```

2. Ejecuta la aplicación:
   ```bash
   dotnet run
   ```

3. Abre tu navegador en:
   - HTTPS: `https://localhost:5001`
   - HTTP: `http://localhost:5000`

### Opción 2: Usando Visual Studio

1. Abre la solución `PoneLaFecha.sln` en Visual Studio
2. Establece `UI.Web` como proyecto de inicio (clic derecho ? "Establecer como proyecto de inicio")
3. Presiona `F5` o haz clic en el botón "Iniciar"

### ?? Credenciales de Acceso (si aplica)

La aplicación web inicia en la ruta `/Auth/Login`. Verifica con el equipo las credenciales de prueba o crea un usuario según la funcionalidad implementada.

## ??? Ejecutar la Aplicación de Escritorio

### Opción 1: Usando dotnet CLI

1. Navega al directorio del proyecto de escritorio:
   ```bash
   cd UI.Desktop
   ```

2. Ejecuta la aplicación:
   ```bash
   dotnet run
   ```

### Opción 2: Usando Visual Studio

1. Abre la solución `PoneLaFecha.sln` en Visual Studio
2. Establece `UI.Desktop` como proyecto de inicio (clic derecho ? "Establecer como proyecto de inicio")
3. Presiona `F5` o haz clic en el botón "Iniciar"

### ?? Nota para Windows Forms

La aplicación de escritorio requiere Windows para ejecutarse, ya que utiliza Windows Forms (net8.0-windows).

## ??? Datos de Ejemplo

La aplicación genera datos de ejemplo automáticamente al iniciar:

- **Salones**: 3 salones de ejemplo (Emperador, Cristal, Garden)
- **DJs**: Varios DJs con diferentes estados y tarifas
- **Gastronómicos**: Servicios gastronómicos de ejemplo

Estos datos se crean solo si las tablas están vacías.

## ??? Compilar la Solución

Para compilar toda la solución:

```bash
dotnet build
```

Para compilar en modo Release:

```bash
dotnet build --configuration Release
```

## ?? Ejecutar Pruebas (si existen)

```bash
dotnet test
```

## ?? Publicar la Aplicación

### Publicar la Aplicación Web

```bash
cd UI.Web
dotnet publish --configuration Release --output ./publish
```

### Publicar la Aplicación de Escritorio

```bash
cd UI.Desktop
dotnet publish --configuration Release --output ./publish
```

## ?? Solución de Problemas

### Error de Conexión a la Base de Datos

- Verifica que SQL Server esté ejecutándose
- Confirma que la cadena de conexión sea correcta
- Asegúrate de haber aplicado las migraciones

### Error "Ya existe una tabla Solicitudes" u otras tablas duplicadas

Si recibes errores sobre tablas que ya existen:

```bash
# Eliminar completamente la base de datos
dotnet ef database drop --project Datos --startup-project UI.Web --force

# Recrear desde cero
dotnet ef database update --project Datos --startup-project UI.Web
```

### Errores de Compilación

```bash
# Limpiar la solución
dotnet clean

# Restaurar paquetes
dotnet restore

# Recompilar
dotnet build
```

### Puerto ya en Uso (Aplicación Web)

Puedes cambiar el puerto editando `UI.Web/Properties/launchSettings.json` o ejecutando:

```bash
dotnet run --urls "http://localhost:5050;https://localhost:5051"
```

### Problemas con Migraciones

Si necesitas crear una nueva migración:

```bash
dotnet ef migrations add NombreDeLaMigracion --project Datos --startup-project UI.Web
```

Para ver el historial de migraciones:

```bash
dotnet ef migrations list --project Datos --startup-project UI.Web
```

Para revertir a una migración específica:

```bash
dotnet ef database update NombreDeLaMigracion --project Datos --startup-project UI.Web
```

## ?? Tecnologías Utilizadas

- **.NET 8**: Framework principal
- **ASP.NET Core Razor Pages**: Aplicación web
- **Windows Forms**: Aplicación de escritorio
- **Entity Framework Core 9**: ORM para acceso a datos
- **SQL Server**: Base de datos
- **Bootstrap**: Framework CSS (aplicación web)
- **jQuery**: Librería JavaScript (aplicación web)

## ?? Contribuir

1. Crea una rama para tu característica (`git checkout -b feature/nueva-caracteristica`)
2. Realiza tus cambios y haz commit (`git commit -am 'Agregar nueva característica'`)
3. Sube tus cambios (`git push origin feature/nueva-caracteristica`)
4. Abre un Pull Request

## ?? Licencia

Este proyecto es parte de un trabajo práctico académico.

## ?? Contacto

Para más información, contacta al equipo de desarrollo o visita el [repositorio en GitHub](https://github.com/SebaCinalli/PoneLaFecha).
