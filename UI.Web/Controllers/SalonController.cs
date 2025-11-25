using Microsoft.AspNetCore.Mvc;
using Entidades;
using System.Text.Json;
using System.Text;

namespace UI.Web.Controllers
{
    public class SalonController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonOptions;

        public SalonController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        private HttpClient Client => _httpClientFactory.CreateClient("API");

        public async Task<IActionResult> Index()
        {
            var response = await Client.GetAsync("Salon");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var salones = JsonSerializer.Deserialize<List<Salon>>(content, _jsonOptions);
                return View(salones);
            }
            return View(new List<Salon>());
        }

        public IActionResult Crear() => View();

        [HttpPost]
        public async Task<IActionResult> Crear(Salon salon)
        {
            try
            {
                var json = JsonSerializer.Serialize(salon);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync("Salon", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Salón creado correctamente.";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Error al crear el salón.";
                return View(salon);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
                return View(salon);
            }
        }

        public async Task<IActionResult> Editar(int id)
        {
            var response = await Client.GetAsync($"Salon/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var salon = JsonSerializer.Deserialize<Salon>(content, _jsonOptions);
                return View(salon);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Salon salon)
        {
            try
            {
                var json = JsonSerializer.Serialize(salon);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync($"Salon/{salon.IdSalon}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Salón modificado correctamente.";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Error al modificar el salón.";
                return View(salon);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
                return View(salon);
            }
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var response = await Client.DeleteAsync($"Salon/{id}");
                if (response.IsSuccessStatusCode)
                    TempData["Success"] = "Salón eliminado correctamente.";
                else
                    TempData["Error"] = "Error al eliminar el salón.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
            }
            return RedirectToAction("Index");
        }
    }
}
