using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentesMedidasController : ControllerBase
    {
        private readonly IIncidentesMedidasService _service;

        public IncidentesMedidasController(IIncidentesMedidasService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IncidentesMedidasModel modelo)
        {
            try
            {
                await _service.AplicarMedida(modelo);
                return Ok(new { mensaje = "Medida disciplinaria/legal aplicada con éxito." });
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

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro de medida eliminado." });
        }
    }
}