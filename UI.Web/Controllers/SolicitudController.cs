using Microsoft.AspNetCore.Mvc;
using Entidades;
using System.Text.Json;
using System.Text;

namespace UI.Web.Controllers
{
    public class SolicitudController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly ILogger<SolicitudController> _logger;

        public SolicitudController(IHttpClientFactory httpClientFactory, ILogger<SolicitudController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        private HttpClient Client => _httpClientFactory.CreateClient("API");

        public async Task<IActionResult> Index()
        {
            var response = await Client.GetAsync("Solicitud");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var solicitudes = JsonSerializer.Deserialize<List<Solicitud>>(content, _jsonOptions);
                return View(solicitudes);
            }
            return View(new List<Solicitud>());
        }

        public async Task<IActionResult> Crear()
        {
            // Verificar que el usuario esté logueado
            var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");
            if (string.IsNullOrEmpty(nombreUsuario))
            {
                TempData["Error"] = "Debe iniciar sesión para crear una solicitud.";
                return RedirectToAction("Login", "Auth");
            }

            try
            {
                // Obtener listas de servicios disponibles
                var salonesResponse = await Client.GetAsync("Salon");
                var barrasResponse = await Client.GetAsync("Barra");
                var gastroResponse = await Client.GetAsync("Gastronomico");
                var djsResponse = await Client.GetAsync("Dj");

                ViewBag.Salones = new List<Salon>();
                ViewBag.Barras = new List<Barra>();
                ViewBag.Gastronomicos = new List<Gastronomico>();
                ViewBag.Djs = new List<Dj>();

                if (salonesResponse.IsSuccessStatusCode)
                {
                    var salonesContent = await salonesResponse.Content.ReadAsStringAsync();
                    ViewBag.Salones = JsonSerializer.Deserialize<List<Salon>>(salonesContent, _jsonOptions) ?? new List<Salon>();
                }

                if (barrasResponse.IsSuccessStatusCode)
                {
                    var barrasContent = await barrasResponse.Content.ReadAsStringAsync();
                    ViewBag.Barras = JsonSerializer.Deserialize<List<Barra>>(barrasContent, _jsonOptions) ?? new List<Barra>();
                }

                if (gastroResponse.IsSuccessStatusCode)
                {
                    var gastroContent = await gastroResponse.Content.ReadAsStringAsync();
                    ViewBag.Gastronomicos = JsonSerializer.Deserialize<List<Gastronomico>>(gastroContent, _jsonOptions) ?? new List<Gastronomico>();
                }

                if (djsResponse.IsSuccessStatusCode)
                {
                    var djsContent = await djsResponse.Content.ReadAsStringAsync();
                    ViewBag.Djs = JsonSerializer.Deserialize<List<Dj>>(djsContent, _jsonOptions) ?? new List<Dj>();
                }

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar datos para crear solicitud");
                TempData["Error"] = $"Error al cargar los datos: {ex.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Solicitud solicitud, 
            List<int>? salonesSeleccionados,
            List<int>? barrasSeleccionadas,
            List<int>? gastrosSeleccionados,
            List<int>? djsSeleccionados)
        {
            try
            {
                // 1. Verificar sesión básica
                var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");
                if (string.IsNullOrEmpty(nombreUsuario))
                {
                    TempData["Error"] = "Su sesión ha expirado. Por favor, inicie sesión nuevamente.";
                    return RedirectToAction("Login", "Auth");
                }

                // 2. Obtener IdCliente
                int idCliente = 0;
                
                // 2.1 Intentar desde sesión
                var idClienteStr = HttpContext.Session.GetString("IdCliente");
                if (!string.IsNullOrEmpty(idClienteStr))
                {
                    if (int.TryParse(idClienteStr, out idCliente) && idCliente > 0)
                    {
                        // Tenemos el IdCliente, continuar
                    }
                    else
                    {
                        TempData["Error"] = $"El IdCliente en sesión no es válido: '{idClienteStr}'. <a href='/Diagnostico/Sesion'>Ver diagnóstico</a>";
                        return RedirectToAction("Index", "Home");
                    }
                }
                
                // 2.2 Si no está en sesión, obtener del API
                if (idCliente <= 0)
                {
                    try
                    {
                        var clienteResponse = await Client.GetAsync($"Cliente/usuario/{nombreUsuario}");
                        
                        if (!clienteResponse.IsSuccessStatusCode)
                        {
                            var errorMsg = await clienteResponse.Content.ReadAsStringAsync();
                            TempData["Error"] = $"No se pudo obtener su perfil de cliente. Status: {clienteResponse.StatusCode}. Error: {errorMsg}. <a href='/Diagnostico/Sesion'>Ver diagnóstico</a>";
                            return RedirectToAction("Index", "Home");
                        }
                        
                        var clienteContent = await clienteResponse.Content.ReadAsStringAsync();
                        var cliente = JsonSerializer.Deserialize<Cliente>(clienteContent, _jsonOptions);
                        
                        if (cliente == null)
                        {
                            TempData["Error"] = $"El cliente se deserializó como null. Respuesta: {clienteContent}. <a href='/Diagnostico/Sesion'>Ver diagnóstico</a>";
                            return RedirectToAction("Index", "Home");
                        }
                        
                        if (cliente.IdCliente <= 0)
                        {
                            TempData["Error"] = $"El cliente tiene IdCliente inválido: {cliente.IdCliente}. <a href='/Diagnostico/Sesion'>Ver diagnóstico</a>";
                            return RedirectToAction("Index", "Home");
                        }
                        
                        idCliente = cliente.IdCliente;
                        HttpContext.Session.SetString("IdCliente", idCliente.ToString());
                    }
                    catch (Exception ex)
                    {
                        TempData["Error"] = $"Excepción al obtener cliente del API: {ex.Message}. <a href='/Diagnostico/Sesion'>Ver diagnóstico</a>";
                        return RedirectToAction("Index", "Home");
                    }
                }

                // 3. Verificar que tenemos un IdCliente válido
                if (idCliente <= 0)
                {
                    TempData["Error"] = $"No se pudo determinar el IdCliente. Valor final: {idCliente}. <a href='/Diagnostico/Sesion'>Ver diagnóstico</a>";
                    return RedirectToAction("Logout", "Auth");
                }

                // 4. Crear la solicitud
                solicitud.IdCliente = idCliente;
                solicitud.Estado = "Pendiente";

                var solicitudDto = new
                {
                    solicitud.IdCliente,
                    solicitud.FechaDesde,
                    solicitud.Estado,
                    SalonesSeleccionados = salonesSeleccionados ?? new List<int>(),
                    BarrasSeleccionadas = barrasSeleccionadas ?? new List<int>(),
                    GastrosSeleccionados = gastrosSeleccionados ?? new List<int>(),
                    DjsSeleccionados = djsSeleccionados ?? new List<int>()
                };

                var json = JsonSerializer.Serialize(solicitudDto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync("Solicitud", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Solicitud creada correctamente. Estado: Pendiente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    TempData["Error"] = $"Error del servidor al crear solicitud (Status: {response.StatusCode}): {errorContent}";
                    return RedirectToAction("Crear");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error inesperado: {ex.Message}<br/>StackTrace: {ex.StackTrace}<br/><a href='/Diagnostico/Sesion'>Ver diagnóstico</a>";
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Pendientes()
        {
            var response = await Client.GetAsync("Solicitud/estado/Pendiente");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var solicitudes = JsonSerializer.Deserialize<List<Solicitud>>(content, _jsonOptions);
                return View("Index", solicitudes);
            }
            return View("Index", new List<Solicitud>());
        }

        [HttpPost]
        public async Task<IActionResult> Aprobar(int id)
        {
            var json = JsonSerializer.Serialize("Aprobada");
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync($"Solicitud/{id}/cambiar-estado", content);
            
            if (response.IsSuccessStatusCode)
                TempData["Success"] = "Solicitud aprobada.";
            else
                TempData["Error"] = "Error al aprobar la solicitud.";
                
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Rechazar(int id)
        {
            var json = JsonSerializer.Serialize("Rechazada");
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync($"Solicitud/{id}/cambiar-estado", content);
            
            if (response.IsSuccessStatusCode)
                TempData["Success"] = "Solicitud rechazada.";
            else
                TempData["Error"] = "Error al rechazar la solicitud.";
                
            return RedirectToAction("Index");
        }
    }
}
