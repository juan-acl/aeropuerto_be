using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class QuejaTransporteService : IQuejaTransporteTerrestreService
    {
        private readonly DBContext _context;
        public QuejaTransporteService(DBContext context) => _context = context;

        public async Task<bool> Insertar(QuejasTransporteTerrestre m)
        {
            var p = new[] {
                new OracleParameter("p_id_reserva_transporte", (object?)m.IdReservaTransporte ?? DBNull.Value),
                new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_fecha_queja", (object?)m.FechaQueja ?? DBNull.Value),
                new OracleParameter("p_tipo_queja", (object?)m.TipoQueja ?? DBNull.Value),
                new OracleParameter("p_descripcion_queja", (object?)m.DescripcionQueja ?? DBNull.Value),
                new OracleParameter("p_evidencia", (object?)m.Evidencia ?? DBNull.Value),
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                new OracleParameter("p_fecha_resolucion", (object?)m.FechaResolucion ?? DBNull.Value),
                new OracleParameter("p_resolucion", (object?)m.Resolucion ?? DBNull.Value),
                new OracleParameter("p_compensacion_ofrecida", (object?)m.CompensacionOfrecida ?? DBNull.Value),
                new OracleParameter("p_resuelto_por", (object?)m.ResueltoPor ?? DBNull.Value),
                new OracleParameter("p_satisfaccion_pasajero", (object?)m.SatisfaccionPasajero ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_quejas_transporte.insert_queja(:p_id_reserva_transporte, :p_id_pasajero, :p_fecha_queja, :p_tipo_queja, :p_descripcion_queja, :p_evidencia, :p_estado, :p_fecha_resolucion, :p_resolucion, :p_compensacion_ofrecida, :p_resuelto_por, :p_satisfaccion_pasajero); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, QuejasTransporteTerrestre m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_queja_transporte", m.IdQuejaTransporte)
            };
            p.AddRange(new[] {
                new OracleParameter("p_id_reserva_transporte", (object?)m.IdReservaTransporte ?? DBNull.Value),
                new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_fecha_queja", (object?)m.FechaQueja ?? DBNull.Value),
                new OracleParameter("p_tipo_queja", (object?)m.TipoQueja ?? DBNull.Value),
                new OracleParameter("p_descripcion_queja", (object?)m.DescripcionQueja ?? DBNull.Value),
                new OracleParameter("p_evidencia", (object?)m.Evidencia ?? DBNull.Value),
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                new OracleParameter("p_fecha_resolucion", (object?)m.FechaResolucion ?? DBNull.Value),
                new OracleParameter("p_resolucion", (object?)m.Resolucion ?? DBNull.Value),
                new OracleParameter("p_compensacion_ofrecida", (object?)m.CompensacionOfrecida ?? DBNull.Value),
                new OracleParameter("p_resuelto_por", (object?)m.ResueltoPor ?? DBNull.Value),
                new OracleParameter("p_satisfaccion_pasajero", (object?)m.SatisfaccionPasajero ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_quejas_transporte.update_queja(:p_id_queja_transporte, :p_id_reserva_transporte, :p_id_pasajero, :p_fecha_queja, :p_tipo_queja, :p_descripcion_queja, :p_evidencia, :p_estado, :p_fecha_resolucion, :p_resolucion, :p_compensacion_ofrecida, :p_resuelto_por, :p_satisfaccion_pasajero); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_quejas_transporte.delete_queja(:p_id_queja_transporte); END;",
                new OracleParameter("p_id_queja_transporte", id));
            return true;
        }

        public async Task<List<QuejasTransporteTerrestre>> ListarTodo() => await _context.Set<QuejasTransporteTerrestre>().ToListAsync();

        public async Task<QuejasTransporteTerrestre?> ObtenerPorId(int id) => await _context.Set<QuejasTransporteTerrestre>().FindAsync(id);
    }
}
