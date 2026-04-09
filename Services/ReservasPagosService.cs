using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ReservasPagosService : IReservasPagosService
    {
        private readonly DBContext _context;

        public ReservasPagosService(DBContext context) => _context = context;

        public async Task<bool> Insertar(ReservasPagosModel m)
        {
            var sql = @"INSERT INTO reservas_pagos 
                        (id_reserva, id_metodo_pago, monto, moneda, fecha_pago, codigo_transaccion, estado_pago, comprobante_pago) 
                        VALUES (:p_reserva, :p_metodo, :p_monto, :p_moneda, SYSTIMESTAMP, :p_codigo, :p_estado, :p_blob)";

            var parametros = new[] {
                new OracleParameter("p_reserva", m.IdReserva),
                new OracleParameter("p_metodo", m.IdMetodoPago),
                new OracleParameter("p_monto", m.Monto),
                new OracleParameter("p_moneda", m.Moneda),
                new OracleParameter("p_codigo", (object?)m.CodigoTransaccion ?? DBNull.Value),
                new OracleParameter("p_estado", m.EstadoPago),
                new OracleParameter("p_blob", (object?)m.ComprobantePago ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<ReservasPagosModel>> ListarPorReserva(int idReserva)
        {
            return await _context.ReservasPagos
                .Where(p => p.IdReserva == idReserva)
                .ToListAsync();
        }

        public async Task<bool> ActualizarEstado(int idPago, string nuevoEstado)
        {
            var sql = "UPDATE reservas_pagos SET estado_pago = :p_estado WHERE id_pago = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_estado", nuevoEstado),
                new OracleParameter("p_id", idPago));
            return true;
        }

        public async Task<bool> EliminarFisico(int idPago)
        {
            var sql = "DELETE FROM reservas_pagos WHERE id_pago = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", idPago));
            return true;
        }
    }
}