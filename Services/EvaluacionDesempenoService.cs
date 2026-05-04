using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class EvaluacionDesempenoService : IEvaluacionDesempenoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public EvaluacionDesempenoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<EvaluacionDesempeno>> ListarTodo()
        {
            try { return await _replica.EVALUACIONES_DESEMPENO.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo EvaluacionDesempeno: {ex.Message}"); return new List<EvaluacionDesempeno>(); }
        }

        public async Task<EvaluacionDesempeno ?> ObtenerPorId(int id)
        {
            try { return await _replica.EVALUACIONES_DESEMPENO.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId EvaluacionDesempeno: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(EvaluacionDesempeno m)
        {
            try
            {
                string sql = "BEGIN pkg_evaluaciones_desempeno.insert_evaluacion(:p_id_empleado, :p_fecha_evaluacion, :p_evaluador_id, :p_periodo_evaluado, :p_puntuacion_total, :p_puntuacion_productividad, :p_puntuacion_calidad, :p_puntuacion_asistencia, :p_puntuacion_trabajo_equipo, :p_comentarios, :p_metas_futuras); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_empleado", m.IdEmpleado),
                    new OracleParameter("p_fecha_evaluacion", m.FechaEvaluacion),
                    new OracleParameter("p_evaluador_id", m.EvaluadorId),
                    new OracleParameter("p_periodo_evaluado", (object?)m.PeriodoEvaluado ?? DBNull.Value),
                    new OracleParameter("p_puntuacion_total", m.PuntuacionTotal),
                    new OracleParameter("p_puntuacion_productividad", m.PuntuacionProductividad),
                    new OracleParameter("p_puntuacion_calidad", m.PuntuacionCalidad),
                    new OracleParameter("p_puntuacion_asistencia", m.PuntuacionAsistencia),
                    new OracleParameter("p_puntuacion_trabajo_equipo", m.PuntuacionTrabajoEquipo),
                    new OracleParameter("p_comentarios", (object?)m.Comentarios ?? DBNull.Value),
                    new OracleParameter("p_metas_futuras", (object?)m.MetasFuturas ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar EvaluacionDesempeno: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, EvaluacionDesempeno m)
        {
            try
            {
                string sql = "BEGIN pkg_evaluaciones_desempeno.update_evaluacion(:p_id_evaluacion, :p_id_empleado, :p_fecha_evaluacion, :p_evaluador_id, :p_periodo_evaluado, :p_puntuacion_total, :p_puntuacion_productividad, :p_puntuacion_calidad, :p_puntuacion_asistencia, :p_puntuacion_trabajo_equipo, :p_comentarios, :p_metas_futuras); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_evaluacion", id),
                    new OracleParameter("p_id_empleado", m.IdEmpleado),
                    new OracleParameter("p_fecha_evaluacion", m.FechaEvaluacion),
                    new OracleParameter("p_evaluador_id", m.EvaluadorId),
                    new OracleParameter("p_periodo_evaluado", (object?)m.PeriodoEvaluado ?? DBNull.Value),
                    new OracleParameter("p_puntuacion_total", m.PuntuacionTotal),
                    new OracleParameter("p_puntuacion_productividad", m.PuntuacionProductividad),
                    new OracleParameter("p_puntuacion_calidad", m.PuntuacionCalidad),
                    new OracleParameter("p_puntuacion_asistencia", m.PuntuacionAsistencia),
                    new OracleParameter("p_puntuacion_trabajo_equipo", m.PuntuacionTrabajoEquipo),
                    new OracleParameter("p_comentarios", (object?)m.Comentarios ?? DBNull.Value),
                    new OracleParameter("p_metas_futuras", (object?)m.MetasFuturas ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar EvaluacionDesempeno: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_evaluaciones_desempeno.delete_evaluacion(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar EvaluacionDesempeno: {ex.Message}"); throw; }
        }
    }
}
