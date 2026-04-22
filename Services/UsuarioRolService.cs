using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class UsuarioRolService : IUsuarioRolService
    {
        private readonly DBContext _context;
        public UsuarioRolService(DBContext context) => _context = context;

        public async Task<List<UsuariosRoles>> ListarTodo()
        {
            try { return await _context.UsuariosRoles.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo UsuariosRoles: {ex.Message}"); return new List<UsuariosRoles>(); }
        }

        public async Task<UsuariosRoles?> ObtenerPorId(int id)
        {
            try { return await _context.UsuariosRoles.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId UsuariosRoles: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(UsuariosRoles m)
        {
            try
            {
                string sql = "BEGIN pkg_usuarios_roles.insert_usuario_rol(:p_id_usuario_sistema, :p_id_rol_sistema, :p_fecha_asignacion, :p_asignado_por, :p_activo); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_usuario_sistema", m.IdUsuarioSistema),
                new OracleParameter("p_id_rol_sistema", (object?)m.IdRolSistema ?? DBNull.Value),
                new OracleParameter("p_fecha_asignacion", (object?)m.FechaAsignacion ?? DBNull.Value),
                new OracleParameter("p_asignado_por", (object?)m.AsignadoPor ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar UsuariosRoles: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, UsuariosRoles m)
        {
            try
            {
                string sql = "BEGIN pkg_usuarios_roles.update_usuario_rol(:p_id_usuario_sistema, :p_id_rol_sistema, :p_fecha_asignacion, :p_asignado_por, :p_activo); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_usuario_sistema", id),
                new OracleParameter("p_id_rol_sistema", (object?)m.IdRolSistema ?? DBNull.Value),
                new OracleParameter("p_fecha_asignacion", (object?)m.FechaAsignacion ?? DBNull.Value),
                new OracleParameter("p_asignado_por", (object?)m.AsignadoPor ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar UsuariosRoles: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_usuarios_roles.delete_usuario_rol(:p_id_usuario_sistema); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_usuario_sistema", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar UsuariosRoles: {ex.Message}"); return false; }
        }
    }
}
