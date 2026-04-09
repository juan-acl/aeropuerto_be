using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasajerosDocumentosController : ControllerBase
    {
        private readonly IPasajerosDocumentosService _service;

        public PasajerosDocumentosController(IPasajerosDocumentosService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PasajerosDocumentosModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Documento registrado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("pasajero/{idPasajero}")]
        public async Task<IActionResult> GetPorPasajero(int idPasajero)
        {
            var docs = await _service.ListarPorPasajero(idPasajero);
            return Ok(docs);
        }

        [HttpPatch("{id}/verificar")]
        public async Task<IActionResult> Verificar(int id, [FromBody] int estado)
        {
            await _service.VerificarDocumento(id, estado);
            return Ok(new { mensaje = "Estado de verificación actualizado." });
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Eliminar(id);
            return Ok(new { mensaje = "Documento desactivado." });
        }
    }
}