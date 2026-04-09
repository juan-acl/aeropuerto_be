using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObjetosEntregadosController : ControllerBase
    {
        private readonly IObjetosEntregadosService _service;

        public ObjetosEntregadosController(IObjetosEntregadosService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ObjetosEntregadosModel modelo)
        {
            try
            {
                await _service.RegistrarEntrega(modelo);
                return Ok(new { mensaje = "Comprobante de entrega y firma registrados exitosamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.ListarEntregas();
            return Ok(result);
        }

        [HttpGet("{id}/firma")]
        public async Task<IActionResult> GetFirma(int id)
        {
            var registro = await _service.ObtenerFirma(id);
            if (registro == null || registro.FirmaDigital == null)
                return NotFound("No se encontró una firma digital para este registro.");

            // Retornamos la firma como imagen (usualmente png o jpeg dependiendo del pad de firmas)
            return File(registro.FirmaDigital, "image/png");
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro de entrega eliminado." });
        }
    }
}