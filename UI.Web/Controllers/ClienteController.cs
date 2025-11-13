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
            try
            {
                LogicaCliente.Crear(c);
                TempData["Success"] = "Cliente creado correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al crear el cliente: {ex.Message}";
                return View(c);
            }
        }

        public IActionResult Editar(int id)
        {
            var cliente = LogicaCliente.Obtener(id);
            return cliente == null ? NotFound() : View(cliente);
        }

        [HttpPost]
        public IActionResult Editar(Cliente c)
        {
            try
            {
                LogicaCliente.Editar(c);
                TempData["Success"] = "Cliente modificado correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al modificar el cliente: {ex.Message}";
                return View(c);
            }
        }

        public IActionResult Eliminar(int id)
        {
            try
            {
                LogicaCliente.Eliminar(id);
                TempData["Success"] = "Cliente eliminado correctamente.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "No se puede eliminar este cliente porque tiene solicitudes asociadas. Por favor, elimine primero las solicitudes relacionadas.";
            }
            return RedirectToAction("Index");
        }
    }
}
