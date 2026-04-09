using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControlAbordajeController : ControllerBase
    {
        private readonly IControlAbordajeService _service;

        public ControlAbordajeController(IControlAbordajeService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ControlAbordajeModel modelo)
        {
            try
            {
                await _service.RegistrarAbordaje(modelo);
                return Ok(new { mensaje = "Abordaje verificado y registrado." });
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

        [HttpGet("vuelo/{idVuelo}/conteo")]
        public async Task<IActionResult> GetCount(int idVuelo)
        {
            var total = await _service.ContarPasajerosAbordados(idVuelo);
            return Ok(new { idVuelo, total_abordados = total });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro de control eliminado." });
        }
    }
}