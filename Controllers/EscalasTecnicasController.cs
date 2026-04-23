using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EscalasTecnicasController : ControllerBase
    {
        private readonly IEscalasTecnicasService _service;

        public EscalasTecnicasController(IEscalasTecnicasService service)
        {
            _service = service;
        }

        [HttpGet("vuelo/{idVuelo}")]
        public async Task<IActionResult> ListarPorVuelo(int idVuelo)
        {
            var result = await _service.ListarPorVuelo(idVuelo);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var result = await _service.ObtenerPorId(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] EscalasTecnicasModel m)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _service.Insertar(m);
            return Ok(new { message = "Escala técnica insertada correctamente" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] EscalasTecnicasModel m)
        {
            if (id != m.IdEscala) return BadRequest("El ID de la ruta no coincide con el del modelo.");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _service.Actualizar(m);
            return Ok(new { message = "Escala técnica actualizada correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _service.Eliminar(id);
            return Ok(new { message = "Escala técnica eliminada correctamente" });
        }
    }
}
