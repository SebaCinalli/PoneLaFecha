# PoneLaFecha - Sistema de Gestión de Eventos

## ?? Cumplimiento de Requisitos - 100%

Este proyecto cumple al **100%** con todos los requisitos especificados para el trabajo práctico.

---

## ? **REQUISITOS FUNCIONALES**

### 1. **Autenticación (Login)** ?
- **Desktop:** `UI.Desktop\FrmLogin.cs`
- **Web:** `UI.Web\Controllers\AuthController.cs` con acciones Login/Logout/Register

### 2. **Múltiples Tipos de Usuario** ?
- **Roles implementados:**
  - `Administrador`: Acceso completo al sistema
  - `Cliente`: Acceso limitado a sus propias solicitudes
- **Entidad:** `Entidades\Usuario.cs` con propiedad `Rol`

### 3. **Acceso Diferenciado por Rol** ?
- **Desktop:** Menú principal (`FrmMenuPrincipal.cs`) adapta opciones según rol
- **Web:** 
  - Filtro de autorización: `UI.Web\Filters\AuthorizeAttribute.cs`
  - Layout dinámico que muestra opciones según el rol del usuario

### 4. **Mínimo 2 ABMs** ?
**Se implementaron 8 ABMs completos:**
1. **Usuarios** (`FrmABMUsuario.cs`)
2. **Clientes** (`FrmABMCliente.cs`)
3. **Salones** (`FrmABMSalon.cs`)
4. **Barras** (`FrmABMBarra.cs`)
5. **DJs** (`FrmABMDj.cs`)
6. **Gastronómicos** (`FrmABMGastronomico.cs`)
7. **Zonas** (`FrmABMZona.cs`)
8. **Solicitudes** (`FrmABMSolicitud.cs`) ? **Con búsqueda por filtros**

### 5. **Búsqueda con Filtros en ABM** ?
**Archivo:** `UI.Desktop\FrmABMSolicitud.cs`

**Funcionalidades:**
- ComboBox para filtrar por estado: "Todos", "Pendiente", "Confirmada", "Cancelada"
- Método `CboEstado_SelectedIndexChanged` que filtra en tiempo real
- Botón "Limpiar Filtro" para resetear
- Usa `LogicaSolicitud.GetByEstadoAsync(estado)` para la consulta filtrada

```csharp
// Código del filtro
private async void CboEstado_SelectedIndexChanged(object sender, EventArgs e)
{
    if (cboEstado.SelectedItem.ToString() == "Todos")
    {
        CargarSolicitudes();
    }
    else
    {
   var estado = cboEstado.SelectedItem.ToString();
        var solicitudes = await _logicaSolicitud.GetByEstadoAsync(estado);
   dgvSolicitudes.DataSource = solicitudes;
        ConfigurarColumnas();
    }
}
```

### 6. **Mínimo 2 Reportes** ?
1. **Reporte de Solicitudes** (`FrmReporteSolicitudes.cs`)
   - Muestra estadísticas por estado
   - Filtrado por rango de fechas
   - ? **Incluye gráfico de barras**

2. **Reporte de Ingresos** (`FrmReporteIngresos.cs`)
   - Muestra ingresos por tipo de servicio
   - Filtrado por mes y año
   - ? **Incluye gráfico de barras**

3. **BONUS: Reporte ADO.NET** (`FrmReporteADO.cs`)
   - Demuestra uso de ADO.NET puro
   - Consultas directas con SqlConnection

### 7. **Reportes con Gráficos** ?
**Ambos reportes incluyen gráficos de barras:**
- Método `PnlGrafico_Paint` en ambos formularios
- Usa `Graphics.FillRectangle` para dibujar barras
- Colores diferenciados por categoría
- Proporcionales a los valores reales

---

## ?? **REQUISITOS TÉCNICOS**

### 1. **Desktop (WinForms)** ?
- **Proyecto:** `UI.Desktop.csproj`
- **Framework:** Windows Forms con .NET 8
- **Formularios:** 20+ formularios implementados

### 2. **Web (ASP.NET Core MVC)** ?
- **Proyecto:** `UI.Web.csproj`
- **Framework:** ASP.NET Core MVC con .NET 8
- **Controllers:** 9 controladores
- **Views:** Razor views con Bootstrap 5

### 3. **ADO.NET al menos una vez** ? ?
**IMPLEMENTACIÓN COMPLETA:**

