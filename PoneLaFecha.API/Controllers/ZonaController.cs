using Microsoft.AspNetCore.Mvc;
using Entidades;
using Negocio;

namespace PoneLaFecha.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZonaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(LogicaZona.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var zona = LogicaZona.Obtener(id);
            if (zona == null)
                return NotFound();
            return Ok(zona);
        }

        [HttpPost]
        public IActionResult Create(Zona zona)
        {
            try
            {
                LogicaZona.Crear(zona);
                return CreatedAtAction(nameof(Get), new { id = zona.IdZona }, zona);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Zona zona)
        {
            if (id != zona.IdZona)
                return BadRequest("ID mismatch");

            try
            {
                LogicaZona.Editar(zona);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                LogicaZona.Eliminar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
