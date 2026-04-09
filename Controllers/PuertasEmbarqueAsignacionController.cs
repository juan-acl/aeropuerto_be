using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PuertasEmbarqueAsignacionController : ControllerBase
    {
        private readonly IPuertasEmbarqueAsignacionService _service;

        public PuertasEmbarqueAsignacionController(IPuertasEmbarqueAsignacionService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PuertasEmbarqueAsignacionModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Puerta asignada al vuelo exitosamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("vuelo/{idVuelo}")]
        public async Task<IActionResult> GetByVuelo(int idVuelo)
        {
            var result = await _service.ListarPorVuelo(idVuelo);
            return Ok(result);
        }

        [HttpGet("actual")]
        public async Task<IActionResult> GetCurrent()
        {
            var result = await _service.ListarOcupacionActual();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PuertasEmbarqueAsignacionModel modelo)
        {
            await _service.Actualizar(id, modelo);
            return Ok(new { mensaje = "Asignación de puerta actualizada." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Asignación eliminada físicamente." });
        }
    }
}