using Microsoft.AspNetCore.Mvc;

namespace UI.Web.Controllers
{
    public class DiagnosticoController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DiagnosticoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient Client => _httpClientFactory.CreateClient("API");

        public async Task<IActionResult> Sesion()
        {
            var diagnostico = new Dictionary<string, string>();

            // Verificar todas las claves de sesión
            diagnostico["Sesión Activa"] = HttpContext.Session.Id ?? "NO HAY SESIÓN";
            
            try
            {
                diagnostico["NombreUsuario"] = HttpContext.Session.GetString("NombreUsuario") ?? "NO EXISTE";
                diagnostico["UsuarioId"] = HttpContext.Session.GetString("UsuarioId") ?? "NO EXISTE";
                diagnostico["IdCliente"] = HttpContext.Session.GetString("IdCliente") ?? "NO EXISTE";
                diagnostico["Rol"] = HttpContext.Session.GetString("Rol") ?? "NO EXISTE";
                diagnostico["NombreCompleto"] = HttpContext.Session.GetString("NombreCompleto") ?? "NO EXISTE";
            }
            catch (Exception ex)
            {
                diagnostico["Error al leer sesión"] = ex.Message;
            }

            // Intentar obtener cliente del API
            var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");
            if (!string.IsNullOrEmpty(nombreUsuario))
            {
                try
                {
                    var response = await Client.GetAsync($"Cliente/usuario/{nombreUsuario}");
                    diagnostico["API Cliente Status"] = response.StatusCode.ToString();
                    
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        diagnostico["API Cliente Response"] = content;
                    }
                    else
                    {
                        diagnostico["API Cliente Error"] = await response.Content.ReadAsStringAsync();
                    }
                }
                catch (Exception ex)
                {
                    diagnostico["API Cliente Exception"] = ex.Message;
                }
            }

            ViewBag.Diagnostico = diagnostico;
            return View();
        }
    }
}
