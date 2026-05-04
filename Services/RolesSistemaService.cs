using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class RolesSistemaService : IRolesSistemaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public RolesSistemaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<RolesSistema>> ListarTodo()
        {
            try { return await _replica.RolesSistema.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo RolesSistema: {ex.Message}"); return new List<RolesSistema>(); }
        }

        public async Task<RolesSistema ?> ObtenerPorId(int id)
        {
            try { return await _replica.RolesSistema.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId RolesSistema: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(RolesSistema m)
        {
            try
            {
                string sql = "BEGIN pkg_roles_sistema.insert_rol(:p_nombre_rol, :p_descripcion, :p_nivel_jerarquico, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_nombre_rol", (object?)m.NombreRol ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_nivel_jerarquico", (object?)m.NivelJerarquico ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar RolesSistema: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, RolesSistema m)
        {
            try
            {
                string sql = "BEGIN pkg_roles_sistema.update_rol(:p_id_rol_sistema, :p_nombre_rol, :p_descripcion, :p_nivel_jerarquico, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_rol_sistema", id),
                    new OracleParameter("p_nombre_rol", (object?)m.NombreRol ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_nivel_jerarquico", (object?)m.NivelJerarquico ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar RolesSistema: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_roles_sistema.delete_rol(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar RolesSistema: {ex.Message}"); throw; }
        }
    }
}