#### **Archivo 1:** `Negocio\LogicaSalon.cs`
```csharp
/// <summary>
/// Método que usa ADO.NET puro para listar salones.
/// </summary>
public static List<Salon> ListarConADO()
{
var salones = new List<Salon>();
    string connectionString = ConnectionHelper.GetConnectionString();

  using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
     string query = "SELECT IdSalon, NombreSalon, Estado, MontoSalon FROM Salones";

using (var command = new SqlCommand(query, connection))
   {
     using (var reader = command.ExecuteReader())
  {
      while (reader.Read())
    {
                    var salon = new Salon
        {
      IdSalon = reader.GetInt32(0),
            NombreSalon = reader.GetString(1),
   Estado = reader.GetString(2),
               MontoSalon = reader.GetDecimal(3)
         };
      salones.Add(salon);
                }
    }
        }
    }

    return salones;
}
```

#### **Archivo 2:** `Negocio\LogicaCliente.cs`
```csharp
/// <summary>
/// Método que usa ADO.NET puro para contar clientes.
/// </summary>
public static int ObtenerTotalClientesConADO()
{
    int total = 0;
    string connectionString = ConnectionHelper.GetConnectionString();

    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        string query = "SELECT COUNT(*) FROM Clientes";

using (var command = new SqlCommand(query, connection))
        {
 total = (int)command.ExecuteScalar();
  }
    }

    return total;
}
```

#### **Uso en Desktop:** `UI.Desktop\FrmReporteADO.cs`
- Formulario completo que muestra datos obtenidos con ADO.NET
- Accesible desde Menú ? Reportes ? "Estadísticas con ADO.NET"

#### **Uso en Web:** `UI.Web\Controllers\EstadisticasController.cs`
- Vista completa: `UI.Web\Views\Estadisticas\Index.cshtml`
- Accesible desde el dashboard del administrador
- URL: `/Estadisticas/Index`

**Componentes ADO.NET utilizados:**
- ? `SqlConnection` - Para conectar a la base de datos
- ? `SqlCommand` - Para ejecutar queries
- ? `SqlDataReader` - Para leer resultados
- ? `ExecuteScalar` - Para consultas agregadas

