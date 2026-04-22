using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class RolPermisoModuloService : IRolPermisoModuloService
    {
        private readonly DBContext _context;
        public RolPermisoModuloService(DBContext context) => _context = context;

        public async Task<List<RolesPermisosModulos>> ListarTodo()
        {
            try { return await _context.RolesPermisosModulos.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo RolesPermisosModulos: {ex.Message}"); return new List<RolesPermisosModulos>(); }
        }

        public async Task<RolesPermisosModulos?> ObtenerPorId(int id)
        {
            try { return await _context.RolesPermisosModulos.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId RolesPermisosModulos: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(RolesPermisosModulos m)
        {
            try
            {
                string sql = "BEGIN pkg_roles_permisos_modulos.insert_permiso(:p_id_rol_sistema, :p_id_modulo_sistema, :p_permiso_lectura, :p_permiso_escritura, :p_permiso_eliminacion, :p_permiso_ejecucion); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_rol_sistema", m.IdRolSistema),
                new OracleParameter("p_id_modulo_sistema", (object?)m.IdModuloSistema ?? DBNull.Value),
                new OracleParameter("p_permiso_lectura", (object?)m.PermisoLectura ?? DBNull.Value),
                new OracleParameter("p_permiso_escritura", (object?)m.PermisoEscritura ?? DBNull.Value),
                new OracleParameter("p_permiso_eliminacion", (object?)m.PermisoEliminacion ?? DBNull.Value),
                new OracleParameter("p_permiso_ejecucion", (object?)m.PermisoEjecucion ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar RolesPermisosModulos: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, RolesPermisosModulos m)
        {
            try
            {
                string sql = "BEGIN pkg_roles_permisos_modulos.update_permiso(:p_id_rol_sistema, :p_id_modulo_sistema, :p_permiso_lectura, :p_permiso_escritura, :p_permiso_eliminacion, :p_permiso_ejecucion); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_rol_sistema", id),
                new OracleParameter("p_id_modulo_sistema", (object?)m.IdModuloSistema ?? DBNull.Value),
                new OracleParameter("p_permiso_lectura", (object?)m.PermisoLectura ?? DBNull.Value),
                new OracleParameter("p_permiso_escritura", (object?)m.PermisoEscritura ?? DBNull.Value),
                new OracleParameter("p_permiso_eliminacion", (object?)m.PermisoEliminacion ?? DBNull.Value),
                new OracleParameter("p_permiso_ejecucion", (object?)m.PermisoEjecucion ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar RolesPermisosModulos: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_roles_permisos_modulos.delete_permiso(:p_id_rol_sistema); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_rol_sistema", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar RolesPermisosModulos: {ex.Message}"); return false; }
        }
    }
}
