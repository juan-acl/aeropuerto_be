using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquiposEmergenciaController : ControllerBase
    {
        private readonly IEquiposEmergenciaService _svc;
        public EquiposEmergenciaController(IEquiposEmergenciaService svc) { _svc = svc; }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _svc.ListarTodo());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _svc.ObtenerPorId(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EquiposEmergencia m)
        {
            await _svc.Insertar(m);
            return Ok(new { mensaje = "Registro creado correctamente." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EquiposEmergencia m)
        {
            await _svc.Actualizar(id, m);
            return Ok(new { mensaje = "Registro actualizado correctamente." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _svc.Eliminar(id);
            return Ok(new { mensaje = "Registro eliminado correctamente." });
        }
    }
}
