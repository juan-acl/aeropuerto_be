using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class EvaluacionPostService : IEvaluacionPostService
    {
        private readonly DBContext _context;
        public EvaluacionPostService(DBContext context) => _context = context;

        public async Task<List<EvaluacionesPostEmergencia>> ListarTodo()
        {
            try { return await _context.EvaluacionesPostEmergencia.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo EvaluacionesPostEmergencia: {ex.Message}"); return new List<EvaluacionesPostEmergencia>(); }
        }

        public async Task<EvaluacionesPostEmergencia?> ObtenerPorId(int id)
        {
            try { return await _context.EvaluacionesPostEmergencia.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId EvaluacionesPostEmergencia: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(EvaluacionesPostEmergencia m)
        {
            try
            {
                string sql = "BEGIN pkg_evaluaciones_post.insert_evaluacion(:p_id_activacion, :p_fecha_evaluacion, :p_evaluador, :p_tiempo_respuesta_minutos, :p_eficacia_respuesta, :p_coordinacion, :p_recursos_utilizados, :p_puntos_fuertes, :p_areas_mejora, :p_acciones_recomendadas, :p_responsable_seguimiento, :p_fecha_seguimiento); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_activacion", m.IdActivacion),
                new OracleParameter("p_fecha_evaluacion", (object?)m.FechaEvaluacion ?? DBNull.Value),
                new OracleParameter("p_evaluador", (object?)m.Evaluador ?? DBNull.Value),
                new OracleParameter("p_tiempo_respuesta_minutos", (object?)m.TiempoRespuestaMinutos ?? DBNull.Value),
                new OracleParameter("p_eficacia_respuesta", (object?)m.EficaciaRespuesta ?? DBNull.Value),
                new OracleParameter("p_coordinacion", (object?)m.Coordinacion ?? DBNull.Value),
                new OracleParameter("p_recursos_utilizados", (object?)m.RecursosUtilizados ?? DBNull.Value),
                new OracleParameter("p_puntos_fuertes", (object?)m.PuntosFuertes ?? DBNull.Value),
                new OracleParameter("p_areas_mejora", (object?)m.AreasMejora ?? DBNull.Value),
                new OracleParameter("p_acciones_recomendadas", (object?)m.AccionesRecomendadas ?? DBNull.Value),
                new OracleParameter("p_responsable_seguimiento", (object?)m.ResponsableSeguimiento ?? DBNull.Value),
                new OracleParameter("p_fecha_seguimiento", (object?)m.FechaSeguimiento ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar EvaluacionesPostEmergencia: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, EvaluacionesPostEmergencia m)
        {
            try
            {
                string sql = "BEGIN pkg_evaluaciones_post.update_evaluacion(:p_id_evaluacion_post, :p_id_activacion, :p_fecha_evaluacion, :p_evaluador, :p_tiempo_respuesta_minutos, :p_eficacia_respuesta, :p_coordinacion, :p_recursos_utilizados, :p_puntos_fuertes, :p_areas_mejora, :p_acciones_recomendadas, :p_responsable_seguimiento, :p_fecha_seguimiento); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_evaluacion_post", id),
                new OracleParameter("p_id_activacion", m.IdActivacion),
                new OracleParameter("p_fecha_evaluacion", (object?)m.FechaEvaluacion ?? DBNull.Value),
                new OracleParameter("p_evaluador", (object?)m.Evaluador ?? DBNull.Value),
                new OracleParameter("p_tiempo_respuesta_minutos", (object?)m.TiempoRespuestaMinutos ?? DBNull.Value),
                new OracleParameter("p_eficacia_respuesta", (object?)m.EficaciaRespuesta ?? DBNull.Value),
                new OracleParameter("p_coordinacion", (object?)m.Coordinacion ?? DBNull.Value),
                new OracleParameter("p_recursos_utilizados", (object?)m.RecursosUtilizados ?? DBNull.Value),
                new OracleParameter("p_puntos_fuertes", (object?)m.PuntosFuertes ?? DBNull.Value),
                new OracleParameter("p_areas_mejora", (object?)m.AreasMejora ?? DBNull.Value),
                new OracleParameter("p_acciones_recomendadas", (object?)m.AccionesRecomendadas ?? DBNull.Value),
                new OracleParameter("p_responsable_seguimiento", (object?)m.ResponsableSeguimiento ?? DBNull.Value),
                new OracleParameter("p_fecha_seguimiento", (object?)m.FechaSeguimiento ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar EvaluacionesPostEmergencia: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_evaluaciones_post.delete_evaluacion(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar EvaluacionesPostEmergencia: {ex.Message}"); return false; }
        }
    }
}
