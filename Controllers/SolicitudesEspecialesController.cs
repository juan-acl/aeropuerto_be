using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitudesEspecialesController : ControllerBase
    {
        private readonly ISolicitudesEspecialesService _service;

        public SolicitudesEspecialesController(ISolicitudesEspecialesService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SolicitudesEspecialesModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Solicitud especial registrada." });
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

        [HttpPatch("resolver/{id}")]
        public async Task<IActionResult> Resolve(int id, [FromBody] dynamic data)
        {
            try
            {
                string res = data.resolucion;
                string estado = data.estado;
                await _service.ResolverSolicitud(id, res, estado);
                return Ok(new { mensaje = "Solicitud procesada." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Solicitud eliminada físicamente." });
        }
    }
}