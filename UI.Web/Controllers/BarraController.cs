using Microsoft.AspNetCore.Mvc;
using Entidades;
using System.Text.Json;
using System.Text;

namespace UI.Web.Controllers
{
    public class BarraController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonOptions;

        public BarraController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        private HttpClient Client => _httpClientFactory.CreateClient("API");

        public async Task<IActionResult> Index()
        {
            var response = await Client.GetAsync("Barra");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var barras = JsonSerializer.Deserialize<List<Barra>>(content, _jsonOptions);
                return View(barras);
            }
            return View(new List<Barra>());
        }

        public IActionResult Crear() => View();

        [HttpPost]
        public async Task<IActionResult> Crear(Barra barra)
        {
            try
            {
                var json = JsonSerializer.Serialize(barra);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync("Barra", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Barra creada correctamente.";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Error al crear la barra.";
                return View(barra);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
                return View(barra);
            }
        }

        public async Task<IActionResult> Editar(int id)
        {
            var response = await Client.GetAsync($"Barra/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var barra = JsonSerializer.Deserialize<Barra>(content, _jsonOptions);
                return View(barra);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Barra barra)
        {
            try
            {
                var json = JsonSerializer.Serialize(barra);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync($"Barra/{barra.IdBarra}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Barra modificada correctamente.";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Error al modificar la barra.";
                return View(barra);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
                return View(barra);
            }
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var response = await Client.DeleteAsync($"Barra/{id}");
                if (response.IsSuccessStatusCode)
                    TempData["Success"] = "Barra eliminada correctamente.";
                else
                    TempData["Error"] = "Error al eliminar la barra.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
            }
            return RedirectToAction("Index");
        }
    }
}
