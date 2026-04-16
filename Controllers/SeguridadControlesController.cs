using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguridadControlesController : ControllerBase
    {
        private readonly ISeguridadControlesService _service;

        public SeguridadControlesController(ISeguridadControlesService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SeguridadControlesModel modelo)
        {
            try
            {
                await _service.RegistrarControl(modelo);
                return Ok(new { mensaje = "Reporte de control de seguridad guardado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("aeropuerto/{codigo}")]
        public async Task<IActionResult> GetByAero(string codigo)
        {
            var result = await _service.ListarPorAeropuerto(codigo);
            return Ok(result);
        }

        [HttpGet("resumen/{codigo}")]
        public async Task<IActionResult> GetSummary(string codigo, [FromQuery] DateTime? fecha)
        {
            var f = fecha ?? DateTime.Now;
            var resumen = await _service.ObtenerResumenEstadistico(codigo, f);
            return Ok(resumen);
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro de control eliminado." });
        }
    }
}