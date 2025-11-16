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

        // Perfil del cliente (para que los clientes editen sus propios datos)
        public IActionResult MiPerfil()
        {
            var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");
            if (string.IsNullOrEmpty(nombreUsuario))
            {
                return RedirectToAction("Login", "Auth");
            }

            var cliente = LogicaCliente.ObtenerPorNombreUsuario(nombreUsuario);
            if (cliente == null)
            {
                TempData["Error"] = "No se encontró el perfil del cliente.";
                return RedirectToAction("Index", "Home");
            }

            return View(cliente);
        }

        [HttpPost]
        public IActionResult MiPerfil(Cliente cliente)
        {
            var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");
            if (string.IsNullOrEmpty(nombreUsuario))
            {
                return RedirectToAction("Login", "Auth");
            }

            // Validar que el cliente está editando su propio perfil
            var clienteActual = LogicaCliente.ObtenerPorNombreUsuario(nombreUsuario);
            if (clienteActual == null || clienteActual.IdCliente != cliente.IdCliente)
            {
                TempData["Error"] = "No tiene permisos para editar este perfil.";
                return RedirectToAction("MiPerfil");
            }

            try
            {
                // Mantener el nombre de usuario original
                cliente.NombreUsuario = clienteActual.NombreUsuario;
                
                LogicaCliente.Editar(cliente);
                TempData["Success"] = "Su perfil ha sido actualizado correctamente.";
                return RedirectToAction("MiPerfil");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al actualizar el perfil: {ex.Message}";
                return View(cliente);
            }
        }
    }
}
