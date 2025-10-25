using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Entidades;
using Negocio;

namespace UI.Web.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            // Si ya está autenticado, redirigir al home
   if (HttpContext.Session.GetString("UsuarioId") != null)
         {
       return RedirectToAction("Index", "Home");
     }
       return View();
        }

        [HttpPost]
        public IActionResult Login(string nombreUsuario, string password)
      {
    if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(password))
   {
     ViewBag.Error = "Debe ingresar usuario y contraseña.";
    return View();
          }

   try
            {
 var usuario = LogicaUsuario.Autenticar(nombreUsuario, password);
     
 if (usuario != null)
    {
          // Guardar información en la sesión
               HttpContext.Session.SetString("UsuarioId", usuario.IdUsuario.ToString());
  HttpContext.Session.SetString("NombreUsuario", usuario.NombreUsuario);
          HttpContext.Session.SetString("NombreCompleto", $"{usuario.Nombre} {usuario.Apellido}");
         HttpContext.Session.SetString("Rol", usuario.Rol);

      // Redirigir según el rol
if (usuario.Rol == "Administrador")
          {
              return RedirectToAction("Index", "Home");
      }
   else if (usuario.Rol == "Cliente")
     {
       return RedirectToAction("MenuCliente", "Auth");
     }
             }
      else
      {
         ViewBag.Error = "Usuario o contraseña incorrectos.";
       }
            }
            catch (Exception ex)
            {
    ViewBag.Error = $"Error al iniciar sesión: {ex.Message}";
       }

     return View();
  }

        public IActionResult Logout()
        {
      HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }

   public IActionResult Register()
        {
         // Si ya está autenticado, redirigir al home
          if (HttpContext.Session.GetString("UsuarioId") != null)
            {
   return RedirectToAction("Index", "Home");
            }
    return View();
        }

     [HttpPost]
        public IActionResult Register(string nombreUsuario, string password, string confirmPassword, 
    string nombre, string apellido, string email, string telefono)
        {
            if (password != confirmPassword)
  {
       ViewBag.Error = "Las contraseñas no coinciden.";
            return View();
  }

   try
            {
                var usuario = new Usuario
    {
        NombreUsuario = nombreUsuario,
        Password = password,
     Nombre = nombre,
          Apellido = apellido,
    Email = email,
 Telefono = telefono,
  Rol = "Cliente", // Por defecto los registros son clientes
     Activo = true,
     FechaCreacion = DateTime.Now
        };

                // Validar
        var validacion = Validaciones.ValidarUsuario(usuario);
     if (!validacion.EsValido)
     {
         ViewBag.Error = validacion.ObtenerMensajeErrores();
          return View();
      }

      LogicaUsuario.Crear(usuario);

       // Crear cliente asociado
                var cliente = new Cliente
       {
 Nombre = nombre,
                  Apellido = apellido,
       Email = email,
              Telefono = telefono,
        NombreUsuario = nombreUsuario
       };

        LogicaCliente.Crear(cliente);

         ViewBag.Success = "Registro exitoso. Ahora puede iniciar sesión.";
   return View("Login");
        }
        catch (Exception ex)
          {
 ViewBag.Error = $"Error al registrar: {ex.Message}";
            }

            return View();
        }

        public IActionResult MenuCliente()
  {
      // Verificar autenticación
  if (HttpContext.Session.GetString("UsuarioId") == null)
      {
        return RedirectToAction("Login");
     }

        // Verificar rol
    if (HttpContext.Session.GetString("Rol") != "Cliente")
         {
    return RedirectToAction("Index", "Home");
            }

          ViewBag.NombreCompleto = HttpContext.Session.GetString("NombreCompleto");
         return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
