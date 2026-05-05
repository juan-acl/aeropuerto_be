using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class AuditoriasSeguridadService : IAuditoriasSeguridadService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public AuditoriasSeguridadService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<AuditoriasSeguridad>> ListarTodo()
        {
            try { return await _replica.AuditoriasSeguridad.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo AuditoriasSeguridad: {ex.Message}"); return new List<AuditoriasSeguridad>(); }
        }

        public async Task<AuditoriasSeguridad ?> ObtenerPorId(int id)
        {
            try { return await _replica.AuditoriasSeguridad.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId AuditoriasSeguridad: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(AuditoriasSeguridad m)
        {
            try
            {
                string sql = "BEGIN pkg_auditorias_seguridad.insert_auditoria(:p_fecha_auditoria, :p_tipo_auditoria, :p_entidad_auditora, :p_alcance, :p_hallazgos, :p_recomendaciones, :p_fecha_cierre, :p_responsable_cierre, :p_documento_auditoria, :p_estado); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_fecha_auditoria", (object?)m.FechaAuditoria ?? DBNull.Value),
                    new OracleParameter("p_tipo_auditoria", (object?)m.TipoAuditoria ?? DBNull.Value),
                    new OracleParameter("p_entidad_auditora", (object?)m.EntidadAuditora ?? DBNull.Value),
                    new OracleParameter("p_alcance", (object?)m.Alcance ?? DBNull.Value),
                    new OracleParameter("p_hallazgos", (object?)m.Hallazgos ?? DBNull.Value),
                    new OracleParameter("p_recomendaciones", (object?)m.Recomendaciones ?? DBNull.Value),
                    new OracleParameter("p_fecha_cierre", (object?)m.FechaCierre ?? DBNull.Value),
                    new OracleParameter("p_responsable_cierre", (object?)m.ResponsableCierre ?? DBNull.Value),
                    new OracleParameter("p_documento_auditoria", (object?)m.DocumentoAuditoria ?? DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar AuditoriasSeguridad: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, AuditoriasSeguridad m)
        {
            try
            {
                string sql = "BEGIN pkg_auditorias_seguridad.update_auditoria(:p_id_auditoria_seguridad, :p_fecha_auditoria, :p_tipo_auditoria, :p_entidad_auditora, :p_alcance, :p_hallazgos, :p_recomendaciones, :p_fecha_cierre, :p_responsable_cierre, :p_documento_auditoria, :p_estado); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_auditoria_seguridad", id),
                    new OracleParameter("p_fecha_auditoria", (object?)m.FechaAuditoria ?? DBNull.Value),
                    new OracleParameter("p_tipo_auditoria", (object?)m.TipoAuditoria ?? DBNull.Value),
                    new OracleParameter("p_entidad_auditora", (object?)m.EntidadAuditora ?? DBNull.Value),
                    new OracleParameter("p_alcance", (object?)m.Alcance ?? DBNull.Value),
                    new OracleParameter("p_hallazgos", (object?)m.Hallazgos ?? DBNull.Value),
                    new OracleParameter("p_recomendaciones", (object?)m.Recomendaciones ?? DBNull.Value),
                    new OracleParameter("p_fecha_cierre", (object?)m.FechaCierre ?? DBNull.Value),
                    new OracleParameter("p_responsable_cierre", (object?)m.ResponsableCierre ?? DBNull.Value),
                    new OracleParameter("p_documento_auditoria", (object?)m.DocumentoAuditoria ?? DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar AuditoriasSeguridad: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_auditorias_seguridad.delete_auditoria(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar AuditoriasSeguridad: {ex.Message}"); throw; }
        }
    }
}
