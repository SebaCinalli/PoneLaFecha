using Microsoft.AspNetCore.Mvc;
using Entidades;
using Negocio;
using System.Text.Json;

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
        public async Task<IActionResult> Create([FromBody] JsonElement jsonElement)
        {
            try
            {
                // Parse the request to get the solicitud and selected services
                var idCliente = jsonElement.GetProperty("idCliente").GetInt32();
                var fechaDesde = jsonElement.GetProperty("fechaDesde").GetDateTime();
                var estado = jsonElement.GetProperty("estado").GetString() ?? "Pendiente";

                var solicitud = new Solicitud
                {
                    IdCliente = idCliente,
                    FechaDesde = fechaDesde,
                    Estado = estado
                };

                // Get selected services
                List<int>? salonesSeleccionados = null;
                List<int>? barrasSeleccionadas = null;
                List<int>? gastrosSeleccionados = null;
                List<int>? djsSeleccionados = null;

                if (jsonElement.TryGetProperty("salonesSeleccionados", out var salones))
                {
                    salonesSeleccionados = JsonSerializer.Deserialize<List<int>>(salones.GetRawText());
                }

                if (jsonElement.TryGetProperty("barrasSeleccionadas", out var barras))
                {
                    barrasSeleccionadas = JsonSerializer.Deserialize<List<int>>(barras.GetRawText());
                }

                if (jsonElement.TryGetProperty("gastrosSeleccionados", out var gastros))
                {
                    gastrosSeleccionados = JsonSerializer.Deserialize<List<int>>(gastros.GetRawText());
                }

                if (jsonElement.TryGetProperty("djsSeleccionados", out var djs))
                {
                    djsSeleccionados = JsonSerializer.Deserialize<List<int>>(djs.GetRawText());
                }

                var solicitudId = await LogicaSolicitud.CrearConServiciosAsync(
                    solicitud,
                    salonesSeleccionados,
                    barrasSeleccionadas,
                    gastrosSeleccionados,
                    djsSeleccionados
                );

                return CreatedAtAction(nameof(Get), new { id = solicitudId }, solicitud);
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
