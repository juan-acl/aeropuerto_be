using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class PlanesEmergenciaService : IPlanesEmergenciaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public PlanesEmergenciaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<PlanesEmergencia>> ListarTodo()
        {
            try { return await _replica.PlanesEmergencia.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PlanesEmergencia: {ex.Message}"); return new List<PlanesEmergencia>(); }
        }

        public async Task<PlanesEmergencia ?> ObtenerPorId(int id)
        {
            try { return await _replica.PlanesEmergencia.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PlanesEmergencia: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PlanesEmergencia m)
        {
            try
            {
                string sql = "BEGIN pkg_planes_emergencia.insert_plan(:p_codigo_plan, :p_nombre_plan, :p_tipo_emergencia, :p_nivel_activacion, :p_descripcion, :p_procedimiento, :p_responsable_activacion, :p_tiempo_respuesta_estimado, :p_recursos_requeridos, :p_version, :p_fecha_creacion, :p_fecha_ultima_revision, :p_fecha_proxima_revision, :p_documento_plan, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_codigo_plan", (object?)m.CodigoPlan ?? DBNull.Value),
                    new OracleParameter("p_nombre_plan", (object?)m.NombrePlan ?? DBNull.Value),
                    new OracleParameter("p_tipo_emergencia", (object?)m.TipoEmergencia ?? DBNull.Value),
                    new OracleParameter("p_nivel_activacion", (object?)m.NivelActivacion ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_procedimiento", (object?)m.Procedimiento ?? DBNull.Value),
                    new OracleParameter("p_responsable_activacion", (object?)m.ResponsableActivacion ?? DBNull.Value),
                    new OracleParameter("p_tiempo_respuesta_estimado", DBNull.Value),
                    new OracleParameter("p_recursos_requeridos", (object?)m.RecursosRequeridos ?? DBNull.Value),
                    new OracleParameter("p_version", (object?)m.Version ?? DBNull.Value),
                    new OracleParameter("p_fecha_creacion", (object?)m.FechaCreacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_ultima_revision", (object?)m.FechaUltimaRevision ?? DBNull.Value),
                    new OracleParameter("p_fecha_proxima_revision", (object?)m.FechaProximaRevision ?? DBNull.Value),
                    new OracleParameter("p_documento_plan", (object?)m.DocumentoPlan ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar PlanesEmergencia: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, PlanesEmergencia m)
        {
            try
            {
                string sql = "BEGIN pkg_planes_emergencia.update_plan(:p_id_plan_emergencia, :p_codigo_plan, :p_nombre_plan, :p_tipo_emergencia, :p_nivel_activacion, :p_descripcion, :p_procedimiento, :p_responsable_activacion, :p_tiempo_respuesta_estimado, :p_recursos_requeridos, :p_version, :p_fecha_creacion, :p_fecha_ultima_revision, :p_fecha_proxima_revision, :p_documento_plan, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_plan_emergencia", id),
                    new OracleParameter("p_codigo_plan", (object?)m.CodigoPlan ?? DBNull.Value),
                    new OracleParameter("p_nombre_plan", (object?)m.NombrePlan ?? DBNull.Value),
                    new OracleParameter("p_tipo_emergencia", (object?)m.TipoEmergencia ?? DBNull.Value),
                    new OracleParameter("p_nivel_activacion", (object?)m.NivelActivacion ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_procedimiento", (object?)m.Procedimiento ?? DBNull.Value),
                    new OracleParameter("p_responsable_activacion", (object?)m.ResponsableActivacion ?? DBNull.Value),
                    new OracleParameter("p_tiempo_respuesta_estimado", DBNull.Value),
                    new OracleParameter("p_recursos_requeridos", (object?)m.RecursosRequeridos ?? DBNull.Value),
                    new OracleParameter("p_version", (object?)m.Version ?? DBNull.Value),
                    new OracleParameter("p_fecha_creacion", (object?)m.FechaCreacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_ultima_revision", (object?)m.FechaUltimaRevision ?? DBNull.Value),
                    new OracleParameter("p_fecha_proxima_revision", (object?)m.FechaProximaRevision ?? DBNull.Value),
                    new OracleParameter("p_documento_plan", (object?)m.DocumentoPlan ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar PlanesEmergencia: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_planes_emergencia.delete_plan(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar PlanesEmergencia: {ex.Message}"); throw; }
        }
    }
}
