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
        private readonly ILogger<AuthController> _logger;

        public AuthController(IHttpClientFactory httpClientFactory, ILogger<AuthController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        private HttpClient Client => _httpClientFactory.CreateClient("API");

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string nombreUsuario, string password)
        {
            try
            {
                _logger.LogInformation("Intento de login para: {Usuario}", nombreUsuario);
                
                var loginRequest = new { Username = nombreUsuario, Password = password };
                var json = JsonSerializer.Serialize(loginRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await Client.PostAsync("Auth/login", content);
                
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    _logger.LogInformation("Respuesta del login: {Response}", responseContent);
                    
                    // La API devuelve { usuario: Usuario } o { usuario: Cliente }
                    var loginResponse = JsonSerializer.Deserialize<JsonElement>(responseContent, _jsonOptions);
                    
                    if (loginResponse.TryGetProperty("usuario", out var usuarioElement))
                    {
                        // Intentar como Usuario primero (tiene IdUsuario)
                        if (usuarioElement.TryGetProperty("idUsuario", out var _))
                        {
                            var usuario = JsonSerializer.Deserialize<Usuario>(usuarioElement.GetRawText(), _jsonOptions);
                            if (usuario != null)
                            {
                                HttpContext.Session.SetString("UsuarioId", usuario.IdUsuario.ToString());
                                HttpContext.Session.SetString("NombreUsuario", usuario.NombreUsuario);
                                HttpContext.Session.SetString("Rol", usuario.Rol);
                                HttpContext.Session.SetString("NombreCompleto", $"{usuario.Nombre} {usuario.Apellido}");
                                
                                // Si es un cliente, intentar obtener su IdCliente de la tabla Clientes
                                if (usuario.Rol == "Cliente")
                                {
                                    try
                                    {
                                        var clienteResponse = await Client.GetAsync($"Cliente/usuario/{usuario.NombreUsuario}");
                                        if (clienteResponse.IsSuccessStatusCode)
                                        {
                                            var clienteContent = await clienteResponse.Content.ReadAsStringAsync();
                                            var cliente = JsonSerializer.Deserialize<Cliente>(clienteContent, _jsonOptions);
                                            if (cliente != null)
                                            {
                                                HttpContext.Session.SetString("IdCliente", cliente.IdCliente.ToString());
                                                _logger.LogInformation("IdCliente establecido: {IdCliente}", cliente.IdCliente);
                                            }
                                        }
                                        else
                                        {
                                            _logger.LogWarning("No se pudo obtener IdCliente para: {Usuario}", nombreUsuario);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        _logger.LogWarning(ex, "Error al obtener IdCliente, continuando sin él");
                                    }
                                }
                                
                                _logger.LogInformation("Login exitoso para Usuario: {Usuario} con rol {Rol}", nombreUsuario, usuario.Rol);
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        // Si no, intentar como Cliente (tiene IdCliente)
                        else if (usuarioElement.TryGetProperty("idCliente", out var _))
                        {
                            var cliente = JsonSerializer.Deserialize<Cliente>(usuarioElement.GetRawText(), _jsonOptions);
                            if (cliente != null)
                            {
                                HttpContext.Session.SetString("UsuarioId", cliente.IdCliente.ToString());
                                HttpContext.Session.SetString("IdCliente", cliente.IdCliente.ToString());
                                HttpContext.Session.SetString("NombreUsuario", cliente.NombreUsuario);
                                HttpContext.Session.SetString("Rol", cliente.Rol);
                                HttpContext.Session.SetString("NombreCompleto", $"{cliente.Nombre} {cliente.Apellido}");
                                
                                _logger.LogInformation("Login exitoso para Cliente: {Usuario} con rol {Rol}", nombreUsuario, cliente.Rol);
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                }
                
                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogWarning("Login fallido para {Usuario}: {Error}", nombreUsuario, errorContent);
                ViewBag.Error = "Usuario o contraseña incorrectos";
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar login para: {Usuario}", nombreUsuario);
                ViewBag.Error = $"Error al conectar con el servidor: {ex.Message}";
                return View();
            }
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(string nombre, string apellido, string email, string telefono, string nombreUsuario, string password, string confirmPassword)
        {
            try
            {
                _logger.LogInformation("Intento de registro para: {Usuario}", nombreUsuario);
                
                // Validaciones del lado del cliente
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    ViewBag.Error = "El nombre es requerido";
                    return View();
                }

                if (string.IsNullOrWhiteSpace(apellido))
                {
                    ViewBag.Error = "El apellido es requerido";
                    return View();
                }

                if (string.IsNullOrWhiteSpace(email))
                {
                    ViewBag.Error = "El email es requerido";
                    return View();
                }

                if (string.IsNullOrWhiteSpace(telefono))
                {
                    ViewBag.Error = "El teléfono es requerido";
                    return View();
                }

                if (string.IsNullOrWhiteSpace(nombreUsuario))
                {
                    ViewBag.Error = "El nombre de usuario es requerido";
                    return View();
                }

                if (nombreUsuario.Length < 3)
                {
                    ViewBag.Error = "El nombre de usuario debe tener al menos 3 caracteres";
                    return View();
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    ViewBag.Error = "La contraseña es requerida";
                    return View();
                }

                if (password.Length < 6)
                {
                    ViewBag.Error = "La contraseña debe tener al menos 6 caracteres";
                    return View();
                }

                if (password != confirmPassword)
                {
                    ViewBag.Error = "Las contraseñas no coinciden";
                    return View();
                }

                var usuario = new Cliente
                {
                    Nombre = nombre.Trim(),
                    Apellido = apellido.Trim(),
                    Email = email.Trim(),
                    Telefono = telefono.Trim(),
                    NombreUsuario = nombreUsuario.Trim(),
                    Clave = password,
                    Rol = "Cliente"
                };

                var json = JsonSerializer.Serialize(usuario);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                _logger.LogInformation("Enviando solicitud de registro para: {Usuario}", nombreUsuario);
                var response = await Client.PostAsync("Auth/register", content);
                
                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Usuario registrado exitosamente: {Usuario}", nombreUsuario);
                    ViewBag.Success = "Usuario registrado exitosamente. Por favor inicie sesión.";
                    return View("Login");
                }
                
                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogWarning("Registro fallido para {Usuario}: {StatusCode} - {Error}", 
                    nombreUsuario, response.StatusCode, errorContent);
                
                // Intentar deserializar el error como JSON
                try
                {
                    var errorObj = JsonSerializer.Deserialize<JsonElement>(errorContent, _jsonOptions);
                    
                    if (errorObj.TryGetProperty("mensaje", out var mensaje))
                    {
                        ViewBag.Error = mensaje.GetString();
                        
                        if (errorObj.TryGetProperty("errores", out var errores))
                        {
                            var listaErrores = errores.EnumerateArray()
                                .Select(e => e.GetString())
                                .Where(e => !string.IsNullOrEmpty(e));
                            ViewBag.Error = string.Join(". ", listaErrores);
                        }
                    }
                    else
                    {
                        ViewBag.Error = errorContent;
                    }
                }
                catch
                {
                    // Si no es JSON, usar el contenido directo
                    ViewBag.Error = errorContent.Replace("\"", "");
                }
                
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar usuario: {Usuario}", nombreUsuario);
                ViewBag.Error = $"Error al conectar con el servidor: {ex.Message}";
                return View();
            }
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
