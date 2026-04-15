using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ReaccionPromocionService : IReaccionPromocionService
    {
        private readonly DBContext _context;
        public ReaccionPromocionService(DBContext context) => _context = context;

        public async Task<bool> Insertar(ReaccionesPromociones m)
        {
            var p = new[] {
                new OracleParameter("p_id_oferta_personalizada", (object?)m.IdOfertaPersonalizada ?? DBNull.Value),
                new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_fecha_reaccion", (object?)m.FechaReaccion ?? DBNull.Value),
                new OracleParameter("p_tipo_reaccion", (object?)m.TipoReaccion ?? DBNull.Value),
                new OracleParameter("p_canal", (object?)m.Canal ?? DBNull.Value),
                new OracleParameter("p_convertido_en_reserva", (object?)m.ConvertidoEnReserva ?? DBNull.Value),
                new OracleParameter("p_id_reserva", (object?)m.IdReserva ?? DBNull.Value),
                new OracleParameter("p_valor_conversion", (object?)m.ValorConversion ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_reacciones_promociones.insert_reaccion(:p_id_oferta_personalizada, :p_id_pasajero, :p_fecha_reaccion, :p_tipo_reaccion, :p_canal, :p_convertido_en_reserva, :p_id_reserva, :p_valor_conversion); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, ReaccionesPromociones m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_reaccion", m.IdReaccion)
            };
            p.AddRange(new[] {
                new OracleParameter("p_id_oferta_personalizada", (object?)m.IdOfertaPersonalizada ?? DBNull.Value),
                new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_fecha_reaccion", (object?)m.FechaReaccion ?? DBNull.Value),
                new OracleParameter("p_tipo_reaccion", (object?)m.TipoReaccion ?? DBNull.Value),
                new OracleParameter("p_canal", (object?)m.Canal ?? DBNull.Value),
                new OracleParameter("p_convertido_en_reserva", (object?)m.ConvertidoEnReserva ?? DBNull.Value),
                new OracleParameter("p_id_reserva", (object?)m.IdReserva ?? DBNull.Value),
                new OracleParameter("p_valor_conversion", (object?)m.ValorConversion ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_reacciones_promociones.update_reaccion(:p_id_reaccion, :p_id_oferta_personalizada, :p_id_pasajero, :p_fecha_reaccion, :p_tipo_reaccion, :p_canal, :p_convertido_en_reserva, :p_id_reserva, :p_valor_conversion); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_reacciones_promociones.delete_reaccion(:p_id_reaccion); END;", 
                new OracleParameter("p_id_reaccion", id));
            return true;
        }

        public async Task<List<ReaccionesPromociones>> ListarTodo() => await _context.Set<ReaccionesPromociones>().ToListAsync();

        public async Task<ReaccionesPromociones?> ObtenerPorId(int id) => await _context.Set<ReaccionesPromociones>().FindAsync(id);
    }
}
