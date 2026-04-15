using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VuelosController : ControllerBase
    {
        private readonly IVueloService _service;

        public VuelosController(IVueloService service)
        {
            _service = service;
        }

        /// <summary>GET /api/vuelos — Lista todos los vuelos, opcionalmente filtrando por origen, destino y fecha</summary>
        [HttpGet]
        public async Task<IActionResult> Listar(
            [FromQuery] string? origen,
            [FromQuery] string? destino,
            [FromQuery] DateTime? fecha)
        {
            try
            {
                List<VueloModel> lista;
                if (!string.IsNullOrEmpty(origen) || !string.IsNullOrEmpty(destino) || fecha.HasValue)
                    lista = await _service.BuscarPorRuta(origen ?? "", destino ?? "", fecha);
                else
                    lista = await _service.ListarTodo();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar vuelos: {ex.Message}");
            }
        }

        /// <summary>GET /api/vuelos/{id}</summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var vuelo = await _service.ObtenerPorId(id);
                if (vuelo == null) return NotFound($"Vuelo con ID {id} no encontrado.");
                return Ok(vuelo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener vuelo: {ex.Message}");
            }
        }

        /// <summary>GET /api/vuelos/estado/{estado} — Filtra por estado operativo</summary>
        [HttpGet("estado/{estado}")]
        public async Task<IActionResult> PorEstado(string estado)
        {
            try
            {
                var lista = await _service.ListarPorEstado(estado.ToUpper());
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al filtrar vuelos por estado: {ex.Message}");
            }
        }

        /// <summary>POST /api/vuelos — Crea un nuevo vuelo operacional</summary>
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] VueloModel modelo)
        {
            if (modelo == null) return BadRequest("Datos de vuelo inválidos.");
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Vuelo creado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear vuelo: {ex.Message}");
            }
        }

        /// <summary>PUT /api/vuelos/{id}/estado — Cambia el estado del vuelo (CANCELADO, EN_VUELO, etc.)</summary>
        [HttpPut("{id}/estado")]
        public async Task<IActionResult> ActualizarEstado(int id, [FromQuery] string estado, [FromQuery] string? motivo)
        {
            try
            {
                var result = await _service.ActualizarEstado(id, estado.ToUpper(), motivo);
                if (!result) return NotFound($"Vuelo {id} no encontrado.");
                return Ok(new { mensaje = $"Estado del vuelo {id} actualizado a {estado}." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar estado: {ex.Message}");
            }
        }

        /// <summary>PUT /api/vuelos/{id}/horas — Registra horas reales de salida y llegada</summary>
        [HttpPut("{id}/horas")]
        public async Task<IActionResult> ActualizarHoras(int id, [FromQuery] DateTime? horaSalidaReal, [FromQuery] DateTime? horaLlegadaReal)
        {
            try
            {
                await _service.ActualizarHoraReal(id, horaSalidaReal, horaLlegadaReal);
                return Ok(new { mensaje = $"Horas reales del vuelo {id} actualizadas." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar horas: {ex.Message}");
            }
        }

        /// <summary>DELETE /api/vuelos/{id}</summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _service.Eliminar(id);
                return Ok(new { mensaje = $"Vuelo {id} eliminado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar vuelo: {ex.Message}");
            }
        }
    }
}
