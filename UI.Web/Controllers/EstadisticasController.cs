using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace UI.Web.Controllers
{
    public class EstadisticasController : Controller
    {
        /// <summary>
   /// Vista que muestra estadísticas obtenidas con ADO.NET
      /// </summary>
        public IActionResult Index()
    {
            try
         {
      // Usar métodos con ADO.NET
  var salones = LogicaSalon.ListarConADO();
    var totalClientes = LogicaCliente.ObtenerTotalClientesConADO();

                ViewBag.Salones = salones;
      ViewBag.TotalClientes = totalClientes;
                ViewBag.TotalSalones = salones.Count;

      return View();
         }
            catch (Exception ex)
            {
      ViewBag.Error = $"Error al cargar estadísticas: {ex.Message}";
         return View();
            }
    }
    }
}
