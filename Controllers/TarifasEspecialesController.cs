using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarifasEspecialesController : ControllerBase
    {
        private readonly ITarifasEspecialesService _service;

        public TarifasEspecialesController(ITarifasEspecialesService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TarifasEspecialesModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Tarifa especial creada exitosamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("activas")]
        public async Task<IActionResult> GetActivas()
        {
            var result = await _service.ListarActivas();
            return Ok(result);
        }

        [HttpGet("aerolinea/{idAerolinea}")]
        public async Task<IActionResult> GetByAerolinea(int idAerolinea)
        {
            var result = await _service.ListarPorAerolinea(idAerolinea);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TarifasEspecialesModel modelo)
        {
            await _service.Actualizar(id, modelo);
            return Ok(new { mensaje = "Tarifa especial actualizada." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Tarifa eliminada permanentemente del catálogo." });
        }
    }
}