using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalEmergenciaController : ControllerBase
    {
        private readonly IPersonalEmergenciaService _service;
        public PersonalEmergenciaController(IPersonalEmergenciaService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.ListarTodo());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.ObtenerPorId(id);
            return item != null ? Ok(item) : NotFound(new { mensaje = "No encontrado" });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonalEmergencia m)
            => await _service.Insertar(m) ? Ok(new { mensaje = "Creado" }) : BadRequest(new { mensaje = "Error al crear" });

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PersonalEmergencia m)
            => await _service.Actualizar(id, m) ? Ok(new { mensaje = "Actualizado" }) : BadRequest(new { mensaje = "Error al actualizar" });

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => await _service.Eliminar(id) ? Ok(new { mensaje = "Eliminado" }) : BadRequest(new { mensaje = "Error al eliminar" });
    }
}
