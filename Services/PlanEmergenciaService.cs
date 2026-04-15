using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PlanEmergenciaService : IPlanEmergenciaService
    {
        private readonly DBContext _context;
        public PlanEmergenciaService(DBContext context) => _context = context;

        public async Task<bool> Insertar(PlanesEmergencia m)
        {
            var p = new[] {
                new OracleParameter("p_codigo_plan", (object?)m.CodigoPlan ?? DBNull.Value),
                new OracleParameter("p_nombre_plan", (object?)m.NombrePlan ?? DBNull.Value),
                new OracleParameter("p_tipo_emergencia", (object?)m.TipoEmergencia ?? DBNull.Value),
                new OracleParameter("p_nivel_activacion", (object?)m.NivelActivacion ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_procedimiento", (object?)m.Procedimiento ?? DBNull.Value),
                new OracleParameter("p_responsable_activacion", (object?)m.ResponsableActivacion ?? DBNull.Value),
                new OracleParameter("p_tiempo_respuesta_estimado", (object?)m.TiempoRespuestaEstimadoMinutos ?? DBNull.Value),
                new OracleParameter("p_recursos_requeridos", (object?)m.RecursosRequeridos ?? DBNull.Value),
                new OracleParameter("p_version", (object?)m.Version ?? DBNull.Value),
                new OracleParameter("p_fecha_creacion", (object?)m.FechaCreacion ?? DBNull.Value),
                new OracleParameter("p_fecha_ultima_revision", (object?)m.FechaUltimaRevision ?? DBNull.Value),
                new OracleParameter("p_fecha_proxima_revision", (object?)m.FechaProximaRevision ?? DBNull.Value),
                new OracleParameter("p_documento_plan", (object?)m.DocumentoPlan ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_planes_emergencia.insert_plan(:p_codigo_plan, :p_nombre_plan, :p_tipo_emergencia, :p_nivel_activacion, :p_descripcion, :p_procedimiento, :p_responsable_activacion, :p_tiempo_respuesta_estimado, :p_recursos_requeridos, :p_version, :p_fecha_creacion, :p_fecha_ultima_revision, :p_fecha_proxima_revision, :p_documento_plan, :p_activo); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, PlanesEmergencia m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_plan_emergencia", m.IdPlanEmergencia)
            };
            p.AddRange(new[] {
                new OracleParameter("p_codigo_plan", (object?)m.CodigoPlan ?? DBNull.Value),
                new OracleParameter("p_nombre_plan", (object?)m.NombrePlan ?? DBNull.Value),
                new OracleParameter("p_tipo_emergencia", (object?)m.TipoEmergencia ?? DBNull.Value),
                new OracleParameter("p_nivel_activacion", (object?)m.NivelActivacion ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_procedimiento", (object?)m.Procedimiento ?? DBNull.Value),
                new OracleParameter("p_responsable_activacion", (object?)m.ResponsableActivacion ?? DBNull.Value),
                new OracleParameter("p_tiempo_respuesta_estimado", (object?)m.TiempoRespuestaEstimadoMinutos ?? DBNull.Value),
                new OracleParameter("p_recursos_requeridos", (object?)m.RecursosRequeridos ?? DBNull.Value),
                new OracleParameter("p_version", (object?)m.Version ?? DBNull.Value),
                new OracleParameter("p_fecha_creacion", (object?)m.FechaCreacion ?? DBNull.Value),
                new OracleParameter("p_fecha_ultima_revision", (object?)m.FechaUltimaRevision ?? DBNull.Value),
                new OracleParameter("p_fecha_proxima_revision", (object?)m.FechaProximaRevision ?? DBNull.Value),
                new OracleParameter("p_documento_plan", (object?)m.DocumentoPlan ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_planes_emergencia.update_plan(:p_id_plan_emergencia, :p_codigo_plan, :p_nombre_plan, :p_tipo_emergencia, :p_nivel_activacion, :p_descripcion, :p_procedimiento, :p_responsable_activacion, :p_tiempo_respuesta_estimado, :p_recursos_requeridos, :p_version, :p_fecha_creacion, :p_fecha_ultima_revision, :p_fecha_proxima_revision, :p_documento_plan, :p_activo); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_planes_emergencia.delete_plan(:p_id_plan_emergencia); END;",
                new OracleParameter("p_id_plan_emergencia", id));
            return true;
        }

        public async Task<List<PlanesEmergencia>> ListarTodo() => await _context.Set<PlanesEmergencia>().ToListAsync();

        public async Task<PlanesEmergencia?> ObtenerPorId(int id) => await _context.Set<PlanesEmergencia>().FindAsync(id);
    }
}
