using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentesEvidenciaController : ControllerBase
    {
        private readonly IIncidentesEvidenciaService _service;

        public IncidentesEvidenciaController(IIncidentesEvidenciaService service) => _service = service;

        [HttpPost("cargar")]
        public async Task<IActionResult> Post([FromBody] IncidentesEvidenciaModel modelo)
        {
            try
            {
                await _service.CargarEvidencia(modelo);
                return Ok(new { mensaje = "Evidencia registrada correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("incidente/{idIncidente}")]
        public async Task<IActionResult> GetByIncidente(int idIncidente)
        {
            var result = await _service.ListarPorIncidente(idIncidente);
            return Ok(result);
        }

        [HttpGet("{id}/archivo")]
        public async Task<IActionResult> GetFile(int id)
        {
            var evidencia = await _service.ObtenerPorId(id);
            if (evidencia == null || evidencia.ArchivoEvidencia == null)
                return NotFound("Archivo no encontrado.");

            // Retorna el binario (esto permite previsualizar imágenes en el navegador)
            return File(evidencia.ArchivoEvidencia, "application/octet-stream");
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Evidencia eliminada." });
        }
    }
}