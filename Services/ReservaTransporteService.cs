using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ReservaTransporteService : IReservaTransporteTerrestreService
    {
        private readonly DBContext _context;
        public ReservaTransporteService(DBContext context) => _context = context;

        public async Task<bool> Insertar(ReservasTransporteTerrestre m)
        {
            var p = new[] {
                new OracleParameter("p_codigo_reserva_transporte", (object?)m.CodigoReservaTransporte ?? DBNull.Value),
                new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_id_ruta_transporte", (object?)m.IdRutaTransporte ?? DBNull.Value),
                new OracleParameter("p_tipo_servicio", (object?)m.TipoServicio ?? DBNull.Value),
                new OracleParameter("p_fecha_reserva", (object?)m.FechaReserva ?? DBNull.Value),
                new OracleParameter("p_fecha_servicio", (object?)m.FechaServicio ?? DBNull.Value),
                new OracleParameter("p_hora_recogida", (object?)m.HoraRecogida ?? DBNull.Value),
                new OracleParameter("p_lugar_recogida", (object?)m.LugarRecogida ?? DBNull.Value),
                new OracleParameter("p_lugar_destino", (object?)m.LugarDestino ?? DBNull.Value),
                new OracleParameter("p_numero_pasajeros", (object?)m.NumeroPasajeros ?? DBNull.Value),
                new OracleParameter("p_cantidad_maletas", (object?)m.CantidadMaletas ?? DBNull.Value),
                new OracleParameter("p_id_vuelo_asociado", (object?)m.IdVueloAsociado ?? DBNull.Value),
                new OracleParameter("p_instrucciones_especiales", (object?)m.InstruccionesEspeciales ?? DBNull.Value),
                new OracleParameter("p_estado_reserva", (object?)m.EstadoReserva ?? DBNull.Value),
                new OracleParameter("p_precio_total", (object?)m.PrecioTotal ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_pagado", (object?)m.Pagado ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_reservas_transporte.insert_reserva(:p_codigo_reserva_transporte, :p_id_pasajero, :p_id_ruta_transporte, :p_tipo_servicio, :p_fecha_reserva, :p_fecha_servicio, :p_hora_recogida, :p_lugar_recogida, :p_lugar_destino, :p_numero_pasajeros, :p_cantidad_maletas, :p_id_vuelo_asociado, :p_instrucciones_especiales, :p_estado_reserva, :p_precio_total, :p_moneda, :p_pagado); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, ReservasTransporteTerrestre m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_reserva_transporte", m.IdReservaTransporte)
            };
            p.AddRange(new[] {
                new OracleParameter("p_codigo_reserva_transporte", (object?)m.CodigoReservaTransporte ?? DBNull.Value),
                new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_id_ruta_transporte", (object?)m.IdRutaTransporte ?? DBNull.Value),
                new OracleParameter("p_tipo_servicio", (object?)m.TipoServicio ?? DBNull.Value),
                new OracleParameter("p_fecha_reserva", (object?)m.FechaReserva ?? DBNull.Value),
                new OracleParameter("p_fecha_servicio", (object?)m.FechaServicio ?? DBNull.Value),
                new OracleParameter("p_hora_recogida", (object?)m.HoraRecogida ?? DBNull.Value),
                new OracleParameter("p_lugar_recogida", (object?)m.LugarRecogida ?? DBNull.Value),
                new OracleParameter("p_lugar_destino", (object?)m.LugarDestino ?? DBNull.Value),
                new OracleParameter("p_numero_pasajeros", (object?)m.NumeroPasajeros ?? DBNull.Value),
                new OracleParameter("p_cantidad_maletas", (object?)m.CantidadMaletas ?? DBNull.Value),
                new OracleParameter("p_id_vuelo_asociado", (object?)m.IdVueloAsociado ?? DBNull.Value),
                new OracleParameter("p_instrucciones_especiales", (object?)m.InstruccionesEspeciales ?? DBNull.Value),
                new OracleParameter("p_estado_reserva", (object?)m.EstadoReserva ?? DBNull.Value),
                new OracleParameter("p_precio_total", (object?)m.PrecioTotal ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_pagado", (object?)m.Pagado ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_reservas_transporte.update_reserva(:p_id_reserva_transporte, :p_codigo_reserva_transporte, :p_id_pasajero, :p_id_ruta_transporte, :p_tipo_servicio, :p_fecha_reserva, :p_fecha_servicio, :p_hora_recogida, :p_lugar_recogida, :p_lugar_destino, :p_numero_pasajeros, :p_cantidad_maletas, :p_id_vuelo_asociado, :p_instrucciones_especiales, :p_estado_reserva, :p_precio_total, :p_moneda, :p_pagado); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_reservas_transporte.delete_reserva(:p_id_reserva_transporte); END;", 
                new OracleParameter("p_id_reserva_transporte", id));
            return true;
        }

        public async Task<List<ReservasTransporteTerrestre>> ListarTodo() => await _context.Set<ReservasTransporteTerrestre>().ToListAsync();

        public async Task<ReservasTransporteTerrestre?> ObtenerPorId(int id) => await _context.Set<ReservasTransporteTerrestre>().FindAsync(id);
    }
}
