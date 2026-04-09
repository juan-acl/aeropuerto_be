using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasObjetosController : ControllerBase
    {
        private readonly ICategoriasObjetosService _service;

        public CategoriasObjetosController(ICategoriasObjetosService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriasObjetosModel modelo)
        {
            try
            {
                await _service.RegistrarCategoria(modelo);
                return Ok(new { mensaje = "Categoría registrada exitosamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.ListarTodas();
            return Ok(result);
        }

        [HttpGet("activas")]
        public async Task<IActionResult> GetActivas()
        {
            // El frontend debe llamar a este endpoint para llenar sus listas desplegables
            var result = await _service.ListarActivas();
            return Ok(result);
        }

        [HttpPatch("{id}/desactivar")]
        public async Task<IActionResult> PatchDesactivar(int id)
        {
            await _service.DesactivarCategoria(id);
            return Ok(new { mensaje = "Categoría desactivada (Soft Delete)." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Categoría eliminada físicamente de la base de datos." });
        }
    }
}