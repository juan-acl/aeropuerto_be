using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class EncuestasPostVueloService : IEncuestasPostVueloService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public EncuestasPostVueloService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<EncuestasPostVuelo>> ListarTodo()
        {
            try { return await _replica.EncuestasPostVuelo.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo EncuestasPostVuelo: {ex.Message}"); return new List<EncuestasPostVuelo>(); }
        }

        public async Task<EncuestasPostVuelo ?> ObtenerPorId(int id)
        {
            try { return await _replica.EncuestasPostVuelo.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId EncuestasPostVuelo: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(EncuestasPostVuelo m)
        {
            try
            {
                string sql = "BEGIN pkg_encuestas_post_vuelo.insert_encuesta(:p_id_vuelo, :p_id_pasajero, :p_fecha_encuesta, :p_canal_respuesta, :p_puntuacion_general, :p_puntuacion_checkin, :p_puntuacion_abordaje, :p_puntuacion_tripulacion, :p_puntuacion_comida, :p_puntuacion_confort, :p_puntuacion_puntualidad, :p_comentarios, :p_recomendaria, :p_nps_generado, :p_procesada); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_vuelo", m.IdVuelo),
                    new OracleParameter("p_id_pasajero", m.IdPasajero),
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
                    new OracleParameter("p_procesada", (object?)m.Procesada ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar EncuestasPostVuelo: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, EncuestasPostVuelo m)
        {
            try
            {
                string sql = "BEGIN pkg_encuestas_post_vuelo.update_encuesta(:p_id_encuesta_post_vuelo, :p_id_vuelo, :p_id_pasajero, :p_fecha_encuesta, :p_canal_respuesta, :p_puntuacion_general, :p_puntuacion_checkin, :p_puntuacion_abordaje, :p_puntuacion_tripulacion, :p_puntuacion_comida, :p_puntuacion_confort, :p_puntuacion_puntualidad, :p_comentarios, :p_recomendaria, :p_nps_generado, :p_procesada); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_encuesta_post_vuelo", id),
                    new OracleParameter("p_id_vuelo", m.IdVuelo),
                    new OracleParameter("p_id_pasajero", m.IdPasajero),
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
                    new OracleParameter("p_procesada", (object?)m.Procesada ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar EncuestasPostVuelo: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_encuestas_post_vuelo.delete_encuesta(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar EncuestasPostVuelo: {ex.Message}"); throw; }
        }
    }
}
