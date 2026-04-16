using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipajeEspecialController : ControllerBase
    {
        private readonly IEquipajeEspecialService _service;

        public EquipajeEspecialController(IEquipajeEspecialService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EquipajeEspecialModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Registro de equipaje especial creado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("reserva/{idReserva}")]
        public async Task<IActionResult> Get(int idReserva)
        {
            var result = await _service.ListarPorReserva(idReserva);
            return Ok(result);
        }

        [HttpPatch("autorizar/{id}")]
        public async Task<IActionResult> Authorize(int id, [FromBody] decimal nuevoCosto)
        {
            await _service.AutorizarEquipaje(id, nuevoCosto);
            return Ok(new { mensaje = "Equipaje autorizado y costo actualizado." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro eliminado físicamente." });
        }
    }
}