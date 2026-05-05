using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class TiendasVentasService : ITiendasVentasService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public TiendasVentasService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<TiendasVentasModel>> ListarTodo()
        {
            try { return await _replica.TiendasVentas.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo TiendasVentasModel: {ex.Message}"); return new List<TiendasVentasModel>(); }
        }

        public async Task<TiendasVentasModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.TiendasVentas.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId TiendasVentasModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(TiendasVentasModel m)
        {
            try
            {
                string sql = "BEGIN pkg_tiendas_ventas.insert_venta(:p_id_concesion, :p_fecha_venta, :p_id_reserva, :p_id_pasajero, :p_tipo_cliente, :p_subtotal, :p_impuestos, :p_total, :p_metodo_pago, :p_tarjeta_numero, :p_autorizado_por); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_concesion", (object?)m.IdConcesion ?? DBNull.Value),
                    new OracleParameter("p_fecha_venta", (object?)m.FechaVenta ?? DBNull.Value),
                    new OracleParameter("p_id_reserva", (object?)m.IdReserva ?? DBNull.Value),
                    new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                    new OracleParameter("p_tipo_cliente", (object?)m.TipoCliente ?? DBNull.Value),
                    new OracleParameter("p_subtotal", (object?)m.Subtotal ?? DBNull.Value),
                    new OracleParameter("p_impuestos", (object?)m.Impuestos ?? DBNull.Value),
                    new OracleParameter("p_total", (object?)m.Total ?? DBNull.Value),
                    new OracleParameter("p_metodo_pago", (object?)m.MetodoPago ?? DBNull.Value),
                    new OracleParameter("p_tarjeta_numero", (object?)m.TarjetaNumero ?? DBNull.Value),
                    new OracleParameter("p_autorizado_por", (object?)m.AutorizadoPor ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar TiendasVentasModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, TiendasVentasModel m)
        {
            try
            {
                string sql = "BEGIN pkg_tiendas_ventas.update_venta(:p_id_venta, :p_id_concesion, :p_fecha_venta, :p_id_reserva, :p_id_pasajero, :p_tipo_cliente, :p_subtotal, :p_impuestos, :p_total, :p_metodo_pago, :p_tarjeta_numero, :p_autorizado_por); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_venta", id),
                    new OracleParameter("p_id_concesion", (object?)m.IdConcesion ?? DBNull.Value),
                    new OracleParameter("p_fecha_venta", (object?)m.FechaVenta ?? DBNull.Value),
                    new OracleParameter("p_id_reserva", (object?)m.IdReserva ?? DBNull.Value),
                    new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                    new OracleParameter("p_tipo_cliente", (object?)m.TipoCliente ?? DBNull.Value),
                    new OracleParameter("p_subtotal", (object?)m.Subtotal ?? DBNull.Value),
                    new OracleParameter("p_impuestos", (object?)m.Impuestos ?? DBNull.Value),
                    new OracleParameter("p_total", (object?)m.Total ?? DBNull.Value),
                    new OracleParameter("p_metodo_pago", (object?)m.MetodoPago ?? DBNull.Value),
                    new OracleParameter("p_tarjeta_numero", (object?)m.TarjetaNumero ?? DBNull.Value),
                    new OracleParameter("p_autorizado_por", (object?)m.AutorizadoPor ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar TiendasVentasModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_tiendas_ventas.delete_venta(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar TiendasVentasModel: {ex.Message}"); throw; }
        }
    }
}
