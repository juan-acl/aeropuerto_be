using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosSistemaController : ControllerBase
    {
        private readonly IUsuariosSistemaService _svc;
        public UsuariosSistemaController(IUsuariosSistemaService svc) { _svc = svc; }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _svc.ListarTodo();
            return Ok(items.Select(ToSafeResponse));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _svc.ObtenerPorId(id);
            return item == null ? NotFound() : Ok(ToSafeResponse(item));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuariosSistema m)
        {
            await _svc.Insertar(m);
            return Ok(new { mensaje = "Registro creado correctamente." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuariosSistema m)
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

        private static object ToSafeResponse(UsuariosSistema item) => new
        {
            item.IdUsuarioSistema,
            item.IdEmpleado,
            item.NombreUsuario,
            item.EmailInstitucional,
            item.FechaCreacion,
            item.FechaUltimoAcceso,
            item.FechaVencimientoPassword,
            item.IntentosFallidos,
            item.Bloqueado,
            item.MotivoBloqueo,
            item.RequiereCambioPassword,
            item.Activo,
            item.CreadoPor
        };
    }
}
