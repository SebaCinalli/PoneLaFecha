using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UI.Web.Filters
{
    public class AuthorizeAttribute : ActionFilterAttribute
    {
        public string Rol { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
      {
            var session = context.HttpContext.Session;
            var usuarioId = session.GetString("UsuarioId");

 // Verificar si está autenticado
       if (string.IsNullOrEmpty(usuarioId))
   {
     context.Result = new RedirectToActionResult("Login", "Auth", null);
 return;
        }

            // Verificar rol si se especificó
  if (!string.IsNullOrEmpty(Rol))
 {
           var rolUsuario = session.GetString("Rol");
     if (rolUsuario != Rol)
      {
     context.Result = new RedirectToActionResult("AccessDenied", "Auth", null);
      return;
     }
  }

   base.OnActionExecuting(context);
        }
 }
}
