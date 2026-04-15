using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class EncuestaPostVueloService : IEncuestaPostVueloService
    {
        private readonly DBContext _context;
        public EncuestaPostVueloService(DBContext context) => _context = context;

        public async Task<bool> Insertar(EncuestasPostVuelo m)
        {
            var p = new[] {
                new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_fecha_encuesta", (object?)m.FechaEncuesta ?? DBNull.Value),
                new OracleParameter("p_canal_respuesta", (object?)m.CanalRespuesta ?? DBNull.Value),
                new OracleParameter("p_puntuacion_general", (object?)m.PuntuacionGeneral ?? DBNull.Value),
                new OracleParameter("p_puntuacion_checkin", (object?)m.PuntuacionCheckin ?? DBNull.Value),
                new OracleParameter("p_puntuacion_abordaje", (object?)m.PuntuacionAbordaje ?? DBNull.Value),
                new OracleParameter("p_puntuacion_tripulacion", (object?)m.PuntuacionTripulacion ?? DBNull.Value),
                new OracleParameter("p_puntuacion_comida", (object?)m.PuntuacionComida ?? DBNull.Value),
                new OracleParameter("p_puntuacion_confort", (object?)m.PuntuacionConfort ?? DBNull.Value),
                new OracleParameter("p_puntuacion_puntualidad", (object?)m.PuntuacionPuntualidad ?? DBNull.Value),
                new OracleParameter("p_comentarios", (object?)m.Comentarios ?? DBNull.Value),
                new OracleParameter("p_recomendaria", (object?)m.Recomendaria ?? DBNull.Value),
                new OracleParameter("p_nps_generado", (object?)m.NpsGenerado ?? DBNull.Value),
                new OracleParameter("p_procesada", (object?)m.Procesada ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_encuestas_post_vuelo.insert_encuesta(:p_id_vuelo, :p_id_pasajero, :p_fecha_encuesta, :p_canal_respuesta, :p_puntuacion_general, :p_puntuacion_checkin, :p_puntuacion_abordaje, :p_puntuacion_tripulacion, :p_puntuacion_comida, :p_puntuacion_confort, :p_puntuacion_puntualidad, :p_comentarios, :p_recomendaria, :p_nps_generado, :p_procesada); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, EncuestasPostVuelo m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_encuesta_post_vuelo", m.IdEncuestaPostVuelo)
            };
            p.AddRange(new[] {
                new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_fecha_encuesta", (object?)m.FechaEncuesta ?? DBNull.Value),
                new OracleParameter("p_canal_respuesta", (object?)m.CanalRespuesta ?? DBNull.Value),
                new OracleParameter("p_puntuacion_general", (object?)m.PuntuacionGeneral ?? DBNull.Value),
                new OracleParameter("p_puntuacion_checkin", (object?)m.PuntuacionCheckin ?? DBNull.Value),
                new OracleParameter("p_puntuacion_abordaje", (object?)m.PuntuacionAbordaje ?? DBNull.Value),
                new OracleParameter("p_puntuacion_tripulacion", (object?)m.PuntuacionTripulacion ?? DBNull.Value),
                new OracleParameter("p_puntuacion_comida", (object?)m.PuntuacionComida ?? DBNull.Value),
                new OracleParameter("p_puntuacion_confort", (object?)m.PuntuacionConfort ?? DBNull.Value),
                new OracleParameter("p_puntuacion_puntualidad", (object?)m.PuntuacionPuntualidad ?? DBNull.Value),
                new OracleParameter("p_comentarios", (object?)m.Comentarios ?? DBNull.Value),
                new OracleParameter("p_recomendaria", (object?)m.Recomendaria ?? DBNull.Value),
                new OracleParameter("p_nps_generado", (object?)m.NpsGenerado ?? DBNull.Value),
                new OracleParameter("p_procesada", (object?)m.Procesada ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_encuestas_post_vuelo.update_encuesta(:p_id_encuesta_post_vuelo, :p_id_vuelo, :p_id_pasajero, :p_fecha_encuesta, :p_canal_respuesta, :p_puntuacion_general, :p_puntuacion_checkin, :p_puntuacion_abordaje, :p_puntuacion_tripulacion, :p_puntuacion_comida, :p_puntuacion_confort, :p_puntuacion_puntualidad, :p_comentarios, :p_recomendaria, :p_nps_generado, :p_procesada); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_encuestas_post_vuelo.delete_encuesta(:p_id_encuesta_post_vuelo); END;", 
                new OracleParameter("p_id_encuesta_post_vuelo", id));
            return true;
        }

        public async Task<List<EncuestasPostVuelo>> ListarTodo() => await _context.Set<EncuestasPostVuelo>().ToListAsync();

        public async Task<EncuestasPostVuelo?> ObtenerPorId(int id) => await _context.Set<EncuestasPostVuelo>().FindAsync(id);
    }
}
