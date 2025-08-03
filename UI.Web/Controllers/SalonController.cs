using Microsoft.AspNetCore.Mvc;
using Entidades;
using Negocio;

namespace UI.Web.Controllers
{
    public class SalonController : Controller
    {
        public IActionResult Index() => View(LogicaSalon.Listar());

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