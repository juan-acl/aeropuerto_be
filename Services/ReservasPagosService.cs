using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ReservasPagosService : IReservasPagosService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ReservasPagosService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ReservasPagosModel>> ListarTodo()
        {
            try { return await _replica.ReservasPagos.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ReservasPagosModel: {ex.Message}"); return new List<ReservasPagosModel>(); }
        }

        public async Task<ReservasPagosModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.ReservasPagos.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ReservasPagosModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ReservasPagosModel m)
        {
            try
            {
                string sql = "BEGIN pkg_reservas_pagos.insert_pago(:p_id_reserva, :p_id_metodo_pago, :p_monto, :p_moneda, :p_fecha_pago, :p_codigo_transaccion, :p_estado_pago, :p_comprobante_pago); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_reserva", m.IdReserva),
                    new OracleParameter("p_id_metodo_pago", m.IdMetodoPago),
                    new OracleParameter("p_monto", m.Monto),
                    new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                    new OracleParameter("p_fecha_pago", (object?)m.FechaPago ?? DBNull.Value),
                    new OracleParameter("p_codigo_transaccion", (object?)m.CodigoTransaccion ?? DBNull.Value),
                    new OracleParameter("p_estado_pago", (object?)m.EstadoPago ?? DBNull.Value),
                    new OracleParameter("p_comprobante_pago", (object?)m.ComprobantePago ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ReservasPagosModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, ReservasPagosModel m)
        {
            try
            {
                string sql = "BEGIN pkg_reservas_pagos.update_pago(:p_id_pago, :p_id_reserva, :p_id_metodo_pago, :p_monto, :p_moneda, :p_fecha_pago, :p_codigo_transaccion, :p_estado_pago, :p_comprobante_pago); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_pago", id),
                    new OracleParameter("p_id_reserva", m.IdReserva),
                    new OracleParameter("p_id_metodo_pago", m.IdMetodoPago),
                    new OracleParameter("p_monto", m.Monto),
                    new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                    new OracleParameter("p_fecha_pago", (object?)m.FechaPago ?? DBNull.Value),
                    new OracleParameter("p_codigo_transaccion", (object?)m.CodigoTransaccion ?? DBNull.Value),
                    new OracleParameter("p_estado_pago", (object?)m.EstadoPago ?? DBNull.Value),
                    new OracleParameter("p_comprobante_pago", (object?)m.ComprobantePago ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ReservasPagosModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_reservas_pagos.delete_pago(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ReservasPagosModel: {ex.Message}"); throw; }
        }
    }
}
