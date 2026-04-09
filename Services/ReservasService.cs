using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ReservasService : IReservasService
    {
        private readonly DBContext _context;

        public ReservasService(DBContext context) => _context = context;

        public async Task<bool> Insertar(ReservasModel m)
        {
            var sql = @"INSERT INTO reservas (id_vuelo, id_pasajero, codigo_reserva, tipo_tarifa, precio_pagado, moneda, numero_asiento, clase_servicio) 
                        VALUES (:p_vuelo, :p_pasajero, :p_codigo, :p_tarifa, :p_precio, :p_moneda, :p_asiento, :p_clase)";

            var parametros = new[] {
                new OracleParameter("p_vuelo", m.IdVuelo),
                new OracleParameter("p_pasajero", m.IdPasajero),
                new OracleParameter("p_codigo", m.CodigoReserva),
                new OracleParameter("p_tarifa", (object?)m.TipoTarifa ?? DBNull.Value),
                new OracleParameter("p_precio", m.PrecioPagado),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? "USD"),
                new OracleParameter("p_asiento", (object?)m.NumeroAsiento ?? DBNull.Value),
                new OracleParameter("p_clase", (object?)m.ClaseServicio ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<ReservasModel>> ListarPorPasajero(int idPasajero)
        {
            return await _context.Reservas
                .Where(r => r.IdPasajero == idPasajero)
                .ToListAsync();
        }

        public async Task<ReservasModel?> ObtenerPorCodigo(string codigo)
        {
            return await _context.Reservas
                .FirstOrDefaultAsync(r => r.CodigoReserva == codigo);
        }

        public async Task<bool> Actualizar(int id, ReservasModel m)
        {
            var sql = @"UPDATE reservas SET 
                        estado_reserva = :p_estado, numero_asiento = :p_asiento, 
                        puerta_embarque_asignada = :p_puerta, checkin_realizado = :p_checkin,
                        fecha_modificacion = SYSDATE 
                        WHERE id_reserva = :p_id";

            var parametros = new[] {
                new OracleParameter("p_estado", m.EstadoReserva),
                new OracleParameter("p_asiento", (object?)m.NumeroAsiento ?? DBNull.Value),
                new OracleParameter("p_puerta", (object?)m.PuertaEmbarqueAsignada ?? DBNull.Value),
                new OracleParameter("p_checkin", m.CheckinRealizado),
                new OracleParameter("p_id", id)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM reservas WHERE id_reserva = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}