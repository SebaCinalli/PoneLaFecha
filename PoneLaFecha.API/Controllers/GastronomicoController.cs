using Microsoft.AspNetCore.Mvc;
using Entidades;
using Negocio;

namespace PoneLaFecha.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GastronomicoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(LogicaGastronomico.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var comida = LogicaGastronomico.Obtener(id);
            if (comida == null)
                return NotFound();
            return Ok(comida);
        }

        [HttpPost]
        public IActionResult Create(Gastronomico comida)
        {
            try
            {
                LogicaGastronomico.Crear(comida);
                return CreatedAtAction(nameof(Get), new { id = comida.IdGastro }, comida);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Gastronomico comida)
        {
            if (id != comida.IdGastro)
                return BadRequest("ID mismatch");

            try
            {
                LogicaGastronomico.Editar(comida);
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
                LogicaGastronomico.Eliminar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
