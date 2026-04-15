using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ReporteOaciService : IReporteOaciService
    {
        private readonly DBContext _context;
        public ReporteOaciService(DBContext context) => _context = context;

        public async Task<bool> Insertar(ReportesOaci m)
        {
            var p = new[] {
                new OracleParameter("p_tipo_reporte", (object?)m.TipoReporte ?? DBNull.Value),
                new OracleParameter("p_periodo", (object?)m.Periodo ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio_periodo", (object?)m.FechaInicioPeriodo ?? DBNull.Value),
                new OracleParameter("p_fecha_fin_periodo", (object?)m.FechaFinPeriodo ?? DBNull.Value),
                new OracleParameter("p_fecha_envio", (object?)m.FechaEnvio ?? DBNull.Value),
                new OracleParameter("p_contenido_reporte", (object?)m.ContenidoReporte ?? DBNull.Value),
                new OracleParameter("p_archivo_reporte", (object?)m.ArchivoReporte ?? DBNull.Value),
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                new OracleParameter("p_enviado_por", (object?)m.EnviadoPor ?? DBNull.Value),
                new OracleParameter("p_confirmacion_recibido", (object?)m.ConfirmacionRecibido ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_reportes_oaci.insert_reporte(:p_tipo_reporte, :p_periodo, :p_fecha_inicio_periodo, :p_fecha_fin_periodo, :p_fecha_envio, :p_contenido_reporte, :p_archivo_reporte, :p_estado, :p_enviado_por, :p_confirmacion_recibido, :p_observaciones); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, ReportesOaci m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_reporte_oaci", m.IdReporteOaci)
            };
            p.AddRange(new[] {
                new OracleParameter("p_tipo_reporte", (object?)m.TipoReporte ?? DBNull.Value),
                new OracleParameter("p_periodo", (object?)m.Periodo ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio_periodo", (object?)m.FechaInicioPeriodo ?? DBNull.Value),
                new OracleParameter("p_fecha_fin_periodo", (object?)m.FechaFinPeriodo ?? DBNull.Value),
                new OracleParameter("p_fecha_envio", (object?)m.FechaEnvio ?? DBNull.Value),
                new OracleParameter("p_contenido_reporte", (object?)m.ContenidoReporte ?? DBNull.Value),
                new OracleParameter("p_archivo_reporte", (object?)m.ArchivoReporte ?? DBNull.Value),
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                new OracleParameter("p_enviado_por", (object?)m.EnviadoPor ?? DBNull.Value),
                new OracleParameter("p_confirmacion_recibido", (object?)m.ConfirmacionRecibido ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_reportes_oaci.update_reporte(:p_id_reporte_oaci, :p_tipo_reporte, :p_periodo, :p_fecha_inicio_periodo, :p_fecha_fin_periodo, :p_fecha_envio, :p_contenido_reporte, :p_archivo_reporte, :p_estado, :p_enviado_por, :p_confirmacion_recibido, :p_observaciones); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_reportes_oaci.delete_reporte(:p_id_reporte_oaci); END;", 
                new OracleParameter("p_id_reporte_oaci", id));
            return true;
        }

        public async Task<List<ReportesOaci>> ListarTodo() => await _context.Set<ReportesOaci>().ToListAsync();

        public async Task<ReportesOaci?> ObtenerPorId(int id) => await _context.Set<ReportesOaci>().FindAsync(id);
    }
}
