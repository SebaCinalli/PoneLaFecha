using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace PoneLaFecha.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadisticasController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStats()
        {
            var clientes = LogicaCliente.Listar();
            var zonas = LogicaZona.Listar();
            var salones = LogicaSalon.Listar();
            var djs = LogicaDj.Listar();
            var barras = LogicaGastronomico.ListarBarras();
            var comidas = LogicaGastronomico.Listar();

            return Ok(new
            {
                TotalClientes = clientes.Count,
                TotalZonas = zonas.Count,
                TotalSalones = salones.Count,
                TotalDjs = djs.Count,
                TotalBarras = barras.Count,
                TotalComidas = comidas.Count
            });
        }
    }
}
