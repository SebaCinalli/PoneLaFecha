using Microsoft.AspNetCore.Mvc;
using Entidades;
using Negocio;

namespace UI.Web.Controllers
{
    public class BarraController : Controller
    {
        public IActionResult Index(decimal? precioMin, decimal? precioMax)
        {
            var barras = LogicaBarra.Listar();
            
            // Aplicar filtros de precio
            if (precioMin.HasValue)
            {
                barras = barras.Where(b => b.PrecioPorHora >= precioMin.Value).ToList();
            }
            
            if (precioMax.HasValue)
            {
                barras = barras.Where(b => b.PrecioPorHora <= precioMax.Value).ToList();
            }
            
            ViewBag.PrecioMin = precioMin;
            ViewBag.PrecioMax = precioMax;
            
            return View(barras);
        }

        public IActionResult Crear() => View();

        [HttpPost]
        public IActionResult Crear(Barra b)
        {
            LogicaBarra.Crear(b);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var barra = LogicaBarra.Obtener(id);
            return barra == null ? NotFound() : View(barra);
        }

        [HttpPost]
        public IActionResult Editar(Barra b)
        {
            LogicaBarra.Editar(b);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            LogicaBarra.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}