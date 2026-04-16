using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class TiendasVentasService : ITiendasVentasService
    {
        private readonly DBContext _context;

        public TiendasVentasService(DBContext context) => _context = context;

        public async Task<int> RegistrarVentaCabecera(TiendasVentasModel m)
        {
            // RETURNING INTO nos permite obtener el ID generado automáticamente para usarlo en el detalle
            var sql = @"INSERT INTO tiendas_ventas 
                        (id_concesion, fecha_venta, id_reserva, id_pasajero, tipo_cliente, 
                         subtotal, impuestos, total, metodo_pago, tarjeta_numero, autorizado_por) 
                        VALUES (:p_con, SYSTIMESTAMP, :p_res, :p_pas, :p_tipo, 
                                :p_sub, :p_imp, :p_tot, :p_metodo, :p_tarjeta, :p_aut)
                        RETURNING id_venta INTO :p_id_out";

            var idOutParam = new OracleParameter("p_id_out", OracleDbType.Int32, ParameterDirection.Output);

            var parametros = new[] {
                new OracleParameter("p_con", (object?)m.IdConcesion ?? DBNull.Value),
                new OracleParameter("p_res", (object?)m.IdReserva ?? DBNull.Value),
                new OracleParameter("p_pas", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_tipo", m.TipoCliente),
                new OracleParameter("p_sub", (object?)m.Subtotal ?? DBNull.Value),
                new OracleParameter("p_imp", (object?)m.Impuestos ?? DBNull.Value),
                new OracleParameter("p_tot", (object?)m.Total ?? DBNull.Value),
                new OracleParameter("p_metodo", (object?)m.MetodoPago ?? DBNull.Value),
                new OracleParameter("p_tarjeta", (object?)m.TarjetaNumero ?? DBNull.Value),
                new OracleParameter("p_aut", (object?)m.AutorizadoPor ?? DBNull.Value),
                idOutParam
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);

            // Retornamos el ID de la venta recién creada
            return Convert.ToInt32(idOutParam.Value.ToString());
        }

        public async Task<List<TiendasVentasModel>> ListarPorConcesion(int idConcesion)
        {
            return await _context.TiendasVentas
                .Where(v => v.IdConcesion == idConcesion)
                .OrderByDescending(v => v.FechaVenta)
                .ToListAsync();
        }

        public async Task<List<TiendasVentasModel>> ListarPorPasajero(int idPasajero)
        {
            return await _context.TiendasVentas
                .Where(v => v.IdPasajero == idPasajero)
                .OrderByDescending(v => v.FechaVenta)
                .ToListAsync();
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM tiendas_ventas WHERE id_venta = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}