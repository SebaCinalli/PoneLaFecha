using Microsoft.AspNetCore.Mvc;
using Entidades;
using System.Text.Json;
using System.Text;

namespace UI.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonOptions;

        public ClienteController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        private HttpClient Client => _httpClientFactory.CreateClient("API");

        public async Task<IActionResult> Index()
        {
            var response = await Client.GetAsync("Cliente");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var clientes = JsonSerializer.Deserialize<List<Cliente>>(content, _jsonOptions);
                return View(clientes);
            }
            return View(new List<Cliente>());
        }

        public IActionResult Crear() => View();

        [HttpPost]
        public async Task<IActionResult> Crear(Cliente c)
        {
            try
            {
                var json = JsonSerializer.Serialize(c);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync("Cliente", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Cliente creado correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = $"Error al crear el cliente: {response.ReasonPhrase}";
                    return View(c);
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al crear el cliente: {ex.Message}";
                return View(c);
            }
        }

        public async Task<IActionResult> Editar(int id)
        {
            var response = await Client.GetAsync($"Cliente/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var cliente = JsonSerializer.Deserialize<Cliente>(content, _jsonOptions);
                return View(cliente);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Cliente c)
        {
            try
            {
                var json = JsonSerializer.Serialize(c);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync($"Cliente/{c.IdCliente}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Cliente modificado correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = $"Error al modificar el cliente: {response.ReasonPhrase}";
                    return View(c);
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al modificar el cliente: {ex.Message}";
                return View(c);
            }
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var response = await Client.DeleteAsync($"Cliente/{id}");
                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Cliente eliminado correctamente.";
                }
                else
                {
                    TempData["Error"] = "No se puede eliminar este cliente porque tiene solicitudes asociadas. Por favor, elimine primero las solicitudes relacionadas.";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al eliminar: {ex.Message}";
            }
            return RedirectToAction("Index");
        }

        // Perfil del cliente (para que los clientes editen sus propios datos)
        public async Task<IActionResult> MiPerfil()
        {
            var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");
            if (string.IsNullOrEmpty(nombreUsuario))
            {
                return RedirectToAction("Login", "Auth");
            }

            var response = await Client.GetAsync($"Cliente/usuario/{nombreUsuario}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var cliente = JsonSerializer.Deserialize<Cliente>(content, _jsonOptions);
                return View(cliente);
            }
            
            TempData["Error"] = "No se encontró el perfil del cliente.";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> MiPerfil(Cliente cliente)
        {
            var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");
            if (string.IsNullOrEmpty(nombreUsuario))
            {
                return RedirectToAction("Login", "Auth");
            }

            // Validar que el cliente está editando su propio perfil
            var response = await Client.GetAsync($"Cliente/usuario/{nombreUsuario}");
            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "Error al validar el perfil.";
                return RedirectToAction("MiPerfil");
            }
            
            var content = await response.Content.ReadAsStringAsync();
            var clienteActual = JsonSerializer.Deserialize<Cliente>(content, _jsonOptions);

            if (clienteActual == null || clienteActual.IdCliente != cliente.IdCliente)
            {
                TempData["Error"] = "No tiene permisos para editar este perfil.";
                return RedirectToAction("MiPerfil");
            }

            try
            {
                // Mantener el nombre de usuario original
                cliente.NombreUsuario = clienteActual.NombreUsuario;
                
                var json = JsonSerializer.Serialize(cliente);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var putResponse = await Client.PutAsync($"Cliente/{cliente.IdCliente}", httpContent);

                if (putResponse.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Su perfil ha sido actualizado correctamente.";
                    return RedirectToAction("MiPerfil");
                }
                else
                {
                    TempData["Error"] = $"Error al actualizar el perfil: {putResponse.ReasonPhrase}";
                    return View(cliente);
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al actualizar el perfil: {ex.Message}";
                return View(cliente);
            }
        }

        // Ver solicitudes del cliente logueado
        public async Task<IActionResult> MisSolicitudes()
        {
            var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");
            if (string.IsNullOrEmpty(nombreUsuario))
            {
                return RedirectToAction("Login", "Auth");
            }

            try
            {
                // Obtener el cliente actual
                var clienteResponse = await Client.GetAsync($"Cliente/usuario/{nombreUsuario}");
                if (!clienteResponse.IsSuccessStatusCode)
                {
                    TempData["Error"] = "No se pudo obtener su perfil de cliente.";
                    return RedirectToAction("Index", "Home");
                }

                var clienteContent = await clienteResponse.Content.ReadAsStringAsync();
                var cliente = JsonSerializer.Deserialize<Cliente>(clienteContent, _jsonOptions);

                if (cliente == null)
                {
                    TempData["Error"] = "No se pudo obtener su perfil de cliente.";
                    return RedirectToAction("Index", "Home");
                }

                // Obtener las solicitudes del cliente
                var solicitudesResponse = await Client.GetAsync($"Solicitud/cliente/{cliente.IdCliente}");
                if (solicitudesResponse.IsSuccessStatusCode)
                {
                    var solicitudesContent = await solicitudesResponse.Content.ReadAsStringAsync();
                    var solicitudes = JsonSerializer.Deserialize<List<Solicitud>>(solicitudesContent, _jsonOptions);
                    return View(solicitudes ?? new List<Solicitud>());
                }
                else
                {
                    TempData["Error"] = "No se pudieron cargar las solicitudes.";
                    return View(new List<Solicitud>());
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al cargar las solicitudes: {ex.Message}";
                return View(new List<Solicitud>());
            }
        }
    }
}
