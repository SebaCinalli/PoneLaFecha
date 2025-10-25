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
    await CargarListasAsync();
            return View();
    }

  [HttpPost]
  public async Task<IActionResult> Crear(Solicitud solicitud)
        {
  if (ModelState.IsValid)
   {
     await _logicaSolicitud.CreateAsync(solicitud);
         return RedirectToAction("Index");
            }
   await CargarListasAsync();
  return View(solicitud);
 }

  public async Task<IActionResult> Editar(int id)
        {
    var solicitud = await _logicaSolicitud.GetByIdAsync(id);
         if (solicitud == null)
      return NotFound();
   
     await CargarListasAsync();
   return View(solicitud);
 }

        [HttpPost]
  public async Task<IActionResult> Editar(Solicitud solicitud)
   {
     if (ModelState.IsValid)
   {
       await _logicaSolicitud.UpdateAsync(solicitud);
       return RedirectToAction("Index");
      }
   await CargarListasAsync();
   return View(solicitud);
}

 public async Task<IActionResult> Eliminar(int id)
    {
     await _logicaSolicitud.DeleteAsync(id);
  return RedirectToAction("Index");
 }

public async Task<IActionResult> Detalles(int id)
   {
    var solicitud = await _logicaSolicitud.GetByIdAsync(id);
       if (solicitud == null)
   return NotFound();

     ViewBag.MontoTotal = await _logicaSolicitud.CalcularMontoTotalAsync(id);
 return View(solicitud);
        }

        [HttpPost]
        public async Task<IActionResult> CambiarEstado(int id, string nuevoEstado)
  {
 await _logicaSolicitud.CambiarEstadoAsync(id, nuevoEstado);
     return RedirectToAction("Detalles", new { id });
   }

     private async Task CargarListasAsync()
  {
    ViewBag.Clientes = new SelectList(LogicaCliente.Listar(), "IdCliente", "Nombre");
        }
    }
}
