using Microsoft.AspNetCore.Mvc;
using Entidades;
using System.Text.Json;
using System.Text;

namespace UI.Web.Controllers
{
    public class ZonaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonOptions;

        public ZonaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        private HttpClient Client => _httpClientFactory.CreateClient("API");

        public async Task<IActionResult> Index()
        {
            var response = await Client.GetAsync("Zona");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var zonas = JsonSerializer.Deserialize<List<Zona>>(content, _jsonOptions);
                return View(zonas);
            }
            return View(new List<Zona>());
        }

        public IActionResult Crear() => View();

        [HttpPost]
        public async Task<IActionResult> Crear(Zona zona)
        {
            try
            {
                var json = JsonSerializer.Serialize(zona);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync("Zona", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Zona creada correctamente.";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Error al crear la zona.";
                return View(zona);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
                return View(zona);
            }
        }

        public async Task<IActionResult> Editar(int id)
        {
            var response = await Client.GetAsync($"Zona/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var zona = JsonSerializer.Deserialize<Zona>(content, _jsonOptions);
                return View(zona);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Zona zona)
        {
            try
            {
                var json = JsonSerializer.Serialize(zona);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync($"Zona/{zona.IdZona}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Zona modificada correctamente.";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Error al modificar la zona.";
                return View(zona);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
                return View(zona);
            }
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var response = await Client.DeleteAsync($"Zona/{id}");
                if (response.IsSuccessStatusCode)
                    TempData["Success"] = "Zona eliminada correctamente.";
                else
                    TempData["Error"] = "Error al eliminar la zona.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
            }
            return RedirectToAction("Index");
        }
    }
}
