using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObjetosDecomisadosController : ControllerBase
    {
        private readonly IObjetosDecomisadosService _service;

        public ObjetosDecomisadosController(IObjetosDecomisadosService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ObjetosDecomisadosModel modelo)
        {
            try
            {
                await _service.RegistrarDecomiso(modelo);
                return Ok(new { mensaje = "Objeto decomisado registrado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("control/{idControl}")]
        public async Task<IActionResult> GetByControl(int idControl)
        {
            var result = await _service.ListarPorControl(idControl);
            return Ok(result);
        }

        [HttpGet("pasajero/{idPasajero}")]
        public async Task<IActionResult> GetByPasajero(int idPasajero)
        {
            var result = await _service.ListarPorPasajero(idPasajero);
            return Ok(result);
        }

        [HttpPatch("{id}/destino")]
        public async Task<IActionResult> PatchDestino(int id, [FromBody] string destino)
        {
            await _service.ActualizarDestino(id, destino);
            return Ok(new { mensaje = "Destino final del objeto actualizado." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro de decomiso eliminado." });
        }
    }
}