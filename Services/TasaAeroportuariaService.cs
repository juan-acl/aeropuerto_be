using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class TasaAeroportuariaService : ITasaAeroportuariaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public TasaAeroportuariaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<TasaAeroportuaria>> ListarTodo()
        {
            try { return await _replica.TASAS_AEROPORTUARIAS.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo TasaAeroportuaria: {ex.Message}"); return new List<TasaAeroportuaria>(); }
        }

        public async Task<TasaAeroportuaria ?> ObtenerPorId(int id)
        {
            try { return await _replica.TASAS_AEROPORTUARIAS.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId TasaAeroportuaria: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(TasaAeroportuaria m)
        {
            try
            {
                string sql = "BEGIN pkg_tasas_aeroportuarias.insert_tasa(:p_nombre_tasa, :p_tipo_tasa, :p_monto, :p_moneda, :p_calculo_porcentaje, :p_aplica_a, :p_activa, :p_fecha_actualizacion); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_nombre_tasa", (object?)m.NombreTasa ?? DBNull.Value),
                    new OracleParameter("p_tipo_tasa", (object?)m.TipoTasa ?? DBNull.Value),
                    new OracleParameter("p_monto", m.Monto),
                    new OracleParameter("p_moneda", DBNull.Value),
                    new OracleParameter("p_calculo_porcentaje", DBNull.Value),
                    new OracleParameter("p_aplica_a", DBNull.Value),
                    new OracleParameter("p_activa", DBNull.Value),
                    new OracleParameter("p_fecha_actualizacion", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar TasaAeroportuaria: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, TasaAeroportuaria m)
        {
            try
            {
                string sql = "BEGIN pkg_tasas_aeroportuarias.update_tasa(:p_id_tasa, :p_nombre_tasa, :p_tipo_tasa, :p_monto, :p_moneda, :p_calculo_porcentaje, :p_aplica_a, :p_activa, :p_fecha_actualizacion); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_tasa", id),
                    new OracleParameter("p_nombre_tasa", (object?)m.NombreTasa ?? DBNull.Value),
                    new OracleParameter("p_tipo_tasa", (object?)m.TipoTasa ?? DBNull.Value),
                    new OracleParameter("p_monto", m.Monto),
                    new OracleParameter("p_moneda", DBNull.Value),
                    new OracleParameter("p_calculo_porcentaje", DBNull.Value),
                    new OracleParameter("p_aplica_a", DBNull.Value),
                    new OracleParameter("p_activa", DBNull.Value),
                    new OracleParameter("p_fecha_actualizacion", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar TasaAeroportuaria: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_tasas_aeroportuarias.delete_tasa(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar TasaAeroportuaria: {ex.Message}"); throw; }
        }
    }
}
