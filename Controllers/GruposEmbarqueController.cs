using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GruposEmbarqueController : ControllerBase
    {
        private readonly IGruposEmbarqueService _service;

        public GruposEmbarqueController(IGruposEmbarqueService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GruposEmbarqueModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Grupo de embarque configurado para el vuelo." });
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] GruposEmbarqueModel modelo)
        {
            await _service.Actualizar(id, modelo);
            return Ok(new { mensaje = "Grupo de embarque actualizado." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Grupo de embarque eliminado físicamente." });
        }
    }
}