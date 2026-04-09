using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentesInvolucradosController : ControllerBase
    {
        private readonly IIncidentesInvolucradosService _service;

        public IncidentesInvolucradosController(IIncidentesInvolucradosService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IncidentesInvolucradosModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Persona involucrada registrada en el incidente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("incidente/{idIncidente}")]
        public async Task<IActionResult> GetByIncidente(int idIncidente)
        {
            var result = await _service.ListarPorIncidente(idIncidente);
            return Ok(result);
        }

        [HttpPatch("{id}/declaracion")]
        public async Task<IActionResult> PatchDeclaracion(int id, [FromBody] string declaracion)
        {
            await _service.ActualizarDeclaracion(id, declaracion);
            return Ok(new { mensaje = "Declaración actualizada." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Involucrado eliminado del registro." });
        }
    }
}