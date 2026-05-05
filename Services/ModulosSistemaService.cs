using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ModulosSistemaService : IModulosSistemaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ModulosSistemaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ModulosSistema>> ListarTodo()
        {
            try { return await _replica.ModulosSistema.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ModulosSistema: {ex.Message}"); return new List<ModulosSistema>(); }
        }

        public async Task<ModulosSistema ?> ObtenerPorId(int id)
        {
            try { return await _replica.ModulosSistema.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ModulosSistema: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ModulosSistema m)
        {
            try
            {
                string sql = "BEGIN pkg_modulos_sistema.insert_modulo(:p_nombre_modulo, :p_descripcion, :p_ruta_acceso, :p_icono, :p_orden, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_nombre_modulo", (object?)m.NombreModulo ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_ruta_acceso", (object?)m.RutaAcceso ?? DBNull.Value),
                    new OracleParameter("p_icono", (object?)m.Icono ?? DBNull.Value),
                    new OracleParameter("p_orden", (object?)m.Orden ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ModulosSistema: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, ModulosSistema m)
        {
            try
            {
                string sql = "BEGIN pkg_modulos_sistema.update_modulo(:p_id_modulo_sistema, :p_nombre_modulo, :p_descripcion, :p_ruta_acceso, :p_icono, :p_orden, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_modulo_sistema", id),
                    new OracleParameter("p_nombre_modulo", (object?)m.NombreModulo ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_ruta_acceso", (object?)m.RutaAcceso ?? DBNull.Value),
                    new OracleParameter("p_icono", (object?)m.Icono ?? DBNull.Value),
                    new OracleParameter("p_orden", (object?)m.Orden ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ModulosSistema: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_modulos_sistema.delete_modulo(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ModulosSistema: {ex.Message}"); throw; }
        }
    }
}
