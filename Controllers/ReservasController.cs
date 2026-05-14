using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly IReservasService _service;

        public ReservasController(IReservasService service) => _service = service;

        // Extrae el mensaje legible del error Oracle (ORA-2XXXX son errores de usuario)
        private static string ExtraerMensaje(Exception ex)
        {
            var msg = ex.InnerException?.Message ?? ex.Message;
            var match = System.Text.RegularExpressions.Regex.Match(
                msg, @"ORA-2\d{4}:\s*(.+?)(?:\r?\n|$)");
            return match.Success
                ? match.Groups[1].Value.Trim()
                : msg.Split('\n')[0].Trim();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReservasModel modelo)
        {
            if (string.IsNullOrWhiteSpace(modelo.CodigoReserva))
                modelo.CodigoReserva =
                    $"RES-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString("N")[..6].ToUpper()}";

            try
            {
                await _service.Insertar(modelo);
                return Ok(new
                {
                    CodigoReserva = modelo.CodigoReserva,
                    IdGenerado    = modelo.IdReserva,
                    mensaje       = "Reserva creada exitosamente."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ExtraerMensaje(ex) });
            }
        }

        [HttpGet("pasajero/{idPasajero}")]
        public async Task<IActionResult> GetByPasajero(int idPasajero)
        {
            var result = await _service.ListarPorPasajero(idPasajero);
            return Ok(result);
        }

        [HttpGet("vuelo/{idVuelo}")]
        public async Task<IActionResult> GetByVuelo(int idVuelo)
        {
            var result = await _service.ListarPorVuelo(idVuelo);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ReservasModel modelo)
        {
            try
            {
                await _service.Actualizar(id, modelo);
                return Ok(new { mensaje = "Reserva actualizada." });
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
                return Ok(new { mensaje = "Reserva eliminada permanentemente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost("registrar-abordaje")]
        public async Task<IActionResult> RegistrarAbordaje([FromBody] EmbarqueRequest modelo)
        {
            if (modelo == null) return BadRequest("Los datos de embarque son requeridos.");

            try
            {
                await _service.RegistrarAbordaje(modelo);
                return Ok(new { mensaje = "Pasajero abordado correctamente y conteo actualizado." });
            }
            catch (Exception ex)
            {
                // Aquí capturamos los errores del SP (ej. Puerta incorrecta, No hizo Check-in)
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("check-in")]
        public async Task<IActionResult> CheckIn([FromBody] CheckInRequest modelo)
        {
            if (modelo == null) return BadRequest("Datos de check-in inválidos.");

            try
            {
                await _service.RealizarCheckIn(modelo);
                return Ok(new
                {
                    mensaje = "Check-in realizado con éxito. Su pase de abordar ha sido generado.",
                    qr_provisional = $"QR-{modelo.CodigoReserva}"
                });
            }
            catch (Exception ex)
            {
                // Captura errores como -38303 (fuera de tiempo) o -38304 (asiento ocupado)
                return BadRequest(new
                {
                    error = "No se pudo completar el check-in",
                    detalle = ex.Message
                });
            }
        }

        [HttpPost("check-in-mostrador")]
        public async Task<IActionResult> CheckInMostrador([FromBody] CheckInMostradorRequest modelo)
        {
            if (modelo == null) return BadRequest("Datos insuficientes para el check-in en mostrador.");

            try
            {
                await _service.RealizarCheckInMostrador(modelo);
                return Ok(new
                {
                    mensaje = "Check-in en mostrador completado con éxito.",
                    detalle = $"Equipaje registrado: {modelo.EquipajeFacturado}kg facturado, {modelo.EquipajeMano}kg mano."
                });
            }
            catch (Exception ex)
            {
                // Captura errores específicos como -38603 (fuera de tiempo) o -38604 (visa inválida)
                return BadRequest(new
                {
                    error = "Error en mostrador",
                    detalle = ex.Message
                });
            }
        }

        [HttpPost("crear-reserva")]
        public async Task<IActionResult> CrearReserva([FromBody] CrearReservaRequest modelo)
        {
            if (modelo == null) return BadRequest("Los datos de la reserva son obligatorios.");

            try
            {
                await _service.CrearReserva(modelo);
                return Ok(new
                {
                    mensaje = "Reservación creada exitosamente en estado PENDIENTE. Tiene 15 minutos para realizar el pago."
                });
            }
            catch (Exception ex)
            {
                // Captura errores específicos de Oracle:
                // -37802: Menos de 2h para la salida
                // -37805: Vuelos traslapados
                // -37806: Asiento ocupado
                return BadRequest(new
                {
                    error = "No se pudo crear la reserva",
                    detalle = ex.Message
                });
            }
        }

        [HttpPost("pagar")]
        public async Task<IActionResult> PagarBoleto([FromBody] PagoBoletoRequest modelo)
        {
            if (modelo == null) return BadRequest("Datos de pago incompletos.");

            try
            {
                await _service.PagarBoleto(modelo);
                return Ok(new { mensaje = "Pago procesado con éxito. Su reserva ha sido CONFIRMADA." });
            }
            catch (Exception ex)
            {
                // Captura errores:
                // -38001: La reserva no está PENDIENTE
                // -38002: La reserva no existe
                return BadRequest(new
                {
                    error = "Error al procesar el pago",
                    detalle = ex.Message
                });
            }
        }
    }
}
