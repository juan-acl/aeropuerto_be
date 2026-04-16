using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class AtencionEspecialService : IAtencionEspecialService
    {
        private readonly DBContext _context;

        public AtencionEspecialService(DBContext context) => _context = context;

        public async Task<int> SolicitarAtencion(AtencionEspecialModel m)
        {
            var sql = @"INSERT INTO atencion_especial 
                        (id_pasajero, id_reserva, tipo_atencion, fecha_solicitud, observaciones) 
                        VALUES (:p_pas, :p_res, :p_tipo, SYSTIMESTAMP, :p_obs)
                        RETURNING id_atencion INTO :p_id_out";

            var idOutParam = new OracleParameter("p_id_out", OracleDbType.Int32, ParameterDirection.Output);

            var parametros = new[] {
                new OracleParameter("p_pas", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_res", (object?)m.IdReserva ?? DBNull.Value),
                new OracleParameter("p_tipo", m.TipoAtencion.ToUpper()),
                new OracleParameter("p_obs", (object?)m.Observaciones ?? DBNull.Value),
                idOutParam
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return Convert.ToInt32(idOutParam.Value.ToString());
        }

        public async Task<bool> AsignarAsistente(int idAtencion, string nombreAsistente)
        {
            var sql = @"UPDATE atencion_especial 
                        SET asistente_asignado = :p_asistente 
                        WHERE id_atencion = :p_id";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_asistente", nombreAsistente),
                new OracleParameter("p_id", idAtencion));

            return true;
        }

        public async Task<bool> FinalizarAtencion(int idAtencion, string? observaciones)
        {
            // Se marca la hora exacta en la que el servicio fue provisto y se añaden notas finales si existen
            var sql = @"UPDATE atencion_especial 
                        SET fecha_atencion = SYSTIMESTAMP,
                            observaciones = observaciones || ' | Cierre: ' || :p_obs 
                        WHERE id_atencion = :p_id";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_obs", (object?)observaciones ?? "Sin novedades"),
                new OracleParameter("p_id", idAtencion));

            return true;
        }

        public async Task<List<AtencionEspecialModel>> ListarPendientes()
        {
            // Las solicitudes pendientes son aquellas que aún no tienen una 'fecha_atencion' registrada
            return await _context.AtencionEspecial
                .Where(a => a.FechaAtencion == null)
                .OrderBy(a => a.FechaSolicitud)
                .ToListAsync();
        }

        public async Task<List<AtencionEspecialModel>> ListarPorReserva(int idReserva)
        {
            return await _context.AtencionEspecial
                .Where(a => a.IdReserva == idReserva)
                .OrderByDescending(a => a.FechaSolicitud)
                .ToListAsync();
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM atencion_especial WHERE id_atencion = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}