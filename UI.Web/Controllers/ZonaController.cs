using Microsoft.AspNetCore.Mvc;
using Entidades;
using Negocio;

namespace UI.Web.Controllers
{
    public class ZonaController : Controller
    {
  private readonly LogicaZona _logicaZona;

        public ZonaController()
        {
            _logicaZona = new LogicaZona();
  }

   public async Task<IActionResult> Index()
        {
  var zonas = await _logicaZona.GetAllAsync();
            return View(zonas);
  }

 public IActionResult Crear() => View();

        [HttpPost]
        public async Task<IActionResult> Crear(Zona zona)
   {
       if (ModelState.IsValid)
            {
        await _logicaZona.CreateAsync(zona);
  return RedirectToAction("Index");
    }
    return View(zona);
 }

  public async Task<IActionResult> Editar(int id)
   {
       var zona = await _logicaZona.GetByIdAsync(id);
    return zona == null ? NotFound() : View(zona);
        }

 [HttpPost]
public async Task<IActionResult> Editar(Zona zona)
   {
            if (ModelState.IsValid)
            {
       await _logicaZona.UpdateAsync(zona);
          return RedirectToAction("Index");
   }
   return View(zona);
        }

      public async Task<IActionResult> Eliminar(int id)
        {
            await _logicaZona.DeleteAsync(id);
            return RedirectToAction("Index");
   }

   public async Task<IActionResult> Detalles(int id)
  {
 var zona = await _logicaZona.GetByIdAsync(id);
            if (zona == null)
     return NotFound();

     ViewBag.Salones = await _logicaZona.GetSalonesPorZonaAsync(id);
            ViewBag.Barras = await _logicaZona.GetBarrasPorZonaAsync(id);
  ViewBag.Gastronomicos = await _logicaZona.GetGastronomicosPorZonaAsync(id);
            ViewBag.Djs = await _logicaZona.GetDjsPorZonaAsync(id);

      return View(zona);
 }
    }
}
