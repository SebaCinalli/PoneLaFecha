using Microsoft.AspNetCore.Mvc;
using Entidades;
using Negocio;

namespace PoneLaFecha.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(LogicaCliente.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cliente = LogicaCliente.Obtener(id);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            try
            {
                LogicaCliente.Crear(cliente);
                return CreatedAtAction(nameof(Get), new { id = cliente.IdCliente }, cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Cliente cliente)
        {
            if (id != cliente.IdCliente)
                return BadRequest("ID mismatch");

            try
            {
                LogicaCliente.Editar(cliente);
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
                LogicaCliente.Eliminar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("usuario/{nombreUsuario}")]
        public IActionResult GetByUsername(string nombreUsuario)
        {
            var cliente = LogicaCliente.ObtenerPorNombreUsuario(nombreUsuario);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }
    }
}
