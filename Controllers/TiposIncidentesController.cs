using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiposIncidentesController : ControllerBase
    {
        private readonly ITiposIncidentesService _service;

        public TiposIncidentesController(ITiposIncidentesService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TiposIncidentesModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Nuevo tipo de incidente/protocolo registrado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.ListarActivos();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TiposIncidentesModel modelo)
        {
            await _service.Actualizar(id, modelo);
            return Ok(new { mensaje = "Protocolo de incidente actualizado." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarLogico(id);
            return Ok(new { mensaje = "Tipo de incidente desactivado del sistema." });
        }
    }
}