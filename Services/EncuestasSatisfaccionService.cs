using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class EncuestasSatisfaccionService : IEncuestasSatisfaccionService
    {
        private readonly DBContext _context;

        public EncuestasSatisfaccionService(DBContext context) => _context = context;

        public async Task<int> RegistrarEncuesta(EncuestasSatisfaccionModel m)
        {
            var sql = @"INSERT INTO encuestas_satisfaccion 
                        (id_pasajero, id_vuelo, fecha_encuesta, puntuacion_general, 
                         puntuacion_checkin, puntuacion_abordaje, puntuacion_comodidad, 
                         puntuacion_limpieza, puntuacion_atencion, puntuacion_equipaje, 
                         comentarios, recomienda) 
                        VALUES (:p_pas, :p_vuelo, SYSTIMESTAMP, :p_gen, 
                                :p_chk, :p_abo, :p_com, 
                                :p_limp, :p_aten, :p_equi, 
                                :p_coment, :p_reco)
                        RETURNING id_encuesta INTO :p_id_out";

            var idOutParam = new OracleParameter("p_id_out", OracleDbType.Int32, ParameterDirection.Output);

            var parametros = new[] {
                new OracleParameter("p_pas", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                new OracleParameter("p_gen", (object?)m.PuntuacionGeneral ?? DBNull.Value),
                new OracleParameter("p_chk", (object?)m.PuntuacionCheckin ?? DBNull.Value),
                new OracleParameter("p_abo", (object?)m.PuntuacionAbordaje ?? DBNull.Value),
                new OracleParameter("p_com", (object?)m.PuntuacionComodidad ?? DBNull.Value),
                new OracleParameter("p_limp", (object?)m.PuntuacionLimpieza ?? DBNull.Value),
                new OracleParameter("p_aten", (object?)m.PuntuacionAtencion ?? DBNull.Value),
                new OracleParameter("p_equi", (object?)m.PuntuacionEquipaje ?? DBNull.Value),
                new OracleParameter("p_coment", (object?)m.Comentarios ?? DBNull.Value),
                new OracleParameter("p_reco", m.Recomienda),
                idOutParam
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return Convert.ToInt32(idOutParam.Value.ToString());
        }

        public async Task<List<EncuestasSatisfaccionModel>> ListarPorVuelo(int idVuelo)
        {
            return await _context.EncuestasSatisfaccion
                .Where(e => e.IdVuelo == idVuelo)
                .OrderByDescending(e => e.FechaEncuesta)
                .ToListAsync();
        }

        public async Task<object> ObtenerEstadisticasPorVuelo(int idVuelo)
        {
            // Agrupamos y calculamos los promedios de todas las encuestas de un vuelo específico
            var encuestas = await _context.EncuestasSatisfaccion
                .Where(e => e.IdVuelo == idVuelo)
                .ToListAsync();

            if (!encuestas.Any()) return new { mensaje = "No hay encuestas registradas para este vuelo." };

            return new
            {
                TotalEncuestas = encuestas.Count,
                PromedioGeneral = encuestas.Average(e => e.PuntuacionGeneral ?? 0).ToString("0.0"),
                PromedioCheckin = encuestas.Average(e => e.PuntuacionCheckin ?? 0).ToString("0.0"),
                PromedioAbordaje = encuestas.Average(e => e.PuntuacionAbordaje ?? 0).ToString("0.0"),
                PromedioComodidad = encuestas.Average(e => e.PuntuacionComodidad ?? 0).ToString("0.0"),
                PromedioLimpieza = encuestas.Average(e => e.PuntuacionLimpieza ?? 0).ToString("0.0"),
                PromedioAtencion = encuestas.Average(e => e.PuntuacionAtencion ?? 0).ToString("0.0"),
                PromedioEquipaje = encuestas.Average(e => e.PuntuacionEquipaje ?? 0).ToString("0.0"),
                PorcentajeRecomendacion = (encuestas.Count(e => e.Recomienda == 1) * 100.0 / encuestas.Count).ToString("0.0") + "%"
            };
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM encuestas_satisfaccion WHERE id_encuesta = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}