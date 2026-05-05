using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class EncuestasSatisfaccionService : IEncuestasSatisfaccionService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public EncuestasSatisfaccionService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<EncuestasSatisfaccionModel>> ListarTodo()
        {
            try { return await _replica.EncuestasSatisfaccion.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo EncuestasSatisfaccionModel: {ex.Message}"); return new List<EncuestasSatisfaccionModel>(); }
        }

        public async Task<EncuestasSatisfaccionModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.EncuestasSatisfaccion.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId EncuestasSatisfaccionModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(EncuestasSatisfaccionModel m)
        {
            try
            {
                string sql = "BEGIN pkg_encuestas_satisfaccion.insert_encuesta(:p_id_pasajero, :p_id_vuelo, :p_fecha_encuesta, :p_puntuacion_general, :p_puntuacion_checkin, :p_puntuacion_abordaje, :p_puntuacion_comodidad, :p_puntuacion_limpieza, :p_puntuacion_atencion, :p_puntuacion_equipaje, :p_comentarios, :p_recomienda); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                    new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                    new OracleParameter("p_fecha_encuesta", (object?)m.FechaEncuesta ?? DBNull.Value),
                    new OracleParameter("p_puntuacion_general", (object?)m.PuntuacionGeneral ?? DBNull.Value),
                    new OracleParameter("p_puntuacion_checkin", (object?)m.PuntuacionCheckin ?? DBNull.Value),
                    new OracleParameter("p_puntuacion_abordaje", (object?)m.PuntuacionAbordaje ?? DBNull.Value),
                    new OracleParameter("p_puntuacion_comodidad", (object?)m.PuntuacionComodidad ?? DBNull.Value),
                    new OracleParameter("p_puntuacion_limpieza", (object?)m.PuntuacionLimpieza ?? DBNull.Value),
                    new OracleParameter("p_puntuacion_atencion", (object?)m.PuntuacionAtencion ?? DBNull.Value),
                    new OracleParameter("p_puntuacion_equipaje", (object?)m.PuntuacionEquipaje ?? DBNull.Value),
                    new OracleParameter("p_comentarios", (object?)m.Comentarios ?? DBNull.Value),
                    new OracleParameter("p_recomienda", m.Recomienda)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar EncuestasSatisfaccionModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, EncuestasSatisfaccionModel m)
        {
            try
            {
                string sql = "BEGIN pkg_encuestas_satisfaccion.update_encuesta(:p_id_encuesta, :p_id_pasajero, :p_id_vuelo, :p_fecha_encuesta, :p_puntuacion_general, :p_puntuacion_checkin, :p_puntuacion_abordaje, :p_puntuacion_comodidad, :p_puntuacion_limpieza, :p_puntuacion_atencion, :p_puntuacion_equipaje, :p_comentarios, :p_recomienda); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_encuesta", id),
                    new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                    new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                    new OracleParameter("p_fecha_encuesta", (object?)m.FechaEncuesta ?? DBNull.Value),
                    new OracleParameter("p_puntuacion_general", (object?)m.PuntuacionGeneral ?? DBNull.Value),
                    new OracleParameter("p_puntuacion_checkin", (object?)m.PuntuacionCheckin ?? DBNull.Value),
                    new OracleParameter("p_puntuacion_abordaje", (object?)m.PuntuacionAbordaje ?? DBNull.Value),
                    new OracleParameter("p_puntuacion_comodidad", (object?)m.PuntuacionComodidad ?? DBNull.Value),
                    new OracleParameter("p_puntuacion_limpieza", (object?)m.PuntuacionLimpieza ?? DBNull.Value),
                    new OracleParameter("p_puntuacion_atencion", (object?)m.PuntuacionAtencion ?? DBNull.Value),
                    new OracleParameter("p_puntuacion_equipaje", (object?)m.PuntuacionEquipaje ?? DBNull.Value),
                    new OracleParameter("p_comentarios", (object?)m.Comentarios ?? DBNull.Value),
                    new OracleParameter("p_recomienda", m.Recomienda)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar EncuestasSatisfaccionModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_encuestas_satisfaccion.delete_encuesta(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar EncuestasSatisfaccionModel: {ex.Message}"); throw; }
        }
    }
}
