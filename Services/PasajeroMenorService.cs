using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class PasajeroMenorService : IPasajeroMenorService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public PasajeroMenorService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<PasajeroMenor>> ListarTodo()
        {
            try { return await _replica.PASAJEROS_MENORES.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PasajeroMenor: {ex.Message}"); return new List<PasajeroMenor>(); }
        }

        public async Task<PasajeroMenor ?> ObtenerPorId(int id)
        {
            try { return await _replica.PASAJEROS_MENORES.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PasajeroMenor: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PasajeroMenor m)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_menores.insert_relacion(:p_id_menor, :p_id_acompanante, :p_tipo_relacion, :p_autorizado, :p_documento_autorizacion); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_menor", DBNull.Value),
                    new OracleParameter("p_id_acompanante", DBNull.Value),
                    new OracleParameter("p_tipo_relacion", DBNull.Value),
                    new OracleParameter("p_autorizado", DBNull.Value),
                    new OracleParameter("p_documento_autorizacion", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar PasajeroMenor: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, PasajeroMenor m)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_menores.update_relacion(:p_id_relacion, :p_id_menor, :p_id_acompanante, :p_tipo_relacion, :p_autorizado, :p_documento_autorizacion); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_relacion", id),
                    new OracleParameter("p_id_menor", DBNull.Value),
                    new OracleParameter("p_id_acompanante", DBNull.Value),
                    new OracleParameter("p_tipo_relacion", DBNull.Value),
                    new OracleParameter("p_autorizado", DBNull.Value),
                    new OracleParameter("p_documento_autorizacion", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar PasajeroMenor: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_menores.delete_relacion(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar PasajeroMenor: {ex.Message}"); throw; }
        }
    }
}
