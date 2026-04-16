using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasajerosRedesSocialesController : ControllerBase
    {
        private readonly IPasajerosRedesSocialesService _service;

        public PasajerosRedesSocialesController(IPasajerosRedesSocialesService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PasajerosRedesSocialesModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Red social vinculada correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("pasajero/{idPasajero}")]
        public async Task<IActionResult> Get(int idPasajero)
        {
            var result = await _service.ListarPorPasajero(idPasajero);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PasajerosRedesSocialesModel modelo)
        {
            try
            {
                await _service.Actualizar(id, modelo);
                return Ok(new { mensaje = "Información de red social actualizada." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.EliminarFisico(id);
                return Ok(new { mensaje = "Vínculo de red social eliminado permanentemente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}