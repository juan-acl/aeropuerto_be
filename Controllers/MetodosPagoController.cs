using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetodosPagoController : ControllerBase
    {
        private readonly IMetodosPagoService _service;

        public MetodosPagoController(IMetodosPagoService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MetodosPagoModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Método de pago creado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.ListarActivos();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MetodosPagoModel modelo)
        {
            try
            {
                await _service.Actualizar(id, modelo);
                return Ok(new { mensaje = "Método de pago actualizado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.EliminarFisico(id);
                return Ok(new { mensaje = "Método de pago eliminado permanentemente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}