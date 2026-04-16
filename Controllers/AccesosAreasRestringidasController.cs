using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccesosAreasRestringidasController : ControllerBase
    {
        private readonly IAccesosAreasRestringidasService _service;

        public AccesosAreasRestringidasController(IAccesosAreasRestringidasService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AccesosAreasRestringidasModel modelo)
        {
            try
            {
                await _service.RegistrarAcceso(modelo);
                return Ok(new { mensaje = "Registro de acceso almacenado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("empleado/{idEmpleado}")]
        public async Task<IActionResult> GetByEmpleado(int idEmpleado)
        {
            var result = await _service.ListarPorEmpleado(idEmpleado);
            return Ok(result);
        }

        [HttpGet("denegados")]
        public async Task<IActionResult> GetDenegados()
        {
            var result = await _service.ListarAccesosDenegados();
            return Ok(result);
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro de acceso eliminado del log." });
        }
    }
}