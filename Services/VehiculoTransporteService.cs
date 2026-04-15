using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class VehiculoTransporteService : IVehiculoTransporteService
    {
        private readonly DBContext _context;
        public VehiculoTransporteService(DBContext context) => _context = context;

        public async Task<bool> Insertar(VehiculosTransporte m)
        {
            var p = new[] {
                new OracleParameter("p_placa", (object?)m.Placa ?? DBNull.Value),
                new OracleParameter("p_tipo_vehiculo", (object?)m.TipoVehiculo ?? DBNull.Value),
                new OracleParameter("p_marca", (object?)m.Marca ?? DBNull.Value),
                new OracleParameter("p_modelo", (object?)m.Modelo ?? DBNull.Value),
                new OracleParameter("p_anio", (object?)m.Anio ?? DBNull.Value),
                new OracleParameter("p_capacidad_pasajeros", (object?)m.CapacidadPasajeros ?? DBNull.Value),
                new OracleParameter("p_capacidad_maletas", (object?)m.CapacidadMaletas ?? DBNull.Value),
                new OracleParameter("p_tiene_aire_acondicionado", (object?)m.TieneAireAcondicionado ?? DBNull.Value),
                new OracleParameter("p_tiene_wifi", (object?)m.TieneWifi ?? DBNull.Value),
                new OracleParameter("p_tiene_accesibilidad", (object?)m.TieneAccesibilidad ?? DBNull.Value),
                new OracleParameter("p_propietario", (object?)m.Propietario ?? DBNull.Value),
                new OracleParameter("p_empresa_operadora", (object?)m.EmpresaOperadora ?? DBNull.Value),
                new OracleParameter("p_fecha_ultimo_mantenimiento", (object?)m.FechaUltimoMantenimiento ?? DBNull.Value),
                new OracleParameter("p_fecha_proximo_mantenimiento", (object?)m.FechaProximoMantenimiento ?? DBNull.Value),
                new OracleParameter("p_disponible", (object?)m.Disponible ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_vehiculos_transporte.insert_vehiculo(:p_placa, :p_tipo_vehiculo, :p_marca, :p_modelo, :p_anio, :p_capacidad_pasajeros, :p_capacidad_maletas, :p_tiene_aire_acondicionado, :p_tiene_wifi, :p_tiene_accesibilidad, :p_propietario, :p_empresa_operadora, :p_fecha_ultimo_mantenimiento, :p_fecha_proximo_mantenimiento, :p_disponible, :p_activo); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, VehiculosTransporte m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_vehiculo_transporte", m.IdVehiculoTransporte)
            };
            p.AddRange(new[] {
                new OracleParameter("p_placa", (object?)m.Placa ?? DBNull.Value),
                new OracleParameter("p_tipo_vehiculo", (object?)m.TipoVehiculo ?? DBNull.Value),
                new OracleParameter("p_marca", (object?)m.Marca ?? DBNull.Value),
                new OracleParameter("p_modelo", (object?)m.Modelo ?? DBNull.Value),
                new OracleParameter("p_anio", (object?)m.Anio ?? DBNull.Value),
                new OracleParameter("p_capacidad_pasajeros", (object?)m.CapacidadPasajeros ?? DBNull.Value),
                new OracleParameter("p_capacidad_maletas", (object?)m.CapacidadMaletas ?? DBNull.Value),
                new OracleParameter("p_tiene_aire_acondicionado", (object?)m.TieneAireAcondicionado ?? DBNull.Value),
                new OracleParameter("p_tiene_wifi", (object?)m.TieneWifi ?? DBNull.Value),
                new OracleParameter("p_tiene_accesibilidad", (object?)m.TieneAccesibilidad ?? DBNull.Value),
                new OracleParameter("p_propietario", (object?)m.Propietario ?? DBNull.Value),
                new OracleParameter("p_empresa_operadora", (object?)m.EmpresaOperadora ?? DBNull.Value),
                new OracleParameter("p_fecha_ultimo_mantenimiento", (object?)m.FechaUltimoMantenimiento ?? DBNull.Value),
                new OracleParameter("p_fecha_proximo_mantenimiento", (object?)m.FechaProximoMantenimiento ?? DBNull.Value),
                new OracleParameter("p_disponible", (object?)m.Disponible ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_vehiculos_transporte.update_vehiculo(:p_id_vehiculo_transporte, :p_placa, :p_tipo_vehiculo, :p_marca, :p_modelo, :p_anio, :p_capacidad_pasajeros, :p_capacidad_maletas, :p_tiene_aire_acondicionado, :p_tiene_wifi, :p_tiene_accesibilidad, :p_propietario, :p_empresa_operadora, :p_fecha_ultimo_mantenimiento, :p_fecha_proximo_mantenimiento, :p_disponible, :p_activo); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_vehiculos_transporte.delete_vehiculo(:p_id_vehiculo_transporte); END;", 
                new OracleParameter("p_id_vehiculo_transporte", id));
            return true;
        }

        public async Task<List<VehiculosTransporte>> ListarTodo() => await _context.Set<VehiculosTransporte>().ToListAsync();

        public async Task<VehiculosTransporte?> ObtenerPorId(int id) => await _context.Set<VehiculosTransporte>().FindAsync(id);
    }
}
