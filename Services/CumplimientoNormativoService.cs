using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class CumplimientoNormativoService : ICumplimientoNormativoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public CumplimientoNormativoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<CumplimientoNormativo>> ListarTodo()
        {
            try { return await _replica.CumplimientoNormativo.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo CumplimientoNormativo: {ex.Message}"); return new List<CumplimientoNormativo>(); }
        }

        public async Task<CumplimientoNormativo ?> ObtenerPorId(int id)
        {
            try { return await _replica.CumplimientoNormativo.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId CumplimientoNormativo: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(CumplimientoNormativo m)
        {
            try
            {
                string sql = "BEGIN pkg_cumplimiento_normativo.insert_cumplimiento(:p_id_normativa, :p_fecha_verificacion, :p_periodo_verificado, :p_responsable_verificacion, :p_cumplimiento_porcentaje, :p_hallazgos, :p_acciones_correctivas, :p_fecha_cierre_acciones, :p_evidencia_cumplimiento, :p_calificacion, :p_proxima_verificacion, :p_verificacion_completada); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_normativa", m.IdNormativa),
                    new OracleParameter("p_fecha_verificacion", (object?)m.FechaVerificacion ?? DBNull.Value),
                    new OracleParameter("p_periodo_verificado", (object?)m.PeriodoVerificado ?? DBNull.Value),
                    new OracleParameter("p_responsable_verificacion", m.ResponsableVerificacion),
                    new OracleParameter("p_cumplimiento_porcentaje", (object?)m.CumplimientoPorcentaje ?? DBNull.Value),
                    new OracleParameter("p_hallazgos", (object?)m.Hallazgos ?? DBNull.Value),
                    new OracleParameter("p_acciones_correctivas", (object?)m.AccionesCorrectivas ?? DBNull.Value),
                    new OracleParameter("p_fecha_cierre_acciones", (object?)m.FechaCierreAcciones ?? DBNull.Value),
                    new OracleParameter("p_evidencia_cumplimiento", (object?)m.EvidenciaCumplimiento ?? DBNull.Value),
                    new OracleParameter("p_calificacion", (object?)m.Calificacion ?? DBNull.Value),
                    new OracleParameter("p_proxima_verificacion", (object?)m.ProximaVerificacion ?? DBNull.Value),
                    new OracleParameter("p_verificacion_completada", (object?)m.VerificacionCompletada ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar CumplimientoNormativo: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, CumplimientoNormativo m)
        {
            try
            {
                string sql = "BEGIN pkg_cumplimiento_normativo.update_cumplimiento(:p_id_cumplimiento_normativo, :p_id_normativa, :p_fecha_verificacion, :p_periodo_verificado, :p_responsable_verificacion, :p_cumplimiento_porcentaje, :p_hallazgos, :p_acciones_correctivas, :p_fecha_cierre_acciones, :p_evidencia_cumplimiento, :p_calificacion, :p_proxima_verificacion, :p_verificacion_completada); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_cumplimiento_normativo", id),
                    new OracleParameter("p_id_normativa", m.IdNormativa),
                    new OracleParameter("p_fecha_verificacion", (object?)m.FechaVerificacion ?? DBNull.Value),
                    new OracleParameter("p_periodo_verificado", (object?)m.PeriodoVerificado ?? DBNull.Value),
                    new OracleParameter("p_responsable_verificacion", m.ResponsableVerificacion),
                    new OracleParameter("p_cumplimiento_porcentaje", (object?)m.CumplimientoPorcentaje ?? DBNull.Value),
                    new OracleParameter("p_hallazgos", (object?)m.Hallazgos ?? DBNull.Value),
                    new OracleParameter("p_acciones_correctivas", (object?)m.AccionesCorrectivas ?? DBNull.Value),
                    new OracleParameter("p_fecha_cierre_acciones", (object?)m.FechaCierreAcciones ?? DBNull.Value),
                    new OracleParameter("p_evidencia_cumplimiento", (object?)m.EvidenciaCumplimiento ?? DBNull.Value),
                    new OracleParameter("p_calificacion", (object?)m.Calificacion ?? DBNull.Value),
                    new OracleParameter("p_proxima_verificacion", (object?)m.ProximaVerificacion ?? DBNull.Value),
                    new OracleParameter("p_verificacion_completada", (object?)m.VerificacionCompletada ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar CumplimientoNormativo: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_cumplimiento_normativo.delete_cumplimiento(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar CumplimientoNormativo: {ex.Message}"); throw; }
        }
    }
}
