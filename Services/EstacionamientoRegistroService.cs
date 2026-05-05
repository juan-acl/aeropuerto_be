using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class EstacionamientoRegistroService : IEstacionamientoRegistroService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public EstacionamientoRegistroService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<EstacionamientoRegistroModel>> ListarTodo()
        {
            try { return await _replica.EstacionamientoRegistro.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo EstacionamientoRegistroModel: {ex.Message}"); return new List<EstacionamientoRegistroModel>(); }
        }

        public async Task<EstacionamientoRegistroModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.EstacionamientoRegistro.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId EstacionamientoRegistroModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(EstacionamientoRegistroModel m)
        {
            try
            {
                string sql = "BEGIN pkg_estacionamiento_registro.insert_registro(:p_id_espacio, :p_id_pasajero, :p_id_vuelo, :p_placa_vehiculo, :p_fecha_entrada, :p_fecha_salida, :p_tiempo_total_horas, :p_tarifa_aplicada, :p_total_pagar, :p_estado_pago, :p_metodo_pago); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_espacio", (object?)m.IdEspacio ?? DBNull.Value),
                    new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                    new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                    new OracleParameter("p_placa_vehiculo", (object?)m.PlacaVehiculo ?? DBNull.Value),
                    new OracleParameter("p_fecha_entrada", (object?)m.FechaEntrada ?? DBNull.Value),
                    new OracleParameter("p_fecha_salida", (object?)m.FechaSalida ?? DBNull.Value),
                    new OracleParameter("p_tiempo_total_horas", (object?)m.TiempoTotalHoras ?? DBNull.Value),
                    new OracleParameter("p_tarifa_aplicada", (object?)m.TarifaAplicada ?? DBNull.Value),
                    new OracleParameter("p_total_pagar", (object?)m.TotalPagar ?? DBNull.Value),
                    new OracleParameter("p_estado_pago", m.EstadoPago),
                    new OracleParameter("p_metodo_pago", (object?)m.MetodoPago ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar EstacionamientoRegistroModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, EstacionamientoRegistroModel m)
        {
            try
            {
                string sql = "BEGIN pkg_estacionamiento_registro.update_registro(:p_id_registro, :p_id_espacio, :p_id_pasajero, :p_id_vuelo, :p_placa_vehiculo, :p_fecha_entrada, :p_fecha_salida, :p_tiempo_total_horas, :p_tarifa_aplicada, :p_total_pagar, :p_estado_pago, :p_metodo_pago); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_registro", id),
                    new OracleParameter("p_id_espacio", (object?)m.IdEspacio ?? DBNull.Value),
                    new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                    new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                    new OracleParameter("p_placa_vehiculo", (object?)m.PlacaVehiculo ?? DBNull.Value),
                    new OracleParameter("p_fecha_entrada", (object?)m.FechaEntrada ?? DBNull.Value),
                    new OracleParameter("p_fecha_salida", (object?)m.FechaSalida ?? DBNull.Value),
                    new OracleParameter("p_tiempo_total_horas", (object?)m.TiempoTotalHoras ?? DBNull.Value),
                    new OracleParameter("p_tarifa_aplicada", (object?)m.TarifaAplicada ?? DBNull.Value),
                    new OracleParameter("p_total_pagar", (object?)m.TotalPagar ?? DBNull.Value),
                    new OracleParameter("p_estado_pago", m.EstadoPago),
                    new OracleParameter("p_metodo_pago", (object?)m.MetodoPago ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar EstacionamientoRegistroModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_estacionamiento_registro.delete_registro(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar EstacionamientoRegistroModel: {ex.Message}"); throw; }
        }
    }
}
