using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class EvaluacionPostService : IEvaluacionPostEmergenciaService
    {
        private readonly DBContext _context;
        public EvaluacionPostService(DBContext context) => _context = context;

        public async Task<bool> Insertar(EvaluacionesPostEmergencia m)
        {
            var p = new[] {
                new OracleParameter("p_id_activacion", (object?)m.IdActivacion ?? DBNull.Value),
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
                new OracleParameter("p_fecha_seguimiento", (object?)m.FechaSeguimiento ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_evaluaciones_post.insert_evaluacion(:p_id_activacion, :p_fecha_evaluacion, :p_evaluador, :p_tiempo_respuesta_minutos, :p_eficacia_respuesta, :p_coordinacion, :p_recursos_utilizados, :p_puntos_fuertes, :p_areas_mejora, :p_acciones_recomendadas, :p_responsable_seguimiento, :p_fecha_seguimiento); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, EvaluacionesPostEmergencia m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_evaluacion_post", m.IdEvaluacionPost)
            };
            p.AddRange(new[] {
                new OracleParameter("p_id_activacion", (object?)m.IdActivacion ?? DBNull.Value),
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
                new OracleParameter("p_fecha_seguimiento", (object?)m.FechaSeguimiento ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_evaluaciones_post.update_evaluacion(:p_id_evaluacion_post, :p_id_activacion, :p_fecha_evaluacion, :p_evaluador, :p_tiempo_respuesta_minutos, :p_eficacia_respuesta, :p_coordinacion, :p_recursos_utilizados, :p_puntos_fuertes, :p_areas_mejora, :p_acciones_recomendadas, :p_responsable_seguimiento, :p_fecha_seguimiento); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_evaluaciones_post.delete_evaluacion(:p_id_evaluacion_post); END;", 
                new OracleParameter("p_id_evaluacion_post", id));
            return true;
        }

        public async Task<List<EvaluacionesPostEmergencia>> ListarTodo() => await _context.Set<EvaluacionesPostEmergencia>().ToListAsync();

        public async Task<EvaluacionesPostEmergencia?> ObtenerPorId(int id) => await _context.Set<EvaluacionesPostEmergencia>().FindAsync(id);
    }
}
