using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuejaTransporteTerrestreController : ControllerBase
    {
        private readonly IQuejaTransporteTerrestreService _service;

        public QuejaTransporteTerrestreController(IQuejaTransporteTerrestreService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] QuejasTransporteTerrestre modelo)
        {
            if (modelo == null) return BadRequest("Datos inválidos");
            try {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "QuejaTransporteTerrestre insertado correctamente." });
            } catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] QuejasTransporteTerrestre modelo)
        {
            try {
                await _service.Actualizar(modelo.IdQuejaTransporte, modelo);
                return Ok(new { mensaje = "QuejaTransporteTerrestre actualizado correctamente." });
            } catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try {
                await _service.Eliminar(id);
                return Ok(new { mensaje = "QuejaTransporteTerrestre eliminado correctamente." });
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
