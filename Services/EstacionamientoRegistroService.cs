using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class EstacionamientoRegistroService : IEstacionamientoRegistroService
    {
        private readonly DBContext _context;

        public EstacionamientoRegistroService(DBContext context) => _context = context;

        public async Task<int> RegistrarEntrada(EstacionamientoRegistroModel m)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1. Registramos la entrada y obtenemos el ID generado para imprimir el ticket
                var sqlInsert = @"INSERT INTO estacionamiento_registro 
                            (id_espacio, id_pasajero, id_vuelo, placa_vehiculo, 
                             fecha_entrada, tarifa_aplicada, estado_pago) 
                            VALUES (:p_espacio, :p_pas, :p_vuelo, :p_placa, 
                                    SYSTIMESTAMP, :p_tarifa, 0)
                            RETURNING id_registro INTO :p_id_out";

                var idOutParam = new OracleParameter("p_id_out", OracleDbType.Int32, ParameterDirection.Output);

                var parametrosInsert = new[] {
                    new OracleParameter("p_espacio", (object?)m.IdEspacio ?? DBNull.Value),
                    new OracleParameter("p_pas", (object?)m.IdPasajero ?? DBNull.Value),
                    new OracleParameter("p_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                    new OracleParameter("p_placa", (object?)m.PlacaVehiculo ?? DBNull.Value),
                    new OracleParameter("p_tarifa", (object?)m.TarifaAplicada ?? DBNull.Value),
                    idOutParam
                };

                await _context.Database.ExecuteSqlRawAsync(sqlInsert, parametrosInsert);
                int idGenerado = Convert.ToInt32(idOutParam.Value.ToString());

                // 2. Marcamos el espacio como OCUPADO en la tabla maestra
                if (m.IdEspacio.HasValue)
                {
                    var sqlUpdateEspacio = "UPDATE estacionamiento SET disponible = 0 WHERE id_estacionamiento = :p_esp";
                    await _context.Database.ExecuteSqlRawAsync(sqlUpdateEspacio, new OracleParameter("p_esp", m.IdEspacio.Value));
                }

                await transaction.CommitAsync();
                return idGenerado;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<EstacionamientoRegistroModel?> CalcularSalida(int idRegistro)
        {
            // Buscamos el registro actual
            var registro = await _context.EstacionamientoRegistro.FindAsync(idRegistro);
            if (registro == null || registro.FechaSalida != null) return registro;

            // Lógica de negocio: Calcular tiempo y costo
            registro.FechaSalida = DateTime.Now;
            var diferencia = registro.FechaSalida.Value - registro.FechaEntrada.Value;

            // Redondeamos hacia arriba para cobrar la fracción como hora completa (clásico de aeropuertos)
            registro.TiempoTotalHoras = (decimal)Math.Ceiling(diferencia.TotalHours);

            // Cálculo del total
            registro.TotalPagar = registro.TiempoTotalHoras * (registro.TarifaAplicada ?? 0);

            // Actualizamos el registro en la base de datos
            var sql = @"UPDATE estacionamiento_registro 
                        SET fecha_salida = :p_salida, 
                            tiempo_total_horas = :p_horas, 
                            total_pagar = :p_total 
                        WHERE id_registro = :p_id";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_salida", registro.FechaSalida),
                new OracleParameter("p_horas", registro.TiempoTotalHoras),
                new OracleParameter("p_total", registro.TotalPagar),
                new OracleParameter("p_id", idRegistro));

            return registro;
        }

        public async Task<bool> ProcesarPago(int idRegistro, string metodoPago)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1. Marcamos el ticket como pagado
                var sqlPago = @"UPDATE estacionamiento_registro 
                                SET estado_pago = 1, metodo_pago = :p_metodo 
                                WHERE id_registro = :p_id";

                await _context.Database.ExecuteSqlRawAsync(sqlPago,
                    new OracleParameter("p_metodo", metodoPago),
                    new OracleParameter("p_id", idRegistro));

                // 2. Liberamos el espacio de estacionamiento
                var registro = await _context.EstacionamientoRegistro.FindAsync(idRegistro);
                if (registro != null && registro.IdEspacio.HasValue)
                {
                    var sqlLibera = "UPDATE estacionamiento SET disponible = 1 WHERE id_estacionamiento = :p_esp";
                    await _context.Database.ExecuteSqlRawAsync(sqlLibera, new OracleParameter("p_esp", registro.IdEspacio.Value));
                }

                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<EstacionamientoRegistroModel>> ListarVehiculosActivos()
        {
            // Retorna los vehículos que no han salido del parqueo (Estado de pago pendiente / sin fecha de salida)
            return await _context.EstacionamientoRegistro
                .Where(r => r.FechaSalida == null)
                .OrderByDescending(r => r.FechaEntrada)
                .ToListAsync();
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM estacionamiento_registro WHERE id_registro = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}