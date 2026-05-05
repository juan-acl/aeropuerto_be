using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class RetrasosTiempoRealService : IRetrasosTiempoRealService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public RetrasosTiempoRealService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<RetrasosTiempoReal>> ListarTodo()
        {
            try { return await _replica.RetrasosTiempoReal.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo RetrasosTiempoReal: {ex.Message}"); return new List<RetrasosTiempoReal>(); }
        }

        public async Task<RetrasosTiempoReal ?> ObtenerPorId(int id)
        {
            try { return await _replica.RetrasosTiempoReal.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId RetrasosTiempoReal: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(RetrasosTiempoReal m)
        {
            try
            {
                string sql = "BEGIN pkg_retrasos_tiempo_real.insert_retraso(:p_id_vuelo, :p_fecha_hora_registro, :p_tipo_retraso, :p_causa_especifica, :p_minutos_retraso_actuales, :p_minutos_retraso_estimados, :p_impacto_global, :p_afecta_conexiones, :p_notificado_pasajeros, :p_actualizado_por, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_vuelo", m.IdVuelo),
                    new OracleParameter("p_fecha_hora_registro", (object?)m.FechaHoraRegistro ?? DBNull.Value),
                    new OracleParameter("p_tipo_retraso", (object?)m.TipoRetraso ?? DBNull.Value),
                    new OracleParameter("p_causa_especifica", (object?)m.CausaEspecifica ?? DBNull.Value),
                    new OracleParameter("p_minutos_retraso_actuales", (object?)m.MinutosRetrasoActuales ?? DBNull.Value),
                    new OracleParameter("p_minutos_retraso_estimados", (object?)m.MinutosRetrasoEstimados ?? DBNull.Value),
                    new OracleParameter("p_impacto_global", (object?)m.ImpactoGlobal ?? DBNull.Value),
                    new OracleParameter("p_afecta_conexiones", (object?)m.AfectaConexiones ?? DBNull.Value),
                    new OracleParameter("p_notificado_pasajeros", (object?)m.NotificadoPasajeros ?? DBNull.Value),
                    new OracleParameter("p_actualizado_por", (object?)m.ActualizadoPor ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar RetrasosTiempoReal: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, RetrasosTiempoReal m)
        {
            try
            {
                string sql = "BEGIN pkg_retrasos_tiempo_real.update_retraso(:p_id_retraso_tiempo_real, :p_id_vuelo, :p_fecha_hora_registro, :p_tipo_retraso, :p_causa_especifica, :p_minutos_retraso_actuales, :p_minutos_retraso_estimados, :p_impacto_global, :p_afecta_conexiones, :p_notificado_pasajeros, :p_actualizado_por, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_retraso_tiempo_real", id),
                    new OracleParameter("p_id_vuelo", m.IdVuelo),
                    new OracleParameter("p_fecha_hora_registro", (object?)m.FechaHoraRegistro ?? DBNull.Value),
                    new OracleParameter("p_tipo_retraso", (object?)m.TipoRetraso ?? DBNull.Value),
                    new OracleParameter("p_causa_especifica", (object?)m.CausaEspecifica ?? DBNull.Value),
                    new OracleParameter("p_minutos_retraso_actuales", (object?)m.MinutosRetrasoActuales ?? DBNull.Value),
                    new OracleParameter("p_minutos_retraso_estimados", (object?)m.MinutosRetrasoEstimados ?? DBNull.Value),
                    new OracleParameter("p_impacto_global", (object?)m.ImpactoGlobal ?? DBNull.Value),
                    new OracleParameter("p_afecta_conexiones", (object?)m.AfectaConexiones ?? DBNull.Value),
                    new OracleParameter("p_notificado_pasajeros", (object?)m.NotificadoPasajeros ?? DBNull.Value),
                    new OracleParameter("p_actualizado_por", (object?)m.ActualizadoPor ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar RetrasosTiempoReal: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_retrasos_tiempo_real.delete_retraso(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar RetrasosTiempoReal: {ex.Message}"); throw; }
        }
    }
}
