# PoneLaFecha

Sistema de gesti�n de eventos con aplicaci�n web (Razor Pages) y aplicaci�n de escritorio (Windows Forms).

## ?? Requisitos Previos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) o [SQL Server Express](https://www.microsoft.com/sql-server/sql-server-editions-express)
- Visual Studio 2022 (opcional, pero recomendado)

## ??? Estructura del Proyecto

```
PoneLaFecha/
??? Entidades/          # Modelos de dominio
??? Datos/              # Capa de acceso a datos (Entity Framework Core)
??? Negocio/            # L�gica de negocio
??? UI.Web/             # Aplicaci�n web Razor Pages
??? UI.Desktop/         # Aplicaci�n de escritorio Windows Forms
```

## ?? Configuraci�n Inicial

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

#### Opci�n A: Usando la Cadena de Conexi�n por Defecto

La aplicaci�n usa LocalDB por defecto. Aseg�rate de tener SQL Server LocalDB instalado.

#### Opci�n B: Configurar tu Propia Cadena de Conexi�n

Edita el archivo `Datos/AppDbContext.cs` y modifica la cadena de conexi�n seg�n tu configuraci�n de SQL Server.

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

**Nota:** Esto eliminar� todos los datos existentes en la base de datos. Los datos de ejemplo se crear�n autom�ticamente al ejecutar la aplicaci�n por primera vez.

## ?? Ejecutar la Aplicaci�n Web

### Opci�n 1: Usando dotnet CLI

1. Navega al directorio del proyecto web:
   ```bash
   cd UI.Web
   ```

2. Ejecuta la aplicaci�n:
   ```bash
   dotnet run
   ```

3. Abre tu navegador en:
   - HTTPS: `https://localhost:5001`
   - HTTP: `http://localhost:5000`

### Opci�n 2: Usando Visual Studio

1. Abre la soluci�n `PoneLaFecha.sln` en Visual Studio
2. Establece `UI.Web` como proyecto de inicio (clic derecho ? "Establecer como proyecto de inicio")
3. Presiona `F5` o haz clic en el bot�n "Iniciar"

### ?? Credenciales de Acceso (si aplica)

La aplicaci�n web inicia en la ruta `/Auth/Login`. Verifica con el equipo las credenciales de prueba o crea un usuario seg�n la funcionalidad implementada.

## ??? Ejecutar la Aplicaci�n de Escritorio

### Opci�n 1: Usando dotnet CLI

1. Navega al directorio del proyecto de escritorio:
   ```bash
   cd UI.Desktop
   ```

2. Ejecuta la aplicaci�n:
   ```bash
   dotnet run
   ```

### Opci�n 2: Usando Visual Studio

1. Abre la soluci�n `PoneLaFecha.sln` en Visual Studio
2. Establece `UI.Desktop` como proyecto de inicio (clic derecho ? "Establecer como proyecto de inicio")
3. Presiona `F5` o haz clic en el bot�n "Iniciar"

### ?? Nota para Windows Forms

La aplicaci�n de escritorio requiere Windows para ejecutarse, ya que utiliza Windows Forms (net8.0-windows).

## ??? Datos de Ejemplo

La aplicaci�n genera datos de ejemplo autom�ticamente al iniciar:

- **Salones**: 3 salones de ejemplo (Emperador, Cristal, Garden)
- **DJs**: Varios DJs con diferentes estados y tarifas
- **Gastron�micos**: Servicios gastron�micos de ejemplo

Estos datos se crean solo si las tablas est�n vac�as.

## ??? Compilar la Soluci�n

Para compilar toda la soluci�n:

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

## ?? Publicar la Aplicaci�n

### Publicar la Aplicaci�n Web

```bash
cd UI.Web
dotnet publish --configuration Release --output ./publish
```

### Publicar la Aplicaci�n de Escritorio

```bash
cd UI.Desktop
dotnet publish --configuration Release --output ./publish
```

## ?? Soluci�n de Problemas

### Error de Conexi�n a la Base de Datos

- Verifica que SQL Server est� ejecut�ndose
- Confirma que la cadena de conexi�n sea correcta
- Aseg�rate de haber aplicado las migraciones

### Error "Ya existe una tabla Solicitudes" u otras tablas duplicadas

Si recibes errores sobre tablas que ya existen:

```bash
# Eliminar completamente la base de datos
dotnet ef database drop --project Datos --startup-project UI.Web --force

# Recrear desde cero
dotnet ef database update --project Datos --startup-project UI.Web
```

### Errores de Compilaci�n

```bash
# Limpiar la soluci�n
dotnet clean

# Restaurar paquetes
dotnet restore

# Recompilar
dotnet build
```

### Puerto ya en Uso (Aplicaci�n Web)

Puedes cambiar el puerto editando `UI.Web/Properties/launchSettings.json` o ejecutando:

```bash
dotnet run --urls "http://localhost:5050;https://localhost:5051"
```

### Problemas con Migraciones

Si necesitas crear una nueva migraci�n:

```bash
dotnet ef migrations add NombreDeLaMigracion --project Datos --startup-project UI.Web
```

Para ver el historial de migraciones:

```bash
dotnet ef migrations list --project Datos --startup-project UI.Web
```

Para revertir a una migraci�n espec�fica:

```bash
dotnet ef database update NombreDeLaMigracion --project Datos --startup-project UI.Web
```

## ?? Tecnolog�as Utilizadas

- **.NET 8**: Framework principal
- **ASP.NET Core Razor Pages**: Aplicaci�n web
- **Windows Forms**: Aplicaci�n de escritorio
- **Entity Framework Core 9**: ORM para acceso a datos
- **SQL Server**: Base de datos
- **Bootstrap**: Framework CSS (aplicaci�n web)
- **jQuery**: Librer�a JavaScript (aplicaci�n web)

## ?? Contribuir

1. Crea una rama para tu caracter�stica (`git checkout -b feature/nueva-caracteristica`)
2. Realiza tus cambios y haz commit (`git commit -am 'Agregar nueva caracter�stica'`)
3. Sube tus cambios (`git push origin feature/nueva-caracteristica`)
4. Abre un Pull Request

## ?? Licencia

Este proyecto es parte de un trabajo pr�ctico acad�mico.

## ?? Contacto

Para m�s informaci�n, contacta al equipo de desarrollo o visita el [repositorio en GitHub](https://github.com/SebaCinalli/PoneLaFecha).
