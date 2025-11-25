using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace UI.Web.Controllers
{
    public class EstadisticasController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonOptions;

        public EstadisticasController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        private HttpClient Client => _httpClientFactory.CreateClient("API");

        public async Task<IActionResult> Index()
        {
            var response = await Client.GetAsync("Estadisticas");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var stats = JsonSerializer.Deserialize<StatsDto>(content, _jsonOptions);
                
                ViewBag.TotalClientes = stats.TotalClientes;
                ViewBag.TotalZonas = stats.TotalZonas;
                ViewBag.TotalSalones = stats.TotalSalones;
                ViewBag.TotalDjs = stats.TotalDjs;
                ViewBag.TotalBarras = stats.TotalBarras;
                ViewBag.TotalComidas = stats.TotalComidas;
            }
            return View();
        }
    }

    public class StatsDto
    {
        public int TotalClientes { get; set; }
        public int TotalZonas { get; set; }
        public int TotalSalones { get; set; }
        public int TotalDjs { get; set; }
        public int TotalBarras { get; set; }
        public int TotalComidas { get; set; }
    }
}
