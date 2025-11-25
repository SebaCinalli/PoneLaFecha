using Microsoft.AspNetCore.Mvc;
using Entidades;
using Negocio;

namespace PoneLaFecha.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitudController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(LogicaSolicitud.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var solicitud = LogicaSolicitud.Obtener(id);
            if (solicitud == null)
                return NotFound();
            return Ok(solicitud);
        }

        [HttpPost]
        public IActionResult Create(Solicitud solicitud)
        {
            try
            {
                LogicaSolicitud.Crear(solicitud);
                return CreatedAtAction(nameof(Get), new { id = solicitud.IdSolicitud }, solicitud);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("estado/{estado}")]
        public async Task<IActionResult> GetByEstado(string estado)
        {
            var solicitudes = await LogicaSolicitud.GetByEstadoAsync(estado);
            return Ok(solicitudes);
        }

        [HttpPost("{id}/cambiar-estado")]
        public async Task<IActionResult> ChangeStatus(int id, [FromBody] string nuevoEstado)
        {
            try
            {
                var result = await LogicaSolicitud.CambiarEstadoAsync(id, nuevoEstado);
                if (result)
                    return Ok();
                return BadRequest("No se pudo cambiar el estado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
