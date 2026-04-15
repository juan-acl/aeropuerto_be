using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/aviones")]
    public class AvionController : ControllerBase
    {
        private readonly IAvionService _service;
        public AvionController(IAvionService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try { return Ok(await _service.ListarTodo()); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(string id)
        {
            try {
                var item = await _service.ObtenerPorId(id);
                return item == null ? NotFound() : Ok(item);
            } catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] AvionModel modelo)
        {
            if (modelo == null) return BadRequest("Datos inválidos.");
            try { await _service.Insertar(modelo); return Ok(new { mensaje = "Creado correctamente." }); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(string id, [FromBody] AvionModel modelo)
        {
            try {
                var ok = await _service.Actualizar(id, modelo);
                return ok ? Ok(new { mensaje = "Actualizado." }) : NotFound();
            } catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(string id)
        {
            try { await _service.Eliminar(id); return Ok(new { mensaje = "Eliminado." }); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }
    }
}
