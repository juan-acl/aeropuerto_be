using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicidadController : ControllerBase
    {
        private readonly IPublicidadService _service;

        public PublicidadController(IPublicidadService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PublicidadModel modelo)
        {
            try
            {
                int idGenerado = await _service.RegistrarPublicidad(modelo);
                return Ok(new
                {
                    mensaje = "Espacio publicitario registrado. Por favor asocie el contrato firmado.",
                    idPublicidad = idGenerado
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("aeropuerto/{codigo}")]
        public async Task<IActionResult> GetByAeropuerto(string codigo)
        {
            var result = await _service.ListarPorAeropuerto(codigo);
            return Ok(result);
        }

        [HttpGet("aeropuerto/{codigo}/vigentes")]
        public async Task<IActionResult> GetVigentes(string codigo)
        {
            var result = await _service.ListarActivas(codigo);
            return Ok(result);
        }

        // --- Manejo del BLOB (Archivo de Contrato) ---

        [HttpPost("{id}/contrato")]
        public async Task<IActionResult> PostUploadContrato(int id, IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
                return BadRequest("Debe enviar un archivo válido.");

            // Convertimos el IFormFile (Multipart/form-data) a byte array
            using var memoryStream = new MemoryStream();
            await archivo.CopyToAsync(memoryStream);
            var documentoBytes = memoryStream.ToArray();

            await _service.SubirContrato(id, documentoBytes);

            return Ok(new { mensaje = "Contrato asociado correctamente a la pauta publicitaria." });
        }

        [HttpGet("{id}/contrato")]
        public async Task<IActionResult> GetDownloadContrato(int id)
        {
            var contratoBytes = await _service.ObtenerContrato(id);

            if (contratoBytes == null || contratoBytes.Length == 0)
                return NotFound("Esta publicidad no tiene un contrato digitalizado asociado.");

            // Retornamos el BLOB como un archivo PDF por defecto (puedes ajustar el MIME type según necesites)
            return File(contratoBytes, "application/pdf", $"Contrato_Publicidad_{id}.pdf");
        }

        // ---------------------------------------------

        [HttpPatch("{id}/desactivar")]
        public async Task<IActionResult> PatchDesactivar(int id)
        {
            await _service.DesactivarPublicidad(id);
            return Ok(new { mensaje = "Pauta publicitaria finalizada/desactivada." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro publicitario eliminado." });
        }
    }
}