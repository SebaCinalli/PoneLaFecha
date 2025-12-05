using Microsoft.AspNetCore.Mvc;
using Entidades;
using System.Text.Json;
using System.Text;

namespace UI.Web.Controllers
{
    public class GastronomicoController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonOptions;

        public GastronomicoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        private HttpClient Client => _httpClientFactory.CreateClient("API");

        public async Task<IActionResult> Index()
        {
            var response = await Client.GetAsync("Gastronomico");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var comidas = JsonSerializer.Deserialize<List<Gastronomico>>(content, _jsonOptions);
                return View(comidas);
            }
            return View(new List<Gastronomico>());
        }

        public IActionResult Crear() => View();

        [HttpPost]
        public async Task<IActionResult> Crear(Gastronomico comida)
        {
            try
            {
                var json = JsonSerializer.Serialize(comida);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync("Gastronomico", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Gastronómico creado correctamente.";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Error al crear el gastronómico.";
                return View(comida);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
                return View(comida);
            }
        }

        public async Task<IActionResult> Editar(int id)
        {
            var response = await Client.GetAsync($"Gastronomico/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var comida = JsonSerializer.Deserialize<Gastronomico>(content, _jsonOptions);
                return View(comida);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Gastronomico comida)
        {
            try
            {
                var json = JsonSerializer.Serialize(comida);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync($"Gastronomico/{comida.IdGastro}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Gastronómico modificado correctamente.";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Error al modificar el gastronómico.";
                return View(comida);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
                return View(comida);
            }
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var response = await Client.DeleteAsync($"Gastronomico/{id}");
                if (response.IsSuccessStatusCode)
                    TempData["Success"] = "Gastronómico eliminado correctamente.";
                else
                    TempData["Error"] = "Error al eliminar el gastronómico.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
            }
            return RedirectToAction("Index");
        }
    }
}
