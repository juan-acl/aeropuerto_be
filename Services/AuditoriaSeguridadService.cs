using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class AuditoriaSeguridadService : IAuditoriaSeguridadService
    {
        private readonly DBContext _context;
        public AuditoriaSeguridadService(DBContext context) => _context = context;

        public async Task<bool> Insertar(AuditoriasSeguridad m)
        {
            var p = new[] {
                new OracleParameter("p_fecha_auditoria", (object?)m.FechaAuditoria ?? DBNull.Value),
                new OracleParameter("p_tipo_auditoria", (object?)m.TipoAuditoria ?? DBNull.Value),
                new OracleParameter("p_entidad_auditora", (object?)m.EntidadAuditora ?? DBNull.Value),
                new OracleParameter("p_alcance", (object?)m.Alcance ?? DBNull.Value),
                new OracleParameter("p_hallazgos", (object?)m.Hallazgos ?? DBNull.Value),
                new OracleParameter("p_recomendaciones", (object?)m.Recomendaciones ?? DBNull.Value),
                new OracleParameter("p_fecha_cierre", (object?)m.FechaCierre ?? DBNull.Value),
                new OracleParameter("p_responsable_cierre", (object?)m.ResponsableCierre ?? DBNull.Value),
                new OracleParameter("p_documento_auditoria", (object?)m.DocumentoAuditoria ?? DBNull.Value),
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_auditorias_seguridad.insert_auditoria(:p_fecha_auditoria, :p_tipo_auditoria, :p_entidad_auditora, :p_alcance, :p_hallazgos, :p_recomendaciones, :p_fecha_cierre, :p_responsable_cierre, :p_documento_auditoria, :p_estado); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, AuditoriasSeguridad m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_auditoria_seguridad", m.IdAuditoriaSeguridad)
            };
            p.AddRange(new[] {
                new OracleParameter("p_fecha_auditoria", (object?)m.FechaAuditoria ?? DBNull.Value),
                new OracleParameter("p_tipo_auditoria", (object?)m.TipoAuditoria ?? DBNull.Value),
                new OracleParameter("p_entidad_auditora", (object?)m.EntidadAuditora ?? DBNull.Value),
                new OracleParameter("p_alcance", (object?)m.Alcance ?? DBNull.Value),
                new OracleParameter("p_hallazgos", (object?)m.Hallazgos ?? DBNull.Value),
                new OracleParameter("p_recomendaciones", (object?)m.Recomendaciones ?? DBNull.Value),
                new OracleParameter("p_fecha_cierre", (object?)m.FechaCierre ?? DBNull.Value),
                new OracleParameter("p_responsable_cierre", (object?)m.ResponsableCierre ?? DBNull.Value),
                new OracleParameter("p_documento_auditoria", (object?)m.DocumentoAuditoria ?? DBNull.Value),
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_auditorias_seguridad.update_auditoria(:p_id_auditoria_seguridad, :p_fecha_auditoria, :p_tipo_auditoria, :p_entidad_auditora, :p_alcance, :p_hallazgos, :p_recomendaciones, :p_fecha_cierre, :p_responsable_cierre, :p_documento_auditoria, :p_estado); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_auditorias_seguridad.delete_auditoria(:p_id_auditoria_seguridad); END;",
                new OracleParameter("p_id_auditoria_seguridad", id));
            return true;
        }

        public async Task<List<AuditoriasSeguridad>> ListarTodo() => await _context.Set<AuditoriasSeguridad>().ToListAsync();

        public async Task<AuditoriasSeguridad?> ObtenerPorId(int id) => await _context.Set<AuditoriasSeguridad>().FindAsync(id);
    }
}
