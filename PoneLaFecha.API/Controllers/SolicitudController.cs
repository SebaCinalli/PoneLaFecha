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
        private readonly ILogger<SolicitudController> _logger;

        public SolicitudController(ILogger<SolicitudController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(LogicaSolicitud.Listar());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var solicitud = await LogicaSolicitud.GetByIdAsync(id);
            if (solicitud == null)
                return NotFound();
            return Ok(solicitud);
        }

        [HttpGet("cliente/{idCliente}")]
        public async Task<IActionResult> GetByCliente(int idCliente)
        {
            try
            {
                var solicitudes = await LogicaSolicitud.GetByClienteIdAsync(idCliente);
                return Ok(solicitudes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting solicitudes for client {IdCliente}", idCliente);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] JsonElement jsonElement)
        {
            try
            {
                _logger.LogInformation("Received solicitud creation request: {Json}", jsonElement.GetRawText());

                // Parse the request to get the solicitud and selected services
                if (!jsonElement.TryGetProperty("idCliente", out var idClienteProp) && 
                    !jsonElement.TryGetProperty("IdCliente", out idClienteProp))
                {
                    _logger.LogError("Missing required field: idCliente");
                    return BadRequest("Missing required field: idCliente");
                }
                var idCliente = idClienteProp.GetInt32();

                if (!jsonElement.TryGetProperty("fechaDesde", out var fechaDesdeProp) && 
                    !jsonElement.TryGetProperty("FechaDesde", out fechaDesdeProp))
                {
                    _logger.LogError("Missing required field: fechaDesde");
                    return BadRequest("Missing required field: fechaDesde");
                }
                var fechaDesde = fechaDesdeProp.GetDateTime();

                var estado = "Pendiente";
                if (jsonElement.TryGetProperty("estado", out var estadoProp) || 
                    jsonElement.TryGetProperty("Estado", out estadoProp))
                {
                    estado = estadoProp.GetString() ?? "Pendiente";
                }

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

                if (jsonElement.TryGetProperty("salonesSeleccionados", out var salones) ||
                    jsonElement.TryGetProperty("SalonesSeleccionados", out salones))
                {
                    salonesSeleccionados = JsonSerializer.Deserialize<List<int>>(salones.GetRawText());
                    _logger.LogInformation("Salones seleccionados: {Count}", salonesSeleccionados?.Count ?? 0);
                }

                if (jsonElement.TryGetProperty("barrasSeleccionadas", out var barras) ||
                    jsonElement.TryGetProperty("BarrasSeleccionadas", out barras))
                {
                    barrasSeleccionadas = JsonSerializer.Deserialize<List<int>>(barras.GetRawText());
                    _logger.LogInformation("Barras seleccionadas: {Count}", barrasSeleccionadas?.Count ?? 0);
                }

                if (jsonElement.TryGetProperty("gastrosSeleccionados", out var gastros) ||
                    jsonElement.TryGetProperty("GastrosSeleccionados", out gastros))
                {
                    gastrosSeleccionados = JsonSerializer.Deserialize<List<int>>(gastros.GetRawText());
                    _logger.LogInformation("Gastros seleccionados: {Count}", gastrosSeleccionados?.Count ?? 0);
                }

                if (jsonElement.TryGetProperty("djsSeleccionados", out var djs) ||
                    jsonElement.TryGetProperty("DjsSeleccionados", out djs))
                {
                    djsSeleccionados = JsonSerializer.Deserialize<List<int>>(djs.GetRawText());
                    _logger.LogInformation("DJs seleccionados: {Count}", djsSeleccionados?.Count ?? 0);
                }

                _logger.LogInformation("Creating solicitud for client {IdCliente} on date {FechaDesde}", idCliente, fechaDesde);

                var solicitudId = await LogicaSolicitud.CrearConServiciosAsync(
                    solicitud,
                    salonesSeleccionados,
                    barrasSeleccionadas,
                    gastrosSeleccionados,
                    djsSeleccionados
                );

                _logger.LogInformation("Solicitud created successfully with ID: {SolicitudId}", solicitudId);

                // Return a simple DTO without circular references
                var responseDto = new
                {
                    IdSolicitud = solicitudId,
                    IdCliente = idCliente,
                    FechaDesde = fechaDesde,
                    Estado = estado,
                    Message = "Solicitud creada exitosamente"
                };

                return CreatedAtAction(nameof(Get), new { id = solicitudId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating solicitud");
                return BadRequest(new { error = ex.Message, stackTrace = ex.StackTrace });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Deleting solicitud with ID: {Id}", id);
                
                var result = await LogicaSolicitud.DeleteAsync(id);
                if (result)
                {
                    _logger.LogInformation("Solicitud {Id} deleted successfully", id);
                    return Ok(new { message = "Solicitud eliminada correctamente" });
                }
                
                _logger.LogWarning("Solicitud {Id} not found", id);
                return NotFound(new { message = "Solicitud no encontrada" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting solicitud {Id}", id);
                return BadRequest(new { error = ex.Message });
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
