using Microsoft.AspNetCore.Mvc;
using Entidades;
using System.Text.Json;
using System.Text;

namespace UI.Web.Controllers
{
    public class DjController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonOptions;

        public DjController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        private HttpClient Client => _httpClientFactory.CreateClient("API");

        public async Task<IActionResult> Index()
        {
            var response = await Client.GetAsync("Dj");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var djs = JsonSerializer.Deserialize<List<Dj>>(content, _jsonOptions);
                return View(djs);
            }
            return View(new List<Dj>());
        }

        public IActionResult Crear() => View();

        [HttpPost]
        public async Task<IActionResult> Crear(Dj dj)
        {
            try
            {
                var json = JsonSerializer.Serialize(dj);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync("Dj", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "DJ creado correctamente.";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Error al crear el DJ.";
                return View(dj);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
                return View(dj);
            }
        }

        public async Task<IActionResult> Editar(int id)
        {
            var response = await Client.GetAsync($"Dj/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var dj = JsonSerializer.Deserialize<Dj>(content, _jsonOptions);
                return View(dj);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Dj dj)
        {
            try
            {
                var json = JsonSerializer.Serialize(dj);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync($"Dj/{dj.IdDj}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "DJ modificado correctamente.";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Error al modificar el DJ.";
                return View(dj);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
                return View(dj);
            }
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var response = await Client.DeleteAsync($"Dj/{id}");
                if (response.IsSuccessStatusCode)
                    TempData["Success"] = "DJ eliminado correctamente.";
                else
                    TempData["Error"] = "Error al eliminar el DJ.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
            }
            return RedirectToAction("Index");
        }
    }
}
