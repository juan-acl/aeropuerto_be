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
            var sql = "sp_crear_reserva";

            var parametros = new[] {
                new OracleParameter("p_id_vuelo", m.IdVuelo),
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_clase_servicio", (object?)m.ClaseServicio ?? DBNull.Value),
                new OracleParameter("p_codigo_reserva", m.CodigoReserva),
                new OracleParameter("p_numero_asiento", (object?)m.NumeroAsiento ?? DBNull.Value),
                new OracleParameter("p_tipo_tarifa", (object?)m.TipoTarifa ?? DBNull.Value),
                new OracleParameter("p_precio_pagado", m.PrecioPagado),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? "USD"),
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

        public async Task<List<ReservasModel>> ListarPorVuelo(int idVuelo)
        {
            return await _context.Reservas
                .Where(r =>
                    r.IdVuelo == idVuelo &&
                    r.NumeroAsiento != null &&
                    r.NumeroAsiento != "" &&
                    r.EstadoReserva != "CANCELADA" &&
                    r.EstadoReserva != "ANULADA" &&
                    r.EstadoReserva != "EXPIRADA")
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

        public async Task<bool> RegistrarAbordaje(EmbarqueRequest m)
        {
            // El nombre del procedimiento fuera de un paquete seg�n tu SQL original
            var sql = "sp_apertura_embarque";

            var parametros = new[] {
                new OracleParameter("p_codigo_reserva", OracleDbType.Varchar2) { Value = m.CodigoReserva },
                new OracleParameter("p_numero_documento", OracleDbType.Varchar2) { Value = m.NumeroDocumento },
                new OracleParameter("p_puerta_embarque", OracleDbType.Varchar2) { Value = m.PuertaEmbarque }
            };

            // Ejecutamos el SP dentro de un bloque BEGIN...END;
            // Nota: Si el SP lanza un RAISE_APPLICATION_ERROR, Entity Framework lo capturar� como una Exception
            await _context.Database.ExecuteSqlRawAsync(
                $"BEGIN {sql}(:p_codigo_reserva, :p_numero_documento, :p_puerta_embarque); END;",
                parametros
            );

            return true;
        }

        public async Task<bool> RealizarCheckIn(CheckInRequest m)
        {
            var sql = "sp_checkin_en_linea";

            var parametros = new[] {
        new OracleParameter("p_codigo_reserva", OracleDbType.Varchar2) { Value = m.CodigoReserva },
        new OracleParameter("p_numero_documento", OracleDbType.Varchar2) { Value = m.NumeroDocumento },
        new OracleParameter("p_numero_asiento", OracleDbType.Varchar2) { Value = m.NumeroAsiento }
    };

            // Ejecuci�n del procedimiento
            await _context.Database.ExecuteSqlRawAsync(
                $"BEGIN {sql}(:p_codigo_reserva, :p_numero_documento, :p_numero_asiento); END;",
                parametros
            );

            return true;
        }

        public async Task<bool> RealizarCheckInMostrador(CheckInMostradorRequest m)
        {
            var sql = "sp_checkin_mostrador";

            var parametros = new[] {
        new OracleParameter("p_codigo_reserva", OracleDbType.Varchar2) { Value = m.CodigoReserva },
        new OracleParameter("p_numero_documento", OracleDbType.Varchar2) { Value = m.NumeroDocumento },
        new OracleParameter("p_numero_asiento", OracleDbType.Varchar2) { Value = m.NumeroAsiento },
        new OracleParameter("p_equipaje_facturado", OracleDbType.Decimal) { Value = m.EquipajeFacturado },
        new OracleParameter("p_equipaje_mano", OracleDbType.Decimal) { Value = m.EquipajeMano },
        new OracleParameter("p_tipo_vuelo", OracleDbType.Varchar2) { Value = m.TipoVuelo },
        new OracleParameter("p_visa_valida", OracleDbType.Int32) { Value = m.VisaValida }
    };

            await _context.Database.ExecuteSqlRawAsync(
                $"BEGIN {sql}(:p_codigo_reserva, :p_numero_documento, :p_numero_asiento, :p_equipaje_facturado, :p_equipaje_mano, :p_tipo_vuelo, :p_visa_valida); END;",
                parametros
            );

            return true;
        }

        public async Task<bool> CrearReserva(CrearReservaRequest m)
        {
            var sql = "sp_crear_reserva";

            var parametros = new[] {
        new OracleParameter("p_id_vuelo", OracleDbType.Int32) { Value = m.IdVuelo },
        new OracleParameter("p_id_pasajero", OracleDbType.Int32) { Value = m.IdPasajero },
        new OracleParameter("p_clase_servicio", OracleDbType.Varchar2) { Value = m.ClaseServicio },
        new OracleParameter("p_numero_asiento", OracleDbType.Varchar2) { Value = m.NumeroAsiento },
        new OracleParameter("p_tipo_tarifa", OracleDbType.Varchar2) { Value = m.TipoTarifa },
        new OracleParameter("p_precio", OracleDbType.Decimal) { Value = m.Precio },
        new OracleParameter("p_moneda", OracleDbType.Varchar2) { Value = m.Moneda }
    };

            await _context.Database.ExecuteSqlRawAsync(
                $"BEGIN {sql}(:p_id_vuelo, :p_id_pasajero, :p_clase_servicio, :p_numero_asiento, :p_tipo_tarifa, :p_precio, :p_moneda); END;",
                parametros
            );

            return true;
        }

        public async Task<bool> PagarBoleto(PagoBoletoRequest m)
        {
            var sql = "sp_pagar_boleto";

            var parametros = new[] {
        new OracleParameter("p_id_reserva", OracleDbType.Int32) { Value = m.IdReserva },
        new OracleParameter("p_id_metodo_pago", OracleDbType.Int32) { Value = m.IdMetodoPago },
        new OracleParameter("p_monto", OracleDbType.Decimal) { Value = m.Monto },
        new OracleParameter("p_moneda", OracleDbType.Varchar2) { Value = m.Moneda },
        new OracleParameter("p_codigo_transaccion", OracleDbType.Varchar2) { Value = m.CodigoTransaccion },
        new OracleParameter("p_comprobante", OracleDbType.Blob) { Value = m.Comprobante }
    };

            await _context.Database.ExecuteSqlRawAsync(
                $"BEGIN {sql}(:p_id_reserva, :p_id_metodo_pago, :p_monto, :p_moneda, :p_codigo_transaccion, :p_comprobante); END;",
                parametros
            );

            return true;
        }

    }
}
