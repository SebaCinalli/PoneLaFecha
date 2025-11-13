using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace UI.Web.Controllers
{
    public class EstadisticasController : Controller
    {
        /// <summary>
        /// Vista que muestra estadísticas del sistema
        /// </summary>
        public async Task<IActionResult> Index()
        {
       try
            {
        // Usar métodos con ADO.NET para salones y clientes
      var salones = LogicaSalon.ListarConADO();
  var totalClientes = LogicaCliente.ObtenerTotalClientesConADO();
   
             // Obtener estadísticas de todos los servicios
     var barras = Negocio.LogicaBarra.Listar();
    var djs = LogicaDj.Listar();
  var gastronomicos = LogicaGastronomico.Listar();
                
 // Usar LogicaZona con async
   var logicaZona = new LogicaZona();
      var zonas = await logicaZona.GetAllAsync();

    ViewBag.Salones = salones;
        ViewBag.TotalClientes = totalClientes;
      ViewBag.TotalSalones = salones.Count;
     
 ViewBag.Barras = barras;
      ViewBag.TotalBarras = barras.Count;
  
     ViewBag.Djs = djs;
 ViewBag.TotalDjs = djs.Count;
  
    ViewBag.Gastronomicos = gastronomicos;
  ViewBag.TotalGastronomicos = gastronomicos.Count;
   
      ViewBag.Zonas = zonas;
 ViewBag.TotalZonas = zonas.Count;

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
