using Microsoft.AspNetCore.Mvc;
using Entidades;
using Negocio;

namespace UI.Web.Controllers
{
    public class GastronomicoController : Controller
    {
        public IActionResult Index(decimal? precioMin, decimal? precioMax)
        {
            var gastronomicos = LogicaGastronomico.Listar();
            
            // Aplicar filtros de precio
            if (precioMin.HasValue)
            {
                gastronomicos = gastronomicos.Where(g => g.MontoG >= precioMin.Value).ToList();
            }
            
            if (precioMax.HasValue)
            {
                gastronomicos = gastronomicos.Where(g => g.MontoG <= precioMax.Value).ToList();
            }
            
            ViewBag.PrecioMin = precioMin;
            ViewBag.PrecioMax = precioMax;
            
            return View(gastronomicos);
        }

        public IActionResult Crear() => View();

        [HttpPost]
        public IActionResult Crear(Gastronomico g)
        {
            if (!ModelState.IsValid)
            {
                return View(g);
            }
            
            LogicaGastronomico.Crear(g);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var gastronomico = LogicaGastronomico.Obtener(id);
            return gastronomico == null ? NotFound() : View(gastronomico);
        }

        [HttpPost]
        public IActionResult Editar(Gastronomico g)
        {
            if (!ModelState.IsValid)
            {
                return View(g);
            }
            
            LogicaGastronomico.Editar(g);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            LogicaGastronomico.Eliminar(id);
            return RedirectToAction("Index");
        }

        public IActionResult Detalle(int id)
        {
            var gastronomico = LogicaGastronomico.Obtener(id);
            return gastronomico == null ? NotFound() : View(gastronomico);
        }
    }
}