using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramaLealtadController : ControllerBase
    {
        private readonly IProgramaLealtadService _service;

        public ProgramaLealtadController(IProgramaLealtadService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProgramaLealtadModel modelo)
        {
            try
            {
                int idGenerado = await _service.RegistrarMembresia(modelo);
                return Ok(new
                {
                    mensaje = "Pasajero inscrito exitosamente en el programa de lealtad.",
                    idLealtad = idGenerado
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al inscribir pasajero: {ex.Message}");
            }
        }

        [HttpGet("pasajero/{idPasajero}")]
        public async Task<IActionResult> GetByPasajero(int idPasajero)
        {
            var result = await _service.ObtenerPorPasajero(idPasajero);
            if (result == null)
                return NotFound("El pasajero no está inscrito en el programa de lealtad.");

            return Ok(result);
        }

        public class ActividadDto
        {
            public int Puntos { get; set; }
            public int Millas { get; set; }
        }

        [HttpPatch("pasajero/{idPasajero}/sumar")]
        public async Task<IActionResult> PatchSumarActividad(int idPasajero, [FromBody] ActividadDto dto)
        {
            await _service.SumarActividad(idPasajero, dto.Puntos, dto.Millas);
            return Ok(new { mensaje = $"Se han sumado {dto.Puntos} puntos y {dto.Millas} millas a la cuenta." });
        }

        public class CanjeDto
        {
            public int PuntosACanjear { get; set; }
        }

        [HttpPatch("pasajero/{idPasajero}/canjear")]
        public async Task<IActionResult> PatchCanjearPuntos(int idPasajero, [FromBody] CanjeDto dto)
        {
            try
            {
                await _service.CanjearPuntos(idPasajero, dto.PuntosACanjear);
                return Ok(new { mensaje = $"Canje de {dto.PuntosACanjear} puntos realizado con éxito." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro del programa de lealtad eliminado." });
        }
    }
}