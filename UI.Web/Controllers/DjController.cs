using Microsoft.AspNetCore.Mvc;
using Entidades;
using Negocio;

namespace UI.Web.Controllers
{
 public class DjController : Controller
  {
   public IActionResult Index() => View(LogicaDj.Listar());

 public IActionResult Crear() => View();

   [HttpPost]
        public IActionResult Crear(Dj dj)
    {
      if (ModelState.IsValid)
     {
       LogicaDj.Crear(dj);
        return RedirectToAction("Index");
  }
       return View(dj);
        }

public IActionResult Editar(int id)
        {
  var dj = LogicaDj.Obtener(id);
 return dj == null ? NotFound() : View(dj);
        }

   [HttpPost]
public IActionResult Editar(Dj dj)
  {
       if (ModelState.IsValid)
     {
  LogicaDj.Editar(dj);
              return RedirectToAction("Index");
            }
      return View(dj);
  }

        public IActionResult Eliminar(int id)
        {
      LogicaDj.Eliminar(id);
         return RedirectToAction("Index");
 }
    }
}
