using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ReportesOaciService : IReportesOaciService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ReportesOaciService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ReportesOaci>> ListarTodo()
        {
            try { return await _replica.ReportesOaci.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ReportesOaci: {ex.Message}"); return new List<ReportesOaci>(); }
        }

        public async Task<ReportesOaci ?> ObtenerPorId(int id)
        {
            try { return await _replica.ReportesOaci.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ReportesOaci: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ReportesOaci m)
        {
            try
            {
                string sql = "BEGIN pkg_reportes_oaci.insert_reporte(:p_tipo_reporte, :p_periodo, :p_fecha_inicio_periodo, :p_fecha_fin_periodo, :p_fecha_envio, :p_contenido_reporte, :p_archivo_reporte, :p_estado, :p_enviado_por, :p_confirmacion_recibido, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_tipo_reporte", (object?)m.TipoReporte ?? DBNull.Value),
                    new OracleParameter("p_periodo", (object?)m.Periodo ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio_periodo", m.FechaInicioPeriodo),
                    new OracleParameter("p_fecha_fin_periodo", m.FechaFinPeriodo),
                    new OracleParameter("p_fecha_envio", (object?)m.FechaEnvio ?? DBNull.Value),
                    new OracleParameter("p_contenido_reporte", (object?)m.ContenidoReporte ?? DBNull.Value),
                    new OracleParameter("p_archivo_reporte", (object?)m.ArchivoReporte ?? DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_enviado_por", (object?)m.EnviadoPor ?? DBNull.Value),
                    new OracleParameter("p_confirmacion_recibido", (object?)m.ConfirmacionRecibido ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ReportesOaci: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, ReportesOaci m)
        {
            try
            {
                string sql = "BEGIN pkg_reportes_oaci.update_reporte(:p_id_reporte_oaci, :p_tipo_reporte, :p_periodo, :p_fecha_inicio_periodo, :p_fecha_fin_periodo, :p_fecha_envio, :p_contenido_reporte, :p_archivo_reporte, :p_estado, :p_enviado_por, :p_confirmacion_recibido, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_reporte_oaci", id),
                    new OracleParameter("p_tipo_reporte", (object?)m.TipoReporte ?? DBNull.Value),
                    new OracleParameter("p_periodo", (object?)m.Periodo ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio_periodo", m.FechaInicioPeriodo),
                    new OracleParameter("p_fecha_fin_periodo", m.FechaFinPeriodo),
                    new OracleParameter("p_fecha_envio", (object?)m.FechaEnvio ?? DBNull.Value),
                    new OracleParameter("p_contenido_reporte", (object?)m.ContenidoReporte ?? DBNull.Value),
                    new OracleParameter("p_archivo_reporte", (object?)m.ArchivoReporte ?? DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_enviado_por", (object?)m.EnviadoPor ?? DBNull.Value),
                    new OracleParameter("p_confirmacion_recibido", (object?)m.ConfirmacionRecibido ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ReportesOaci: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_reportes_oaci.delete_reporte(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ReportesOaci: {ex.Message}"); throw; }
        }
    }
}
