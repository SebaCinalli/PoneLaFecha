using Microsoft.AspNetCore.Mvc;
using Entidades;
using Negocio;

namespace PoneLaFecha.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            try
            {
                _logger.LogInformation("Intento de login para usuario: {Username}", request.Username);
                
                if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                {
                    _logger.LogWarning("Login fallido: Usuario o contraseña vacíos");
                    return BadRequest("Usuario y contraseña son requeridos");
                }

                // Primero intentar login como Usuario (admin)
                var usuario = LogicaUsuario.Autenticar(request.Username, request.Password);
                if (usuario != null)
                {
                    _logger.LogInformation("Login exitoso para usuario: {Username}", request.Username);
                    return Ok(usuario);
                }

                // Si no es usuario, intentar login como Cliente
                var cliente = LogicaUsuario.LoginCliente(request.Username, request.Password);
                if (cliente != null)
                {
                    _logger.LogInformation("Login exitoso para cliente: {Username}", request.Username);
                    return Ok(cliente);
                }
                
                _logger.LogWarning("Login fallido para usuario: {Username}", request.Username);
                return Unauthorized("Usuario o contraseña incorrectos");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar login para usuario: {Username}", request.Username);
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Cliente cliente)
        {
            try
            {
                _logger.LogInformation("Intento de registro para usuario: {Username}", cliente?.NombreUsuario ?? "null");
                
                // Validar el modelo
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();
                    
                    _logger.LogWarning("Registro fallido - Errores de validación: {Errors}", string.Join(", ", errors));
                    return BadRequest(new { mensaje = "Errores de validación", errores = errors });
                }

                // Validar que el cliente no sea nulo
                if (cliente == null)
                {
                    _logger.LogWarning("Registro fallido: Datos del cliente son nulos");
                    return BadRequest("Los datos del cliente son requeridos");
                }

                // Validaciones adicionales
                if (string.IsNullOrWhiteSpace(cliente.Nombre))
                {
                    _logger.LogWarning("Registro fallido: Nombre vacío");
                    return BadRequest("El nombre es requerido");
                }

                if (string.IsNullOrWhiteSpace(cliente.Apellido))
                {
                    _logger.LogWarning("Registro fallido: Apellido vacío");
                    return BadRequest("El apellido es requerido");
                }

                if (string.IsNullOrWhiteSpace(cliente.Email))
                {
                    _logger.LogWarning("Registro fallido: Email vacío");
                    return BadRequest("El email es requerido");
                }

                if (string.IsNullOrWhiteSpace(cliente.Telefono))
                {
                    _logger.LogWarning("Registro fallido: Teléfono vacío");
                    return BadRequest("El teléfono es requerido");
                }

                if (string.IsNullOrWhiteSpace(cliente.NombreUsuario))
                {
                    _logger.LogWarning("Registro fallido: Nombre de usuario vacío");
                    return BadRequest("El nombre de usuario es requerido");
                }

                if (cliente.NombreUsuario.Length < 3)
                {
                    _logger.LogWarning("Registro fallido: Nombre de usuario muy corto");
                    return BadRequest("El nombre de usuario debe tener al menos 3 caracteres");
                }

                if (string.IsNullOrWhiteSpace(cliente.Clave))
                {
                    _logger.LogWarning("Registro fallido: Contraseña vacía");
                    return BadRequest("La contraseña es requerida");
                }

                if (cliente.Clave.Length < 6)
                {
                    _logger.LogWarning("Registro fallido: Contraseña muy corta");
                    return BadRequest("La contraseña debe tener al menos 6 caracteres");
                }

                // Verificar si el usuario ya existe
                var usuarioExistente = LogicaUsuario.ObtenerClientePorNombreUsuario(cliente.NombreUsuario);
                if (usuarioExistente != null)
                {
                    _logger.LogWarning("Registro fallido: Usuario ya existe - {Username}", cliente.NombreUsuario);
                    return BadRequest("El nombre de usuario ya está en uso");
                }

                // Crear el cliente
                LogicaUsuario.CrearCliente(cliente);
                _logger.LogInformation("Usuario registrado exitosamente: {Username}", cliente.NombreUsuario);
                
                return Ok(new { mensaje = "Usuario registrado exitosamente" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar usuario: {Username}", cliente?.NombreUsuario ?? "null");
                return BadRequest($"Error al registrar el usuario: {ex.Message}");
            }
        }
    }

    public class LoginRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
