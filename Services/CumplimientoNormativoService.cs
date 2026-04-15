using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class CumplimientoNormativoService : ICumplimientoNormativoService
    {
        private readonly DBContext _context;
        public CumplimientoNormativoService(DBContext context) => _context = context;

        public async Task<bool> Insertar(CumplimientoNormativo m)
        {
            var p = new[] {
                new OracleParameter("p_id_normativa", (object?)m.IdNormativa ?? DBNull.Value),
                new OracleParameter("p_fecha_verificacion", (object?)m.FechaVerificacion ?? DBNull.Value),
                new OracleParameter("p_periodo_verificado", (object?)m.PeriodoVerificado ?? DBNull.Value),
                new OracleParameter("p_responsable_verificacion", (object?)m.ResponsableVerificacion ?? DBNull.Value),
                new OracleParameter("p_cumplimiento_porcentaje", (object?)m.CumplimientoPorcentaje ?? DBNull.Value),
                new OracleParameter("p_hallazgos", (object?)m.Hallazgos ?? DBNull.Value),
                new OracleParameter("p_acciones_correctivas", (object?)m.AccionesCorrectivas ?? DBNull.Value),
                new OracleParameter("p_fecha_cierre_acciones", (object?)m.FechaCierreAcciones ?? DBNull.Value),
                new OracleParameter("p_evidencia_cumplimiento", (object?)m.EvidenciaCumplimiento ?? DBNull.Value),
                new OracleParameter("p_calificacion", (object?)m.Calificacion ?? DBNull.Value),
                new OracleParameter("p_proxima_verificacion", (object?)m.ProximaVerificacion ?? DBNull.Value),
                new OracleParameter("p_verificacion_completada", (object?)m.VerificacionCompletada ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_cumplimiento_normativo.insert_cumplimiento(:p_id_normativa, :p_fecha_verificacion, :p_periodo_verificado, :p_responsable_verificacion, :p_cumplimiento_porcentaje, :p_hallazgos, :p_acciones_correctivas, :p_fecha_cierre_acciones, :p_evidencia_cumplimiento, :p_calificacion, :p_proxima_verificacion, :p_verificacion_completada); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, CumplimientoNormativo m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_cumplimiento_normativo", m.IdCumplimientoNormativo)
            };
            p.AddRange(new[] {
                new OracleParameter("p_id_normativa", (object?)m.IdNormativa ?? DBNull.Value),
                new OracleParameter("p_fecha_verificacion", (object?)m.FechaVerificacion ?? DBNull.Value),
                new OracleParameter("p_periodo_verificado", (object?)m.PeriodoVerificado ?? DBNull.Value),
                new OracleParameter("p_responsable_verificacion", (object?)m.ResponsableVerificacion ?? DBNull.Value),
                new OracleParameter("p_cumplimiento_porcentaje", (object?)m.CumplimientoPorcentaje ?? DBNull.Value),
                new OracleParameter("p_hallazgos", (object?)m.Hallazgos ?? DBNull.Value),
                new OracleParameter("p_acciones_correctivas", (object?)m.AccionesCorrectivas ?? DBNull.Value),
                new OracleParameter("p_fecha_cierre_acciones", (object?)m.FechaCierreAcciones ?? DBNull.Value),
                new OracleParameter("p_evidencia_cumplimiento", (object?)m.EvidenciaCumplimiento ?? DBNull.Value),
                new OracleParameter("p_calificacion", (object?)m.Calificacion ?? DBNull.Value),
                new OracleParameter("p_proxima_verificacion", (object?)m.ProximaVerificacion ?? DBNull.Value),
                new OracleParameter("p_verificacion_completada", (object?)m.VerificacionCompletada ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_cumplimiento_normativo.update_cumplimiento(:p_id_cumplimiento_normativo, :p_id_normativa, :p_fecha_verificacion, :p_periodo_verificado, :p_responsable_verificacion, :p_cumplimiento_porcentaje, :p_hallazgos, :p_acciones_correctivas, :p_fecha_cierre_acciones, :p_evidencia_cumplimiento, :p_calificacion, :p_proxima_verificacion, :p_verificacion_completada); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_cumplimiento_normativo.delete_cumplimiento(:p_id_cumplimiento_normativo); END;",
                new OracleParameter("p_id_cumplimiento_normativo", id));
            return true;
        }

        public async Task<List<CumplimientoNormativo>> ListarTodo() => await _context.Set<CumplimientoNormativo>().ToListAsync();

        public async Task<CumplimientoNormativo?> ObtenerPorId(int id) => await _context.Set<CumplimientoNormativo>().FindAsync(id);
    }
}
