using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmergenciasMedicasController : ControllerBase
    {
        private readonly IEmergenciasMedicasService _service;

        public EmergenciasMedicasController(IEmergenciasMedicasService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmergenciasMedicasModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Emergencia médica registrada en el sistema." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("pasajero/{idPasajero}")]
        public async Task<IActionResult> GetByPasajero(int idPasajero)
        {
            var result = await _service.ListarPorPasajero(idPasajero);
            return Ok(result);
        }

        [HttpPatch("{id}/alta")]
        public async Task<IActionResult> PatchAlta(int id, [FromBody] DateTime fecha)
        {
            await _service.ActualizarAlta(id, fecha);
            return Ok(new { mensaje = "Fecha de alta actualizada." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro médico eliminado." });
        }
    }
}