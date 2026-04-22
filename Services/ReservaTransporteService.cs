using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ReservaTransporteService : IReservaTransporteService
    {
        private readonly DBContext _context;
        public ReservaTransporteService(DBContext context) => _context = context;

        public async Task<List<ReservasTransporteTerrestre>> ListarTodo()
        {
            try { return await _context.ReservasTransporte.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ReservasTransporteTerrestre: {ex.Message}"); return new List<ReservasTransporteTerrestre>(); }
        }

        public async Task<ReservasTransporteTerrestre?> ObtenerPorId(int id)
        {
            try { return await _context.ReservasTransporte.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ReservasTransporteTerrestre: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ReservasTransporteTerrestre m)
        {
            try
            {
                string sql = "BEGIN pkg_reservas_transporte.insert_reserva(:p_codigo_reserva_transporte, :p_id_pasajero, :p_id_ruta_transporte, :p_tipo_servicio, :p_fecha_reserva, :p_fecha_servicio, :p_hora_recogida, :p_lugar_recogida, :p_lugar_destino, :p_numero_pasajeros, :p_cantidad_maletas, :p_id_vuelo_asociado, :p_instrucciones_especiales, :p_estado_reserva, :p_precio_total, :p_moneda, :p_pagado); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_codigo_reserva_transporte", (object?)m.CodigoReservaTransporte ?? DBNull.Value),
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_id_ruta_transporte", m.IdRutaTransporte),
                new OracleParameter("p_tipo_servicio", (object?)m.TipoServicio ?? DBNull.Value),
                new OracleParameter("p_fecha_reserva", (object?)m.FechaReserva ?? DBNull.Value),
                new OracleParameter("p_fecha_servicio", m.FechaServicio),
                new OracleParameter("p_hora_recogida", m.HoraRecogida),
                new OracleParameter("p_lugar_recogida", (object?)m.LugarRecogida ?? DBNull.Value),
                new OracleParameter("p_lugar_destino", (object?)m.LugarDestino ?? DBNull.Value),
                new OracleParameter("p_numero_pasajeros", (object?)m.NumeroPasajeros ?? DBNull.Value),
                new OracleParameter("p_cantidad_maletas", (object?)m.CantidadMaletas ?? DBNull.Value),
                new OracleParameter("p_id_vuelo_asociado", (object?)m.IdVueloAsociado ?? DBNull.Value),
                new OracleParameter("p_instrucciones_especiales", (object?)m.InstruccionesEspeciales ?? DBNull.Value),
                new OracleParameter("p_estado_reserva", (object?)m.EstadoReserva ?? DBNull.Value),
                new OracleParameter("p_precio_total", (object?)m.PrecioTotal ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_pagado", (object?)m.Pagado ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ReservasTransporteTerrestre: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, ReservasTransporteTerrestre m)
        {
            try
            {
                string sql = "BEGIN pkg_reservas_transporte.update_reserva(:p_id_reserva_transporte, :p_codigo_reserva_transporte, :p_id_pasajero, :p_id_ruta_transporte, :p_tipo_servicio, :p_fecha_reserva, :p_fecha_servicio, :p_hora_recogida, :p_lugar_recogida, :p_lugar_destino, :p_numero_pasajeros, :p_cantidad_maletas, :p_id_vuelo_asociado, :p_instrucciones_especiales, :p_estado_reserva, :p_precio_total, :p_moneda, :p_pagado); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_reserva_transporte", id),
                new OracleParameter("p_codigo_reserva_transporte", (object?)m.CodigoReservaTransporte ?? DBNull.Value),
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_id_ruta_transporte", m.IdRutaTransporte),
                new OracleParameter("p_tipo_servicio", (object?)m.TipoServicio ?? DBNull.Value),
                new OracleParameter("p_fecha_reserva", (object?)m.FechaReserva ?? DBNull.Value),
                new OracleParameter("p_fecha_servicio", m.FechaServicio),
                new OracleParameter("p_hora_recogida", m.HoraRecogida),
                new OracleParameter("p_lugar_recogida", (object?)m.LugarRecogida ?? DBNull.Value),
                new OracleParameter("p_lugar_destino", (object?)m.LugarDestino ?? DBNull.Value),
                new OracleParameter("p_numero_pasajeros", (object?)m.NumeroPasajeros ?? DBNull.Value),
                new OracleParameter("p_cantidad_maletas", (object?)m.CantidadMaletas ?? DBNull.Value),
                new OracleParameter("p_id_vuelo_asociado", (object?)m.IdVueloAsociado ?? DBNull.Value),
                new OracleParameter("p_instrucciones_especiales", (object?)m.InstruccionesEspeciales ?? DBNull.Value),
                new OracleParameter("p_estado_reserva", (object?)m.EstadoReserva ?? DBNull.Value),
                new OracleParameter("p_precio_total", (object?)m.PrecioTotal ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_pagado", (object?)m.Pagado ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ReservasTransporteTerrestre: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_reservas_transporte.delete_reserva(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ReservasTransporteTerrestre: {ex.Message}"); return false; }
        }
    }
}
