using Microsoft.AspNetCore.Mvc;
using Entidades;
using Negocio;

namespace UI.Web.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index() => View(LogicaCliente.Listar());

        public IActionResult Crear() => View();

        [HttpPost]
        public IActionResult Crear(Cliente c)
        {
            LogicaCliente.Crear(c);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var cliente = LogicaCliente.Obtener(id);
            return cliente == null ? NotFound() : View(cliente);
        }

        [HttpPost]
        public IActionResult Editar(Cliente c)
        {
            LogicaCliente.Editar(c);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            LogicaCliente.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
