using Microsoft.AspNetCore.Mvc;
using Entidades;
using Negocio;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Web.Controllers
{
    public class SolicitudController : Controller
    {
        private readonly LogicaSolicitud _logicaSolicitud;
        private readonly LogicaZona _logicaZona;

     public SolicitudController()
   {
       _logicaSolicitud = new LogicaSolicitud();
  _logicaZona = new LogicaZona();
    }

  public async Task<IActionResult> Index()
     {
   var solicitudes = await _logicaSolicitud.GetAllAsync();
       return View(solicitudes);
}

  public async Task<IActionResult> Crear()
   {
       // Verificar autenticación
       var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");
       if (string.IsNullOrEmpty(nombreUsuario))
       {
      return RedirectToAction("Login", "Auth");
       }

  await CargarListasAsync();
       return View();
    }

  [HttpPost]
  public async Task<IActionResult> Crear(DateTime FechaDesde, int[] salonesSeleccionados, int[] barrasSeleccionadas, int[] gastrosSeleccionados, int[] djsSeleccionados)
   {
 try
       {
      // Verificar autenticación
   var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");
        if (string.IsNullOrEmpty(nombreUsuario))
   {
     TempData["Error"] = "Debe iniciar sesión para crear una solicitud.";
       return RedirectToAction("Login", "Auth");
 }

    // Obtener el cliente asociado al usuario logueado
        var cliente = LogicaCliente.ObtenerPorNombreUsuario(nombreUsuario);
           if (cliente == null)
   {
      TempData["Error"] = "No se encontró el cliente asociado a su usuario. Por favor, contacte al administrador.";
await CargarListasAsync();
         return View();
       }

           // Validar fecha
        if (FechaDesde < DateTime.Today)
    {
   TempData["Error"] = "La fecha del evento no puede ser anterior a hoy.";
    await CargarListasAsync();
   return View();
           }

     // Crear la solicitud con datos automáticos
  var solicitud = new Solicitud
    {
         IdCliente = cliente.IdCliente,
             FechaDesde = FechaDesde,
    Estado = "Pendiente" // Estado automático
 };

       // Crear la solicitud
           await _logicaSolicitud.CreateAsync(solicitud);

      // Asignar servicios seleccionados
       if (salonesSeleccionados != null && salonesSeleccionados.Length > 0)
    {
  foreach (var idSalon in salonesSeleccionados)
   {
      await _logicaSolicitud.AsignarSalonASolicitudAsync(solicitud.IdSolicitud, idSalon);
}
      }

   if (barrasSeleccionadas != null && barrasSeleccionadas.Length > 0)
         {
foreach (var idBarra in barrasSeleccionadas)
          {
      await _logicaSolicitud.AsignarBarraASolicitudAsync(solicitud.IdSolicitud, idBarra);
     }
         }

    if (gastrosSeleccionados != null && gastrosSeleccionados.Length > 0)
    {
        foreach (var idGastro in gastrosSeleccionados)
        {
  await _logicaSolicitud.AsignarGastronomicoASolicitudAsync(solicitud.IdSolicitud, idGastro);
  }
          }

     if (djsSeleccionados != null && djsSeleccionados.Length > 0)
   {
       foreach (var idDj in djsSeleccionados)
         {
         await _logicaSolicitud.AsignarDjASolicitudAsync(solicitud.IdSolicitud, idDj);
   }
      }

      TempData["Success"] = "Solicitud creada exitosamente con estado Pendiente.";
        return RedirectToAction("Index");
       }
   catch (Exception ex)
       {
    TempData["Error"] = $"Error al crear la solicitud: {ex.Message}";
    await CargarListasAsync();
return View();
    }
 }

  public async Task<IActionResult> Editar(int id)
     {
       // Solo administradores pueden editar
       var rol = HttpContext.Session.GetString("Rol");
    if (rol != "Administrador")
       {
       TempData["Error"] = "Solo los administradores pueden editar solicitudes.";
           return RedirectToAction("Index");
  }

    var solicitud = await _logicaSolicitud.GetByIdAsync(id);
     if (solicitud == null)
      return NotFound();

   await CargarListasAsync();
   return View(solicitud);
 }

     [HttpPost]
  public async Task<IActionResult> Editar(Solicitud solicitud)
   {
       // Solo administradores pueden editar
       var rol = HttpContext.Session.GetString("Rol");
       if (rol != "Administrador")
       {
    TempData["Error"] = "Solo los administradores pueden editar solicitudes.";
    return RedirectToAction("Index");
  }

     if (ModelState.IsValid)
   {
  await _logicaSolicitud.UpdateAsync(solicitud);
           TempData["Success"] = "Solicitud actualizada exitosamente.";
       return RedirectToAction("Index");
      }
   await CargarListasAsync();
   return View(solicitud);
}

 public async Task<IActionResult> Eliminar(int id)
  {
       try
       {
    // Verificar autenticación
 var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");
       var rol = HttpContext.Session.GetString("Rol");
           
   if (string.IsNullOrEmpty(nombreUsuario))
         {
 return RedirectToAction("Login", "Auth");
      }

           // Si es cliente, verificar que la solicitud le pertenece
      if (rol == "Cliente")
       {
       var solicitud = await _logicaSolicitud.GetByIdAsync(id);
        if (solicitud == null)
    {
                   return NotFound();
               }

    var cliente = LogicaCliente.ObtenerPorNombreUsuario(nombreUsuario);
  if (cliente == null || solicitud.IdCliente != cliente.IdCliente)
     {
       TempData["Error"] = "No puede eliminar solicitudes que no le pertenecen.";
    return RedirectToAction("Index");
       }
        }

     await _logicaSolicitud.DeleteAsync(id);
       TempData["Success"] = "Solicitud eliminada exitosamente.";
  return RedirectToAction("Index");
       }
       catch (Exception ex)
     {
           TempData["Error"] = $"Error al eliminar la solicitud: {ex.Message}";
           return RedirectToAction("Index");
       }
 }

public async Task<IActionResult> Detalles(int id)
   {
    var solicitud = await _logicaSolicitud.GetByIdAsync(id);
 if (solicitud == null)
   return NotFound();

     ViewBag.MontoTotal = await _logicaSolicitud.CalcularMontoTotalAsync(id);
       
   // Pasar el rol a la vista para mostrar/ocultar opciones
       ViewBag.Rol = HttpContext.Session.GetString("Rol");
       
 return View(solicitud);
 }

        [HttpPost]
    public async Task<IActionResult> CambiarEstado(int id, string nuevoEstado)
  {
       // Solo administradores pueden cambiar el estado
       var rol = HttpContext.Session.GetString("Rol");
       if (rol != "Administrador")
     {
  TempData["Error"] = "Solo los administradores pueden cambiar el estado de las solicitudes.";
   return RedirectToAction("Detalles", new { id });
       }

 await _logicaSolicitud.CambiarEstadoAsync(id, nuevoEstado);
TempData["Success"] = $"Estado actualizado a '{nuevoEstado}' exitosamente.";
   return RedirectToAction("Detalles", new { id });
   }

   private async Task CargarListasAsync()
  {
    ViewBag.Salones = LogicaSalon.Listar();
  ViewBag.Barras = Negocio.LogicaBarra.Listar();
 ViewBag.Gastronomicos = LogicaGastronomico.Listar();
  ViewBag.Djs = LogicaDj.Listar();
    }
    }
}
