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
