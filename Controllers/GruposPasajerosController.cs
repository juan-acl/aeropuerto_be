using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GruposPasajerosController : ControllerBase
    {
        private readonly IGruposPasajerosService _service;

        public GruposPasajerosController(IGruposPasajerosService service) => _service = service;

        [HttpPost("asignar")]
        public async Task<IActionResult> Post([FromBody] GruposPasajerosModel modelo)
        {
            try
            {
                await _service.AsignarPasajero(modelo);
                return Ok(new { mensaje = "Pasajero asignado al grupo correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("grupo/{idGrupo}")]
        public async Task<IActionResult> Get(int idGrupo)
        {
            var result = await _service.ListarPasajerosPorGrupo(idGrupo);
            return Ok(result);
        }

        [HttpDelete("quitar/{idGrupo}/{idPasajero}")]
        public async Task<IActionResult> Delete(int idGrupo, int idPasajero)
        {
            await _service.EliminarRelacion(idGrupo, idPasajero);
            return Ok(new { mensaje = "Pasajero removido del grupo." });
        }
    }
}