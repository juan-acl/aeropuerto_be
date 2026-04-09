using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class SolicitudesEspecialesService : ISolicitudesEspecialesService
    {
        private readonly DBContext _context;

        public SolicitudesEspecialesService(DBContext context) => _context = context;

        public async Task<bool> Insertar(SolicitudesEspecialesModel m)
        {
            var sql = @"INSERT INTO solicitudes_especiales 
                        (id_reserva, tipo_solicitud, descripcion, fecha_solicitud, estado_solicitud) 
                        VALUES (:p_res, :p_tipo, :p_desc, SYSTIMESTAMP, :p_estado)";

            var parametros = new[] {
                new OracleParameter("p_res", m.IdReserva),
                new OracleParameter("p_tipo", m.TipoSolicitud),
                new OracleParameter("p_desc", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_estado", m.EstadoSolicitud)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<SolicitudesEspecialesModel>> ListarPorReserva(int idReserva)
        {
            return await _context.SolicitudesEspeciales
                .Where(s => s.IdReserva == idReserva)
                .ToListAsync();
        }

        public async Task<bool> ResolverSolicitud(int id, string resolucion, string nuevoEstado)
        {
            var sql = @"UPDATE solicitudes_especiales 
                        SET resolucion = :p_res, 
                            estado_solicitud = :p_estado, 
                            fecha_resolucion = SYSTIMESTAMP 
                        WHERE id_solicitud = :p_id";

            var parametros = new[] {
                new OracleParameter("p_res", resolucion),
                new OracleParameter("p_estado", nuevoEstado),
                new OracleParameter("p_id", id)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM solicitudes_especiales WHERE id_solicitud = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}