using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class AsignacionVehiculoRutaService : IAsignacionVehiculoRutaService
    {
        private readonly DBContext _context;
        public AsignacionVehiculoRutaService(DBContext context) => _context = context;

        public async Task<bool> Insertar(AsignacionVehiculosRutas m)
        {
            var p = new[] {
                new OracleParameter("p_id_vehiculo_transporte", (object?)m.IdVehiculoTransporte ?? DBNull.Value),
                new OracleParameter("p_id_ruta_transporte", (object?)m.IdRutaTransporte ?? DBNull.Value),
                new OracleParameter("p_fecha_asignacion", (object?)m.FechaAsignacion ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio_vigencia", (object?)m.FechaInicioVigencia ?? DBNull.Value),
                new OracleParameter("p_fecha_fin_vigencia", (object?)m.FechaFinVigencia ?? DBNull.Value),
                new OracleParameter("p_horario_servicio", (object?)m.HorarioServicio ?? DBNull.Value),
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_asignacion_vehiculos_rutas.insert_asignacion(:p_id_vehiculo_transporte, :p_id_ruta_transporte, :p_fecha_asignacion, :p_fecha_inicio_vigencia, :p_fecha_fin_vigencia, :p_horario_servicio, :p_activa); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, AsignacionVehiculosRutas m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_asignacion_vehiculo_ruta", m.IdAsignacionVehiculoRuta)
            };
            p.AddRange(new[] {
                new OracleParameter("p_id_vehiculo_transporte", (object?)m.IdVehiculoTransporte ?? DBNull.Value),
                new OracleParameter("p_id_ruta_transporte", (object?)m.IdRutaTransporte ?? DBNull.Value),
                new OracleParameter("p_fecha_asignacion", (object?)m.FechaAsignacion ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio_vigencia", (object?)m.FechaInicioVigencia ?? DBNull.Value),
                new OracleParameter("p_fecha_fin_vigencia", (object?)m.FechaFinVigencia ?? DBNull.Value),
                new OracleParameter("p_horario_servicio", (object?)m.HorarioServicio ?? DBNull.Value),
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_asignacion_vehiculos_rutas.update_asignacion(:p_id_asignacion_vehiculo_ruta, :p_id_vehiculo_transporte, :p_id_ruta_transporte, :p_fecha_asignacion, :p_fecha_inicio_vigencia, :p_fecha_fin_vigencia, :p_horario_servicio, :p_activa); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_asignacion_vehiculos_rutas.delete_asignacion(:p_id_asignacion_vehiculo_ruta); END;", 
                new OracleParameter("p_id_asignacion_vehiculo_ruta", id));
            return true;
        }

        public async Task<List<AsignacionVehiculosRutas>> ListarTodo() => await _context.Set<AsignacionVehiculosRutas>().ToListAsync();

        public async Task<AsignacionVehiculosRutas?> ObtenerPorId(int id) => await _context.Set<AsignacionVehiculosRutas>().FindAsync(id);
    }
}
