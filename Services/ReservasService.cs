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
            var sql = "pkg_reservas.insert_reserva";

            var parametros = new[] {
                new OracleParameter("p_id_vuelo", m.IdVuelo),
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_codigo_reserva", m.CodigoReserva),
                new OracleParameter("p_tipo_tarifa", (object?)m.TipoTarifa ?? DBNull.Value),
                new OracleParameter("p_precio_pagado", m.PrecioPagado),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? "USD"),
                new OracleParameter("p_numero_asiento", (object?)m.NumeroAsiento ?? DBNull.Value),
                new OracleParameter("p_clase_servicio", (object?)m.ClaseServicio ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_vuelo, :p_id_pasajero, :p_codigo_reserva, :p_tipo_tarifa, :p_precio_pagado, :p_moneda, :p_numero_asiento, :p_clase_servicio); END;", parametros);
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
            var sql = "pkg_reservas.update_reserva";

            var parametros = new[] {
                new OracleParameter("p_id_reserva", id),
                new OracleParameter("p_estado_reserva", m.EstadoReserva),
                new OracleParameter("p_numero_asiento", (object?)m.NumeroAsiento ?? DBNull.Value),
                new OracleParameter("p_puerta_embarque_asignada", (object?)m.PuertaEmbarqueAsignada ?? DBNull.Value),
                new OracleParameter("p_checkin_realizado", m.CheckinRealizado)
            };

            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_reserva, :p_estado_reserva, :p_numero_asiento, :p_puerta_embarque_asignada, :p_checkin_realizado); END;", parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "pkg_reservas.delete_reserva";
            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_reserva); END;", new OracleParameter("p_id_reserva", id));
            return true;
        }
    }
}