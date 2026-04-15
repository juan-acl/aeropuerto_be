using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramasVueloController : ControllerBase
    {
        private readonly IProgramaVueloService _service;

        public ProgramasVueloController(IProgramaVueloService service)
        {
            _service = service;
        }

        /// <summary>GET /api/programasvuelo — Lista todos los programas activos</summary>
        [HttpGet]
        public async Task<IActionResult> Listar(
            [FromQuery] string? origen,
            [FromQuery] string? destino)
        {
            try
            {
                List<ProgramaVueloModel> lista;
                if (!string.IsNullOrEmpty(origen) || !string.IsNullOrEmpty(destino))
                    lista = await _service.BuscarPorRuta(origen ?? "", destino ?? "");
                else
                    lista = await _service.ListarTodo();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar programas de vuelo: {ex.Message}");
            }
        }

        /// <summary>GET /api/programasvuelo/{id}</summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var p = await _service.ObtenerPorId(id);
                if (p == null) return NotFound($"Programa {id} no encontrado.");
                return Ok(p);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener programa: {ex.Message}");
            }
        }

        /// <summary>GET /api/programasvuelo/aerolinea/{id}</summary>
        [HttpGet("aerolinea/{idAerolinea}")]
        public async Task<IActionResult> PorAerolinea(int idAerolinea)
        {
            try
            {
                var lista = await _service.ListarPorAerolinea(idAerolinea);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>POST /api/programasvuelo</summary>
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ProgramaVueloModel modelo)
        {
            if (modelo == null) return BadRequest("Datos inválidos.");
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = $"Programa '{modelo.NumeroVuelo}' creado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear programa: {ex.Message}");
            }
        }

        /// <summary>PUT /api/programasvuelo/{id}</summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] ProgramaVueloModel modelo)
        {
            try
            {
                var result = await _service.Actualizar(id, modelo);
                if (!result) return NotFound($"Programa {id} no encontrado.");
                return Ok(new { mensaje = $"Programa {id} actualizado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar: {ex.Message}");
            }
        }

        /// <summary>DELETE /api/programasvuelo/{id} — Desactivación lógica</summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _service.Eliminar(id);
                return Ok(new { mensaje = $"Programa {id} desactivado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar: {ex.Message}");
            }
        }
    }
}
