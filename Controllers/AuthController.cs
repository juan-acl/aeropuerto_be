using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Models;
using System.Threading.Tasks;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DBContext _context;

        public AuthController(DBContext context)
        {
            _context = context;
        }

        public class LoginRequest
        {
            public string Usuario { get; set; } = null!;
            public string Password { get; set; } = null!;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Usuario) || string.IsNullOrEmpty(request.Password))
                return BadRequest(new { mensaje = "Credenciales inválidas" });

            // Validación texto plano como acordado para facilitar los INSERT iniciales
            var user = await _context.UsuariosSistema
                .FirstOrDefaultAsync(u => u.NombreUsuario.ToLower() == request.Usuario.ToLower() 
                                          && u.PasswordHash == request.Password && u.Activo == 1);

            if (user != null)
            {
                var rolAsignado = await _context.UsuariosRoles
                    .FirstOrDefaultAsync(ur => ur.IdUsuarioSistema == user.IdUsuarioSistema);

                string nombreRol = "CLIENTE";
                decimal nivelJerarquico = 3; // Lector por defecto para evitar intrusiones
                if (rolAsignado != null)
                {
                    var rol = await _context.RolesSistema.FirstOrDefaultAsync(r => r.IdRolSistema == rolAsignado.IdRolSistema);
                    if (rol != null) {
                        nombreRol = rol.NombreRol;
                        nivelJerarquico = rol.NivelJerarquico ?? 3;
                    }
                }

                return Ok(new {
                    token = "ora-tk-" + Guid.NewGuid().ToString().Substring(0, 10),
                    usuario = new {
                        id = user.IdUsuarioSistema,
                        nombre = user.NombreUsuario,
                        apellido = "",
                        email = user.EmailInstitucional ?? "correo@aurora.aero",
                        rol = nombreRol,
                        jerarquia = nivelJerarquico,
                        avatar = nombreRol.Contains("ADMIN") || nivelJerarquico == 1 ? "shield-checkmark" : "person",
                        departamento = "Oracle DB"
                    }
                });
            }

            return Unauthorized(new { mensaje = "Usuario o contraseña incorrectos" });
        }
    }
}
