using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class UsuarioSistemaService : IUsuarioSistemaService
    {
        private readonly DBContext _context;
        public UsuarioSistemaService(DBContext context) => _context = context;

        public async Task<List<UsuariosSistema>> ListarTodo()
        {
            try { return await _context.UsuariosSistema.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo UsuariosSistema: {ex.Message}"); return new List<UsuariosSistema>(); }
        }

        public async Task<UsuariosSistema?> ObtenerPorId(int id)
        {
            try { return await _context.UsuariosSistema.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId UsuariosSistema: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(UsuariosSistema m)
        {
            try
            {
                string sql = "BEGIN pkg_usuarios_sistema.insert_usuario(:p_id_empleado, :p_nombre_usuario, :p_password_hash, :p_email_institucional, :p_fecha_creacion, :p_fecha_ultimo_acceso, :p_fecha_vencimiento_password, :p_intentos_fallidos, :p_bloqueado, :p_motivo_bloqueo, :p_requiere_cambio_password, :p_activo, :p_creado_por); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_empleado", (object?)m.IdEmpleado ?? DBNull.Value),
                new OracleParameter("p_nombre_usuario", (object?)m.NombreUsuario ?? DBNull.Value),
                new OracleParameter("p_password_hash", (object?)m.PasswordHash ?? DBNull.Value),
                new OracleParameter("p_email_institucional", (object?)m.EmailInstitucional ?? DBNull.Value),
                new OracleParameter("p_fecha_creacion", (object?)m.FechaCreacion ?? DBNull.Value),
                new OracleParameter("p_fecha_ultimo_acceso", (object?)m.FechaUltimoAcceso ?? DBNull.Value),
                new OracleParameter("p_fecha_vencimiento_password", (object?)m.FechaVencimientoPassword ?? DBNull.Value),
                new OracleParameter("p_intentos_fallidos", (object?)m.IntentosFallidos ?? DBNull.Value),
                new OracleParameter("p_bloqueado", (object?)m.Bloqueado ?? DBNull.Value),
                new OracleParameter("p_motivo_bloqueo", (object?)m.MotivoBloqueo ?? DBNull.Value),
                new OracleParameter("p_requiere_cambio_password", (object?)m.RequiereCambioPassword ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
                new OracleParameter("p_creado_por", (object?)m.CreadoPor ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar UsuariosSistema: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, UsuariosSistema m)
        {
            try
            {
                string sql = "BEGIN pkg_usuarios_sistema.update_usuario(:p_id_usuario_sistema, :p_id_empleado, :p_nombre_usuario, :p_password_hash, :p_email_institucional, :p_fecha_creacion, :p_fecha_ultimo_acceso, :p_fecha_vencimiento_password, :p_intentos_fallidos, :p_bloqueado, :p_motivo_bloqueo, :p_requiere_cambio_password, :p_activo, :p_creado_por); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_usuario_sistema", id),
                new OracleParameter("p_id_empleado", (object?)m.IdEmpleado ?? DBNull.Value),
                new OracleParameter("p_nombre_usuario", (object?)m.NombreUsuario ?? DBNull.Value),
                new OracleParameter("p_password_hash", (object?)m.PasswordHash ?? DBNull.Value),
                new OracleParameter("p_email_institucional", (object?)m.EmailInstitucional ?? DBNull.Value),
                new OracleParameter("p_fecha_creacion", (object?)m.FechaCreacion ?? DBNull.Value),
                new OracleParameter("p_fecha_ultimo_acceso", (object?)m.FechaUltimoAcceso ?? DBNull.Value),
                new OracleParameter("p_fecha_vencimiento_password", (object?)m.FechaVencimientoPassword ?? DBNull.Value),
                new OracleParameter("p_intentos_fallidos", (object?)m.IntentosFallidos ?? DBNull.Value),
                new OracleParameter("p_bloqueado", (object?)m.Bloqueado ?? DBNull.Value),
                new OracleParameter("p_motivo_bloqueo", (object?)m.MotivoBloqueo ?? DBNull.Value),
                new OracleParameter("p_requiere_cambio_password", (object?)m.RequiereCambioPassword ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
                new OracleParameter("p_creado_por", (object?)m.CreadoPor ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar UsuariosSistema: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_usuarios_sistema.delete_usuario(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar UsuariosSistema: {ex.Message}"); return false; }
        }
    }
}
