using Microsoft.AspNetCore.Mvc;
using Entidades;
using Negocio;

namespace PoneLaFecha.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DjController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(LogicaDj.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dj = LogicaDj.Obtener(id);
            if (dj == null)
                return NotFound();
            return Ok(dj);
        }

        [HttpPost]
        public IActionResult Create(Dj dj)
        {
            try
            {
                LogicaDj.Crear(dj);
                return CreatedAtAction(nameof(Get), new { id = dj.IdDj }, dj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Dj dj)
        {
            if (id != dj.IdDj)
                return BadRequest("ID mismatch");

            try
            {
                LogicaDj.Editar(dj);
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
                LogicaDj.Eliminar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
