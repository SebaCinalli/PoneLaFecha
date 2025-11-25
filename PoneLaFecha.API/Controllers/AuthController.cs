using Microsoft.AspNetCore.Mvc;
using Entidades;
using Negocio;

namespace PoneLaFecha.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            try
            {
                var usuario = LogicaUsuario.Login(request.Username, request.Password);
                if (usuario != null)
                {
                    return Ok(usuario);
                }
                return Unauthorized("Usuario o contraseña incorrectos");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public IActionResult Register(Cliente cliente)
        {
            try
            {
                LogicaUsuario.Crear(cliente);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class LoginRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
