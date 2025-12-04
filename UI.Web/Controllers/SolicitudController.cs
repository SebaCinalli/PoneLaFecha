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

        public SolicitudController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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
            try
            {
                // Obtener listas de servicios disponibles
                var salonesResponse = await Client.GetAsync("Salon");
                var barrasResponse = await Client.GetAsync("Barra");
                var gastroResponse = await Client.GetAsync("Gastronomico");
                var djsResponse = await Client.GetAsync("Dj");

                if (salonesResponse.IsSuccessStatusCode)
                {
                    var salonesContent = await salonesResponse.Content.ReadAsStringAsync();
                    ViewBag.Salones = JsonSerializer.Deserialize<List<Salon>>(salonesContent, _jsonOptions);
                }

                if (barrasResponse.IsSuccessStatusCode)
                {
                    var barrasContent = await barrasResponse.Content.ReadAsStringAsync();
                    ViewBag.Barras = JsonSerializer.Deserialize<List<Barra>>(barrasContent, _jsonOptions);
                }

                if (gastroResponse.IsSuccessStatusCode)
                {
                    var gastroContent = await gastroResponse.Content.ReadAsStringAsync();
                    ViewBag.Gastronomicos = JsonSerializer.Deserialize<List<Gastronomico>>(gastroContent, _jsonOptions);
                }

                if (djsResponse.IsSuccessStatusCode)
                {
                    var djsContent = await djsResponse.Content.ReadAsStringAsync();
                    ViewBag.Djs = JsonSerializer.Deserialize<List<Dj>>(djsContent, _jsonOptions);
                }

                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al cargar los datos: {ex.Message}";
                return RedirectToAction("Index");
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
                // Obtener el IdCliente de la sesión
                var idClienteStr = HttpContext.Session.GetString("IdCliente");
                if (string.IsNullOrEmpty(idClienteStr))
                {
                    TempData["Error"] = "Debe iniciar sesión para crear una solicitud.";
                    return RedirectToAction("Login", "Auth");
                }

                solicitud.IdCliente = int.Parse(idClienteStr);
                solicitud.Estado = "Pendiente";

                // Crear DTO para enviar a la API
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
                    return RedirectToAction("Index", "Cliente");
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    TempData["Error"] = $"Error al crear la solicitud: {errorContent}";
                    return await ReloadCrearView(solicitud);
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
                return await ReloadCrearView(solicitud);
            }
        }

        private async Task<IActionResult> ReloadCrearView(Solicitud solicitud)
        {
            // Recargar los datos para la vista
            var salonesResponse = await Client.GetAsync("Salon");
            var barrasResponse = await Client.GetAsync("Barra");
            var gastroResponse = await Client.GetAsync("Gastronomico");
            var djsResponse = await Client.GetAsync("Dj");

            if (salonesResponse.IsSuccessStatusCode)
            {
                var salonesContent = await salonesResponse.Content.ReadAsStringAsync();
                ViewBag.Salones = JsonSerializer.Deserialize<List<Salon>>(salonesContent, _jsonOptions);
            }

            if (barrasResponse.IsSuccessStatusCode)
            {
                var barrasContent = await barrasResponse.Content.ReadAsStringAsync();
                ViewBag.Barras = JsonSerializer.Deserialize<List<Barra>>(barrasContent, _jsonOptions);
            }

            if (gastroResponse.IsSuccessStatusCode)
            {
                var gastroContent = await gastroResponse.Content.ReadAsStringAsync();
                ViewBag.Gastronomicos = JsonSerializer.Deserialize<List<Gastronomico>>(gastroContent, _jsonOptions);
            }

            if (djsResponse.IsSuccessStatusCode)
            {
                var djsContent = await djsResponse.Content.ReadAsStringAsync();
                ViewBag.Djs = JsonSerializer.Deserialize<List<Dj>>(djsContent, _jsonOptions);
            }

            return View("Crear", solicitud);
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
