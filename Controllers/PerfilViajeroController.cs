using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PerfilesViajeroController : ControllerBase
	{
		private readonly IPerfilViajeroService _service;

		public PerfilesViajeroController(IPerfilViajeroService service) => _service = service;

		[HttpPost]
		public async Task<IActionResult> Crear([FromBody] PerfilViajeroModel modelo)
		{
			try
			{
				await _service.Insertar(modelo);
				return Ok(new { mensaje = "Perfil de viajero creado exitosamente." });
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error: {ex.Message}");
			}
		}

		[HttpGet("pasajero/{idPasajero}")]
		public async Task<IActionResult> GetByPasajero(int idPasajero)
		{
			var perfil = await _service.ObtenerPorPasajero(idPasajero);
			if (perfil == null) return NotFound("El pasajero no tiene un perfil asociado.");
			return Ok(perfil);
		}

		[HttpPatch("{id}/sumar-puntos")]
		public async Task<IActionResult> AddPoints(int id, [FromBody] int puntos)
		{
			await _service.SumarPuntos(id, puntos);
			return Ok(new { mensaje = $"{puntos} puntos sumados correctamente." });
		}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Eliminar(id);
            return Ok(new { mensaje = "Perfil desactivado." });
        }
    }
}