### 4. **Entity Framework para el resto** ?
- **DbContext:** `Datos\AppDbContext.cs`
- **Migrations:** 6 migraciones en `Datos\Migrations\`
- **Configuración:** Relaciones, índices únicos, precisión decimal

### 5. **Validaciones a Nivel UI** ?

#### **Desktop:**
```csharp
// Ejemplo: FrmABMUsuario.cs
private bool ValidarCampos()
{
 if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
    {
   MessageBox.Show("El nombre de usuario es obligatorio.", 
          "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
    txtNombreUsuario.Focus();
        return false;
    }

    if (txtPassword.Text.Length < 6)
    {
        MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", 
       "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
    }
    
  // ... más validaciones
    return true;
}
```

#### **Web:**
```html
<!-- Ejemplo: Views\Solicitud\Crear.cshtml -->
<input asp-for="FechaDesde" type="date" class="form-control" required />
<span asp-validation-for="FechaDesde" class="text-danger"></span>

<input asp-for="MontoDJ" type="number" step="0.01" class="form-control" required />
<span asp-validation-for="MontoDJ" class="text-danger"></span>
```

### 6. **Validaciones a Nivel Lógica/Dominio** ?
**Archivo:** `Negocio\Validaciones.cs`

**Métodos implementados:**
- `ValidarUsuario(Usuario)` - Valida datos de usuarios
- `ValidarCliente(Cliente)` - Valida datos de clientes
- `ValidarSolicitud(Solicitud)` - Valida solicitudes
- `ValidarZona(Zona)` - Valida zonas
- `ValidarSalon(Salon)` - Valida salones
- `ValidarBarra(Barra)` - Valida barras
- `ValidarDj(Dj)` - Valida DJs
- `ValidarGastronomico(Gastronomico)` - Valida servicios gastronómicos

**Métodos auxiliares:**
- `EsEmailValido(string)` - Validación con Regex
- `EsTelefonoValido(string)` - Validación de formato
- `EsMontoValido(decimal)` - Validación de rangos
- `EsFechaValida(DateTime)` - Validación de fechas

**Ejemplo de uso:**
```csharp
public static int Crear(Usuario usuario)
{
    // Validar antes de crear
    var validacion = Validaciones.ValidarUsuario(usuario);
    if (!validacion.EsValido)
    {
     throw new Exception($"Validación fallida:\n{validacion.ObtenerMensajeErrores()}");
    }

    using var db = new AppDbContext();
    usuario.Password = EncriptarPassword(usuario.Password);
    db.Usuarios.Add(usuario);
    db.SaveChanges();
    return usuario.IdUsuario;
}
```

---

## ??? **ARQUITECTURA EN CAPAS**

### **1. UI.Desktop** - Interfaz de Usuario Desktop
- WinForms con .NET 8
- 20+ formularios
- Reportes con gráficos

### **2. UI.Web** - Interfaz de Usuario Web
- ASP.NET Core MVC
- Bootstrap 5
- Razor Views

### **3. Negocio** - Lógica de Negocios
- Clases estáticas `Logica*.cs`
- Validaciones
- Reglas de negocio
- **Métodos con ADO.NET** ?

### **4. Entidades** - Modelo de Dominio
- 16 entidades
- Anotaciones de validación
- Relaciones de navegación

### **5. Datos** - Acceso a Datos
- Entity Framework Core
- AppDbContext
- Migrations
- ConnectionHelper (para ADO.NET)

---

## ?? **RESUMEN DE CUMPLIMIENTO**

| Requisito | Estado | Implementación |
|-----------|--------|----------------|
| Autenticación | ? 100% | Login Desktop + Web |
| 2+ Tipos de Usuario | ? 100% | Administrador + Cliente |
| Mínimo 2 ABMs | ? 400% | 8 ABMs implementados |
| **Búsqueda con Filtros** | ? 100% | FrmABMSolicitud con filtro por estado |
| 2 Reportes | ? 150% | 3 reportes (2 requeridos + 1 bonus) |
| Reporte con Gráfico | ? 200% | AMBOS reportes con gráficos |
| Desktop | ? 100% | UI.Desktop (WinForms) |
| Web | ? 100% | UI.Web (ASP.NET Core MVC) |
| **ADO.NET al menos 1 vez** | ? 100% | 2 métodos + UI Desktop + UI Web |
| EF para el resto | ? 100% | AppDbContext + Migrations |
| Validaciones UI | ? 100% | Desktop + Web |
| Validaciones Lógica | ? 100% | Clase Validaciones completa |
| Arquitectura en Capas | ? 100% | 5 proyectos separados |

---

## ?? **CÓMO PROBAR LA IMPLEMENTACIÓN DE ADO.NET**

### **Opción 1: Desktop**
1. Ejecutar `UI.Desktop`
2. Iniciar sesión con usuario administrador
3. Ir a **Menú** ? **Reportes**
4. Hacer clic en **"Estadísticas con ADO.NET (Ejemplo técnico)"**
5. Se mostrará:
   - Listado de salones obtenido con `ListarConADO()`
   - Total de clientes obtenido con `ObtenerTotalClientesConADO()`

### **Opción 2: Web**
1. Ejecutar `UI.Web`
2. Iniciar sesión como administrador
3. En el dashboard, hacer clic en la tarjeta **"Estadísticas ADO.NET"**
4. O navegar directamente a: `/Estadisticas/Index`
5. Se mostrará:
   - Tabla de salones (ADO.NET)
   - Total de clientes (ADO.NET)
   - Código de ejemplo
   - Información técnica

---

## ?? **PAQUETES NUGET**

### Negocio
- `Microsoft.Data.SqlClient` (6.1.3) - Para ADO.NET

### Datos
- `Microsoft.EntityFrameworkCore` (9.0.9)
- `Microsoft.EntityFrameworkCore.SqlServer` (9.0.9)
- `Microsoft.EntityFrameworkCore.Tools` (9.0.9)

### UI.Web
- ASP.NET Core 8.0 (incluido en SDK)

---

## ?? **USUARIOS DE PRUEBA**

### Administrador
- **Usuario:** `chiqui123`
- **Contraseña:** `elchiqui123`

### Clientes
- **Usuario:** `cliente1` / **Contraseña:** `123456`
- **Usuario:** `cliente2` / **Contraseña:** `123456`

---

## ?? **NOTAS ADICIONALES**

1. **Base de Datos:** LocalDB (se crea automáticamente)
2. **Connection String:** Configurable vía variable de entorno `PLF_DB`
3. **Datos de Ejemplo:** Se crean automáticamente al iniciar
4. **Seguridad:** Contraseñas encriptadas con SHA256

---

## ? **EXTRAS IMPLEMENTADOS**

- ?? Encriptación de contraseñas
- ?? Reportes con gráficos en GDI+
- ?? UI moderna con Bootstrap 5
- ?? Filtros en tiempo real
- ?? Responsive design
- ? Validaciones exhaustivas
- ??? 8 ABMs completos (4 veces el mínimo)
- ?? 3 Reportes (1.5 veces el mínimo)

---

**? PROYECTO COMPLETO Y FUNCIONAL AL 100%**
