using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ReaccionesPromocionesService : IReaccionesPromocionesService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ReaccionesPromocionesService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ReaccionesPromociones>> ListarTodo()
        {
            try { return await _replica.ReaccionesPromociones.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ReaccionesPromociones: {ex.Message}"); return new List<ReaccionesPromociones>(); }
        }

        public async Task<ReaccionesPromociones ?> ObtenerPorId(int id)
        {
            try { return await _replica.ReaccionesPromociones.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ReaccionesPromociones: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ReaccionesPromociones m)
        {
            try
            {
                string sql = "BEGIN pkg_reacciones_promociones.insert_reaccion(:p_id_oferta_personalizada, :p_id_pasajero, :p_fecha_reaccion, :p_tipo_reaccion, :p_canal, :p_convertido_en_reserva, :p_id_reserva, :p_valor_conversion); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_oferta_personalizada", m.IdOfertaPersonalizada),
                    new OracleParameter("p_id_pasajero", m.IdPasajero),
                    new OracleParameter("p_fecha_reaccion", (object?)m.FechaReaccion ?? DBNull.Value),
                    new OracleParameter("p_tipo_reaccion", (object?)m.TipoReaccion ?? DBNull.Value),
                    new OracleParameter("p_canal", (object?)m.Canal ?? DBNull.Value),
                    new OracleParameter("p_convertido_en_reserva", (object?)m.ConvertidoEnReserva ?? DBNull.Value),
                    new OracleParameter("p_id_reserva", (object?)m.IdReserva ?? DBNull.Value),
                    new OracleParameter("p_valor_conversion", (object?)m.ValorConversion ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ReaccionesPromociones: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, ReaccionesPromociones m)
        {
            try
            {
                string sql = "BEGIN pkg_reacciones_promociones.update_reaccion(:p_id_reaccion, :p_id_oferta_personalizada, :p_id_pasajero, :p_fecha_reaccion, :p_tipo_reaccion, :p_canal, :p_convertido_en_reserva, :p_id_reserva, :p_valor_conversion); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_reaccion", id),
                    new OracleParameter("p_id_oferta_personalizada", m.IdOfertaPersonalizada),
                    new OracleParameter("p_id_pasajero", m.IdPasajero),
                    new OracleParameter("p_fecha_reaccion", (object?)m.FechaReaccion ?? DBNull.Value),
                    new OracleParameter("p_tipo_reaccion", (object?)m.TipoReaccion ?? DBNull.Value),
                    new OracleParameter("p_canal", (object?)m.Canal ?? DBNull.Value),
                    new OracleParameter("p_convertido_en_reserva", (object?)m.ConvertidoEnReserva ?? DBNull.Value),
                    new OracleParameter("p_id_reserva", (object?)m.IdReserva ?? DBNull.Value),
                    new OracleParameter("p_valor_conversion", (object?)m.ValorConversion ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ReaccionesPromociones: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_reacciones_promociones.delete_reaccion(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ReaccionesPromociones: {ex.Message}"); throw; }
        }
    }
}
