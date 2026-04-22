using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class AuditoriaInternacionalService : IAuditoriaInternacionalService
    {
        private readonly DBContext _context;
        public AuditoriaInternacionalService(DBContext context) => _context = context;

        public async Task<List<AuditoriasInternacionales>> ListarTodo()
        {
            try { return await _context.AuditoriasInternacionales.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo AuditoriasInternacionales: {ex.Message}"); return new List<AuditoriasInternacionales>(); }
        }

        public async Task<AuditoriasInternacionales?> ObtenerPorId(int id)
        {
            try { return await _context.AuditoriasInternacionales.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId AuditoriasInternacionales: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(AuditoriasInternacionales m)
        {
            try
            {
                string sql = "BEGIN pkg_auditorias_internacionales.insert_auditoria(:p_entidad_auditora, :p_fecha_auditoria, :p_tipo_auditoria, :p_alcance, :p_auditores, :p_areas_auditadas, :p_hallazgos, :p_no_conformidades, :p_recomendaciones, :p_fecha_informe, :p_informe_auditoria, :p_plazo_correccion_dias, :p_fecha_cierre, :p_observaciones); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_entidad_auditora", (object?)m.EntidadAuditora ?? DBNull.Value),
                new OracleParameter("p_fecha_auditoria", m.FechaAuditoria),
                new OracleParameter("p_tipo_auditoria", (object?)m.TipoAuditoria ?? DBNull.Value),
                new OracleParameter("p_alcance", (object?)m.Alcance ?? DBNull.Value),
                new OracleParameter("p_auditores", (object?)m.Auditores ?? DBNull.Value),
                new OracleParameter("p_areas_auditadas", (object?)m.AreasAuditadas ?? DBNull.Value),
                new OracleParameter("p_hallazgos", (object?)m.Hallazgos ?? DBNull.Value),
                new OracleParameter("p_no_conformidades", (object?)m.NoConformidades ?? DBNull.Value),
                new OracleParameter("p_recomendaciones", (object?)m.Recomendaciones ?? DBNull.Value),
                new OracleParameter("p_fecha_informe", (object?)m.FechaInforme ?? DBNull.Value),
                new OracleParameter("p_informe_auditoria", OracleDbType.Blob) { Value = (object?)m.InformeAuditoria ?? DBNull.Value },
                new OracleParameter("p_plazo_correccion_dias", (object?)m.PlazoCorreccionDias ?? DBNull.Value),
                new OracleParameter("p_fecha_cierre", (object?)m.FechaCierre ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar AuditoriasInternacionales: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, AuditoriasInternacionales m)
        {
            try
            {
                string sql = "BEGIN pkg_auditorias_internacionales.update_auditoria(:p_id_auditoria_internacional, :p_entidad_auditora, :p_fecha_auditoria, :p_tipo_auditoria, :p_alcance, :p_auditores, :p_areas_auditadas, :p_hallazgos, :p_no_conformidades, :p_recomendaciones, :p_fecha_informe, :p_informe_auditoria, :p_plazo_correccion_dias, :p_fecha_cierre, :p_observaciones); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_auditoria_internacional", id),
                new OracleParameter("p_entidad_auditora", (object?)m.EntidadAuditora ?? DBNull.Value),
                new OracleParameter("p_fecha_auditoria", m.FechaAuditoria),
                new OracleParameter("p_tipo_auditoria", (object?)m.TipoAuditoria ?? DBNull.Value),
                new OracleParameter("p_alcance", (object?)m.Alcance ?? DBNull.Value),
                new OracleParameter("p_auditores", (object?)m.Auditores ?? DBNull.Value),
                new OracleParameter("p_areas_auditadas", (object?)m.AreasAuditadas ?? DBNull.Value),
                new OracleParameter("p_hallazgos", (object?)m.Hallazgos ?? DBNull.Value),
                new OracleParameter("p_no_conformidades", (object?)m.NoConformidades ?? DBNull.Value),
                new OracleParameter("p_recomendaciones", (object?)m.Recomendaciones ?? DBNull.Value),
                new OracleParameter("p_fecha_informe", (object?)m.FechaInforme ?? DBNull.Value),
                new OracleParameter("p_informe_auditoria", OracleDbType.Blob) { Value = (object?)m.InformeAuditoria ?? DBNull.Value },
                new OracleParameter("p_plazo_correccion_dias", (object?)m.PlazoCorreccionDias ?? DBNull.Value),
                new OracleParameter("p_fecha_cierre", (object?)m.FechaCierre ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar AuditoriasInternacionales: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_auditorias_internacionales.delete_auditoria(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar AuditoriasInternacionales: {ex.Message}"); return false; }
        }
    }
}
