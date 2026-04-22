using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class QuejaTransporteService : IQuejaTransporteService
    {
        private readonly DBContext _context;
        public QuejaTransporteService(DBContext context) => _context = context;

        public async Task<List<QuejasTransporteTerrestre>> ListarTodo()
        {
            try { return await _context.QuejasTransporte.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo QuejasTransporteTerrestre: {ex.Message}"); return new List<QuejasTransporteTerrestre>(); }
        }

        public async Task<QuejasTransporteTerrestre?> ObtenerPorId(int id)
        {
            try { return await _context.QuejasTransporte.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId QuejasTransporteTerrestre: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(QuejasTransporteTerrestre m)
        {
            try
            {
                string sql = "BEGIN pkg_quejas_transporte.insert_queja(:p_id_reserva_transporte, :p_id_pasajero, :p_fecha_queja, :p_tipo_queja, :p_descripcion_queja, :p_evidencia, :p_estado, :p_fecha_resolucion, :p_resolucion, :p_compensacion_ofrecida, :p_resuelto_por, :p_satisfaccion_pasajero); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_reserva_transporte", m.IdReservaTransporte),
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_fecha_queja", (object?)m.FechaQueja ?? DBNull.Value),
                new OracleParameter("p_tipo_queja", (object?)m.TipoQueja ?? DBNull.Value),
                new OracleParameter("p_descripcion_queja", (object?)m.DescripcionQueja ?? DBNull.Value),
                new OracleParameter("p_evidencia", OracleDbType.Blob) { Value = (object?)m.Evidencia ?? DBNull.Value },
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                new OracleParameter("p_fecha_resolucion", (object?)m.FechaResolucion ?? DBNull.Value),
                new OracleParameter("p_resolucion", (object?)m.Resolucion ?? DBNull.Value),
                new OracleParameter("p_compensacion_ofrecida", (object?)m.CompensacionOfrecida ?? DBNull.Value),
                new OracleParameter("p_resuelto_por", (object?)m.ResueltoPor ?? DBNull.Value),
                new OracleParameter("p_satisfaccion_pasajero", (object?)m.SatisfaccionPasajero ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar QuejasTransporteTerrestre: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, QuejasTransporteTerrestre m)
        {
            try
            {
                string sql = "BEGIN pkg_quejas_transporte.update_queja(:p_id_queja_transporte, :p_id_reserva_transporte, :p_id_pasajero, :p_fecha_queja, :p_tipo_queja, :p_descripcion_queja, :p_evidencia, :p_estado, :p_fecha_resolucion, :p_resolucion, :p_compensacion_ofrecida, :p_resuelto_por, :p_satisfaccion_pasajero); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_queja_transporte", id),
                new OracleParameter("p_id_reserva_transporte", m.IdReservaTransporte),
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_fecha_queja", (object?)m.FechaQueja ?? DBNull.Value),
                new OracleParameter("p_tipo_queja", (object?)m.TipoQueja ?? DBNull.Value),
                new OracleParameter("p_descripcion_queja", (object?)m.DescripcionQueja ?? DBNull.Value),
                new OracleParameter("p_evidencia", OracleDbType.Blob) { Value = (object?)m.Evidencia ?? DBNull.Value },
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                new OracleParameter("p_fecha_resolucion", (object?)m.FechaResolucion ?? DBNull.Value),
                new OracleParameter("p_resolucion", (object?)m.Resolucion ?? DBNull.Value),
                new OracleParameter("p_compensacion_ofrecida", (object?)m.CompensacionOfrecida ?? DBNull.Value),
                new OracleParameter("p_resuelto_por", (object?)m.ResueltoPor ?? DBNull.Value),
                new OracleParameter("p_satisfaccion_pasajero", (object?)m.SatisfaccionPasajero ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar QuejasTransporteTerrestre: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_quejas_transporte.delete_queja(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar QuejasTransporteTerrestre: {ex.Message}"); return false; }
        }
    }
}
