using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class AutorizacionMenorService : IAutorizacionMenorService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public AutorizacionMenorService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<AutorizacionMenor>> ListarTodo()
        {
            try { return await _replica.AUTORIZACIONES_MENORES.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo AutorizacionMenor: {ex.Message}"); return new List<AutorizacionMenor>(); }
        }

        public async Task<AutorizacionMenor ?> ObtenerPorId(int id)
        {
            try { return await _replica.AUTORIZACIONES_MENORES.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId AutorizacionMenor: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(AutorizacionMenor m)
        {
            try
            {
                string sql = "BEGIN pkg_autorizaciones_menores.insert_autorizacion(:p_id_menor, :p_numero_autorizacion, :p_fecha_emision, :p_fecha_expiracion, :p_autoridad_emisora, :p_documento_autorizacion, :p_verificado); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_menor", DBNull.Value),
                    new OracleParameter("p_numero_autorizacion", DBNull.Value),
                    new OracleParameter("p_fecha_emision", m.FechaEmision),
                    new OracleParameter("p_fecha_expiracion", DBNull.Value),
                    new OracleParameter("p_autoridad_emisora", DBNull.Value),
                    new OracleParameter("p_documento_autorizacion", DBNull.Value),
                    new OracleParameter("p_verificado", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar AutorizacionMenor: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, AutorizacionMenor m)
        {
            try
            {
                string sql = "BEGIN pkg_autorizaciones_menores.update_autorizacion(:p_id_autorizacion_menor, :p_id_menor, :p_numero_autorizacion, :p_fecha_emision, :p_fecha_expiracion, :p_autoridad_emisora, :p_documento_autorizacion, :p_verificado); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_autorizacion_menor", id),
                    new OracleParameter("p_id_menor", DBNull.Value),
                    new OracleParameter("p_numero_autorizacion", DBNull.Value),
                    new OracleParameter("p_fecha_emision", m.FechaEmision),
                    new OracleParameter("p_fecha_expiracion", DBNull.Value),
                    new OracleParameter("p_autoridad_emisora", DBNull.Value),
                    new OracleParameter("p_documento_autorizacion", DBNull.Value),
                    new OracleParameter("p_verificado", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar AutorizacionMenor: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_autorizaciones_menores.delete_autorizacion(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar AutorizacionMenor: {ex.Message}"); throw; }
        }
    }
}
