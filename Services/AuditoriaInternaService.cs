using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class AuditoriaInternaService : IAuditoriaInternaService
    {
        private readonly DBContext _context;
        public AuditoriaInternaService(DBContext context) => _context = context;

        public async Task<List<AuditoriasInternas>> ListarTodo()
        {
            try { return await _context.AuditoriasInternas.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo AuditoriasInternas: {ex.Message}"); return new List<AuditoriasInternas>(); }
        }

        public async Task<AuditoriasInternas?> ObtenerPorId(int id)
        {
            try { return await _context.AuditoriasInternas.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId AuditoriasInternas: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(AuditoriasInternas m)
        {
            try
            {
                string sql = "BEGIN pkg_auditorias_internas.insert_auditoria(:p_codigo_auditoria, :p_titulo, :p_tipo_auditoria, :p_alcance, :p_fecha_inicio_planeacion, :p_fecha_fin_planeacion, :p_fecha_inicio_ejecucion, :p_fecha_fin_ejecucion, :p_fecha_informe, :p_auditor_lider, :p_equipo_auditor, :p_areas_auditadas, :p_hallazgos, :p_no_conformidades, :p_oportunidades_mejora, :p_conclusiones, :p_informe_final, :p_estado); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_codigo_auditoria", (object?)m.CodigoAuditoria ?? DBNull.Value),
                new OracleParameter("p_titulo", (object?)m.Titulo ?? DBNull.Value),
                new OracleParameter("p_tipo_auditoria", (object?)m.TipoAuditoria ?? DBNull.Value),
                new OracleParameter("p_alcance", (object?)m.Alcance ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio_planeacion", (object?)m.FechaInicioPlaneacion ?? DBNull.Value),
                new OracleParameter("p_fecha_fin_planeacion", (object?)m.FechaFinPlaneacion ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio_ejecucion", (object?)m.FechaInicioEjecucion ?? DBNull.Value),
                new OracleParameter("p_fecha_fin_ejecucion", (object?)m.FechaFinEjecucion ?? DBNull.Value),
                new OracleParameter("p_fecha_informe", (object?)m.FechaInforme ?? DBNull.Value),
                new OracleParameter("p_auditor_lider", (object?)m.AuditorLider ?? DBNull.Value),
                new OracleParameter("p_equipo_auditor", (object?)m.EquipoAuditor ?? DBNull.Value),
                new OracleParameter("p_areas_auditadas", (object?)m.AreasAuditadas ?? DBNull.Value),
                new OracleParameter("p_hallazgos", (object?)m.Hallazgos ?? DBNull.Value),
                new OracleParameter("p_no_conformidades", (object?)m.NoConformidades ?? DBNull.Value),
                new OracleParameter("p_oportunidades_mejora", (object?)m.OportunidadesMejora ?? DBNull.Value),
                new OracleParameter("p_conclusiones", (object?)m.Conclusiones ?? DBNull.Value),
                new OracleParameter("p_informe_final", OracleDbType.Blob) { Value = (object?)m.InformeFinal ?? DBNull.Value },
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar AuditoriasInternas: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, AuditoriasInternas m)
        {
            try
            {
                string sql = "BEGIN pkg_auditorias_internas.update_auditoria(:p_id_auditoria_interna, :p_codigo_auditoria, :p_titulo, :p_tipo_auditoria, :p_alcance, :p_fecha_inicio_planeacion, :p_fecha_fin_planeacion, :p_fecha_inicio_ejecucion, :p_fecha_fin_ejecucion, :p_fecha_informe, :p_auditor_lider, :p_equipo_auditor, :p_areas_auditadas, :p_hallazgos, :p_no_conformidades, :p_oportunidades_mejora, :p_conclusiones, :p_informe_final, :p_estado); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_auditoria_interna", id),
                new OracleParameter("p_codigo_auditoria", (object?)m.CodigoAuditoria ?? DBNull.Value),
                new OracleParameter("p_titulo", (object?)m.Titulo ?? DBNull.Value),
                new OracleParameter("p_tipo_auditoria", (object?)m.TipoAuditoria ?? DBNull.Value),
                new OracleParameter("p_alcance", (object?)m.Alcance ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio_planeacion", (object?)m.FechaInicioPlaneacion ?? DBNull.Value),
                new OracleParameter("p_fecha_fin_planeacion", (object?)m.FechaFinPlaneacion ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio_ejecucion", (object?)m.FechaInicioEjecucion ?? DBNull.Value),
                new OracleParameter("p_fecha_fin_ejecucion", (object?)m.FechaFinEjecucion ?? DBNull.Value),
                new OracleParameter("p_fecha_informe", (object?)m.FechaInforme ?? DBNull.Value),
                new OracleParameter("p_auditor_lider", (object?)m.AuditorLider ?? DBNull.Value),
                new OracleParameter("p_equipo_auditor", (object?)m.EquipoAuditor ?? DBNull.Value),
                new OracleParameter("p_areas_auditadas", (object?)m.AreasAuditadas ?? DBNull.Value),
                new OracleParameter("p_hallazgos", (object?)m.Hallazgos ?? DBNull.Value),
                new OracleParameter("p_no_conformidades", (object?)m.NoConformidades ?? DBNull.Value),
                new OracleParameter("p_oportunidades_mejora", (object?)m.OportunidadesMejora ?? DBNull.Value),
                new OracleParameter("p_conclusiones", (object?)m.Conclusiones ?? DBNull.Value),
                new OracleParameter("p_informe_final", OracleDbType.Blob) { Value = (object?)m.InformeFinal ?? DBNull.Value },
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar AuditoriasInternas: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_auditorias_internas.delete_auditoria(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar AuditoriasInternas: {ex.Message}"); return false; }
        }
    }
}
