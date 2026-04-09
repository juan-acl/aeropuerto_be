using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstacionamientoRegistroController : ControllerBase
    {
        private readonly IEstacionamientoRegistroService _service;

        public EstacionamientoRegistroController(IEstacionamientoRegistroService service) => _service = service;

        [HttpPost("entrada")]
        public async Task<IActionResult> PostEntrada([FromBody] EstacionamientoRegistroModel modelo)
        {
            try
            {
                int idGenerado = await _service.RegistrarEntrada(modelo);
                return Ok(new
                {
                    mensaje = "Entrada registrada y espacio ocupado.",
                    ticketId = idGenerado
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar entrada: {ex.Message}");
            }
        }

        [HttpPost("{id}/calcular-salida")]
        public async Task<IActionResult> PostCalcularSalida(int id)
        {
            var registro = await _service.CalcularSalida(id);
            if (registro == null)
                return NotFound("No se encontró el registro o ya fue procesado.");

            return Ok(new
            {
                mensaje = "Cálculo realizado con éxito.",
                tiempoHoras = registro.TiempoTotalHoras,
                totalPagar = registro.TotalPagar
            });
        }

        public class PagoDto
        {
            public string MetodoPago { get; set; } = null!;
        }

        [HttpPatch("{id}/pagar")]
        public async Task<IActionResult> PatchPagar(int id, [FromBody] PagoDto dto)
        {
            try
            {
                await _service.ProcesarPago(id, dto.MetodoPago);
                return Ok(new { mensaje = "Pago procesado exitosamente. La barrera puede ser levantada y el espacio está libre." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al procesar el pago: {ex.Message}");
            }
        }

        [HttpGet("activos")]
        public async Task<IActionResult> GetActivos()
        {
            var result = await _service.ListarVehiculosActivos();
            return Ok(result);
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro de estacionamiento eliminado." });
        }
    }
}