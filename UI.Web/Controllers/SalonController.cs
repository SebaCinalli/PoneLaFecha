using Microsoft.AspNetCore.Mvc;
using Entidades;
using Negocio;

namespace UI.Web.Controllers
{
    public class SalonController : Controller
    {
        public IActionResult Index(decimal? precioMin, decimal? precioMax)
        {
            var salones = LogicaSalon.Listar();
            
            // Aplicar filtros de precio
            if (precioMin.HasValue)
            {
                salones = salones.Where(s => s.MontoSalon >= precioMin.Value).ToList();
            }
            
            if (precioMax.HasValue)
            {
                salones = salones.Where(s => s.MontoSalon <= precioMax.Value).ToList();
            }
            
            ViewBag.PrecioMin = precioMin;
            ViewBag.PrecioMax = precioMax;
            
            return View(salones);
        }

        public IActionResult Crear() => View();

        [HttpPost]
        public IActionResult Crear(Salon s)
        {
            LogicaSalon.Crear(s);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var salon = LogicaSalon.Obtener(id);
            return salon == null ? NotFound() : View(salon);
        }

        [HttpPost]
        public IActionResult Editar(Salon s)
        {
            LogicaSalon.Editar(s);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            LogicaSalon.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}