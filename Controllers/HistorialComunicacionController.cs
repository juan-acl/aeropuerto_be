using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialComunicacionesController : ControllerBase
    {
        private readonly IHistorialComunicacionService _service;

        public HistorialComunicacionesController(IHistorialComunicacionService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] HistorialComunicacionModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Registro de comunicación guardado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("pasajero/{idPasajero}")]
        public async Task<IActionResult> GetByPasajero(int idPasajero)
        {
            var lista = await _service.ListarPorPasajero(idPasajero);
            return Ok(lista);
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> DeleteFisico(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro eliminado físicamente." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarHistorialComunicacion(int id, [FromBody] HistorialComunicacionModel modelo)
        {
            try
            {
                // Validamos que el ID del cuerpo o de la URL coincidan 
                await _service.Actualizar(id, modelo);
                return Ok(new { mensaje = $"Comunicación con ID {id} actualizada correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar: {ex.Message}");
            }
        }
    }
}