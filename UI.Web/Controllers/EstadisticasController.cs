using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Entidades;

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
            try
            {
                var response = await Client.GetAsync("Estadisticas");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var stats = JsonSerializer.Deserialize<StatsDto>(content, _jsonOptions);
                    
                    if (stats != null)
                    {
                        ViewBag.TotalClientes = stats.TotalClientes;
                        ViewBag.TotalZonas = stats.TotalZonas;
                        ViewBag.TotalSalones = stats.TotalSalones;
                        ViewBag.TotalDjs = stats.TotalDjs;
                        ViewBag.TotalBarras = stats.TotalBarras;
                        ViewBag.TotalComidas = stats.TotalComidas;
                        ViewBag.TotalGastronomicos = stats.TotalGastronomicos;
                        ViewBag.Salones = stats.Salones;
                        ViewBag.Barras = stats.Barras;
                        ViewBag.Djs = stats.Djs;
                        ViewBag.Gastronomicos = stats.Gastronomicos;
                    }
                }
                else
                {
                    ViewBag.Error = "No se pudieron obtener las estadísticas del servidor.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error al obtener estadísticas: {ex.Message}";
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
        public int TotalGastronomicos { get; set; }
        public List<Salon>? Salones { get; set; }
        public List<Barra>? Barras { get; set; }
        public List<Dj>? Djs { get; set; }
        public List<Gastronomico>? Gastronomicos { get; set; }
    }
}
