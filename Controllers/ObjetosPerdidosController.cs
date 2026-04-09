using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObjetosPerdidosController : ControllerBase
    {
        private readonly IObjetosPerdidosService _service;

        public ObjetosPerdidosController(IObjetosPerdidosService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ObjetosPerdidosModel modelo)
        {
            try
            {
                await _service.RegistrarObjeto(modelo);
                return Ok(new { mensaje = "Objeto perdido registrado exitosamente en el sistema." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("pendientes")]
        public async Task<IActionResult> GetPendientes([FromQuery] string? codigoAeropuerto)
        {
            var result = await _service.ListarNoEntregados(codigoAeropuerto);
            return Ok(result);
        }

        [HttpGet("{id}/foto")]
        public async Task<IActionResult> GetFoto(int id)
        {
            var objeto = await _service.ObtenerFoto(id);
            if (objeto == null || objeto.FotoObjeto == null)
                return NotFound("Imagen no disponible para este objeto.");

            return File(objeto.FotoObjeto, "image/jpeg"); // O el mime type que estés usando
        }

        [HttpPatch("{id}/entregar")]
        public async Task<IActionResult> PatchEntregar(int id, [FromBody] int idPasajero)
        {
            await _service.EntregarObjeto(id, idPasajero);
            return Ok(new { mensaje = "Objeto marcado como ENTREGADO a su dueño." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro de objeto perdido eliminado." });
        }
    }
}