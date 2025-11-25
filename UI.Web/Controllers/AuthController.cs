using Microsoft.AspNetCore.Mvc;
using Entidades;
using System.Text.Json;
using System.Text;

namespace UI.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonOptions;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        private HttpClient Client => _httpClientFactory.CreateClient("API");

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var loginRequest = new { Username = username, Password = password };
            var json = JsonSerializer.Serialize(loginRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await Client.PostAsync("Auth/login", content);
            
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var usuario = JsonSerializer.Deserialize<Cliente>(responseContent, _jsonOptions);
                
                HttpContext.Session.SetString("UsuarioId", usuario.IdCliente.ToString());
                HttpContext.Session.SetString("NombreUsuario", usuario.NombreUsuario);
                HttpContext.Session.SetString("Rol", usuario.Rol);
                HttpContext.Session.SetString("NombreCompleto", $"{usuario.Nombre} {usuario.Apellido}");
                
                return RedirectToAction("Index", "Home");
            }
            
            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View();
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(string nombre, string apellido, string email, string username, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ViewBag.Error = "Las contraseñas no coinciden";
                return View();
            }

            var usuario = new Cliente
            {
                Nombre = nombre,
                Apellido = apellido,
                Email = email,
                NombreUsuario = username,
                Clave = password,
                Rol = "Cliente"
            };

            var json = JsonSerializer.Serialize(usuario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await Client.PostAsync("Auth/register", content);
            
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }
            
            ViewBag.Error = "Error al registrar el usuario";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
