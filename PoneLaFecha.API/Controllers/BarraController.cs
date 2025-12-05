using Microsoft.AspNetCore.Mvc;
using Entidades;
using Negocio;

namespace PoneLaFecha.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarraController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(LogicaBarra.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var barra = LogicaBarra.Obtener(id);
            if (barra == null)
                return NotFound();
            return Ok(barra);
        }

        [HttpPost]
        public IActionResult Create(Barra barra)
        {
            try
            {
                LogicaBarra.Crear(barra);
                return CreatedAtAction(nameof(Get), new { id = barra.IdBarra }, barra);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Barra barra)
        {
            if (id != barra.IdBarra)
                return BadRequest("ID mismatch");

            try
            {
                LogicaBarra.Editar(barra);
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
                LogicaBarra.Eliminar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
