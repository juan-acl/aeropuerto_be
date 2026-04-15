using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditoriaSeguridadController : ControllerBase
    {
        private readonly IAuditoriaSeguridadService _service;

        public AuditoriaSeguridadController(IAuditoriaSeguridadService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] AuditoriasSeguridad modelo)
        {
            if (modelo == null) return BadRequest("Datos inválidos");
            try {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "AuditoriaSeguridad insertado correctamente." });
            } catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] AuditoriasSeguridad modelo)
        {
            try {
                await _service.Actualizar(modelo.IdAuditoriaSeguridad ,modelo);
                return Ok(new { mensaje = "AuditoriaSeguridad actualizado correctamente." });
            } catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try {
                await _service.Eliminar(id);
                return Ok(new { mensaje = "AuditoriaSeguridad eliminado correctamente." });
            } catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try {
                var lista = await _service.ListarTodo();
                return Ok(lista);
            } catch (Exception ex) { return StatusCode(500, ex.Message); }
        }
    }
}
