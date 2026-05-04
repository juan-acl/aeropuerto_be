using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ManifiestoCargaService : IManifiestoCargaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ManifiestoCargaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ManifiestoCarga>> ListarTodo()
        {
            try { return await _replica.MANIFIESTOS_CARGA.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ManifiestoCarga: {ex.Message}"); return new List<ManifiestoCarga>(); }
        }

        public async Task<ManifiestoCarga ?> ObtenerPorId(int id)
        {
            try { return await _replica.MANIFIESTOS_CARGA.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ManifiestoCarga: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ManifiestoCarga m)
        {
            try
            {
                string sql = "BEGIN pkg_manifiestos_carga.insert_manifiesto(:p_numero_manifiesto, :p_id_vuelo, :p_fecha_emision, :p_total_bultos, :p_peso_total_kg, :p_volumen_total_m3, :p_valor_total, :p_agente_carga, :p_documento_adjunto, :p_estado, :p_emitido_por); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_numero_manifiesto", DBNull.Value),
                    new OracleParameter("p_id_vuelo", m.IdVuelo),
                    new OracleParameter("p_fecha_emision", DBNull.Value),
                    new OracleParameter("p_total_bultos", DBNull.Value),
                    new OracleParameter("p_peso_total_kg", DBNull.Value),
                    new OracleParameter("p_volumen_total_m3", DBNull.Value),
                    new OracleParameter("p_valor_total", DBNull.Value),
                    new OracleParameter("p_agente_carga", DBNull.Value),
                    new OracleParameter("p_documento_adjunto", DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_emitido_por", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ManifiestoCarga: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, ManifiestoCarga m)
        {
            try
            {
                string sql = "BEGIN pkg_manifiestos_carga.update_manifiesto(:p_id_manifiesto, :p_numero_manifiesto, :p_id_vuelo, :p_fecha_emision, :p_total_bultos, :p_peso_total_kg, :p_volumen_total_m3, :p_valor_total, :p_agente_carga, :p_documento_adjunto, :p_estado, :p_emitido_por); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_manifiesto", id),
                    new OracleParameter("p_numero_manifiesto", DBNull.Value),
                    new OracleParameter("p_id_vuelo", m.IdVuelo),
                    new OracleParameter("p_fecha_emision", DBNull.Value),
                    new OracleParameter("p_total_bultos", DBNull.Value),
                    new OracleParameter("p_peso_total_kg", DBNull.Value),
                    new OracleParameter("p_volumen_total_m3", DBNull.Value),
                    new OracleParameter("p_valor_total", DBNull.Value),
                    new OracleParameter("p_agente_carga", DBNull.Value),
                    new OracleParameter("p_documento_adjunto", DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_emitido_por", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ManifiestoCarga: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_manifiestos_carga.delete_manifiesto(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ManifiestoCarga: {ex.Message}"); throw; }
        }
    }
}
