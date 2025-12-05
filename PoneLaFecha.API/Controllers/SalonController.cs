using Microsoft.AspNetCore.Mvc;
using Entidades;
using Negocio;

namespace PoneLaFecha.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalonController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(LogicaSalon.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var salon = LogicaSalon.Obtener(id);
            if (salon == null)
                return NotFound();
            return Ok(salon);
        }

        [HttpPost]
        public IActionResult Create(Salon salon)
        {
            try
            {
                LogicaSalon.Crear(salon);
                return CreatedAtAction(nameof(Get), new { id = salon.IdSalon }, salon);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Salon salon)
        {
            if (id != salon.IdSalon)
                return BadRequest("ID mismatch");

            try
            {
                LogicaSalon.Editar(salon);
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
                LogicaSalon.Eliminar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
