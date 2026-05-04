using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class AsignacionVehiculosRutasService : IAsignacionVehiculosRutasService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public AsignacionVehiculosRutasService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<AsignacionVehiculosRutas>> ListarTodo()
        {
            try { return await _replica.AsignacionesVehiculosRutas.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo AsignacionVehiculosRutas: {ex.Message}"); return new List<AsignacionVehiculosRutas>(); }
        }

        public async Task<AsignacionVehiculosRutas ?> ObtenerPorId(int id)
        {
            try { return await _replica.AsignacionesVehiculosRutas.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId AsignacionVehiculosRutas: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(AsignacionVehiculosRutas m)
        {
            try
            {
                string sql = "BEGIN pkg_asignacion_vehiculos_rutas.insert_asignacion(:p_id_vehiculo_transporte, :p_id_ruta_transporte, :p_fecha_asignacion, :p_fecha_inicio_vigencia, :p_fecha_fin_vigencia, :p_horario_servicio, :p_activa); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_vehiculo_transporte", m.IdVehiculoTransporte),
                    new OracleParameter("p_id_ruta_transporte", m.IdRutaTransporte),
                    new OracleParameter("p_fecha_asignacion", (object?)m.FechaAsignacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio_vigencia", m.FechaInicioVigencia),
                    new OracleParameter("p_fecha_fin_vigencia", (object?)m.FechaFinVigencia ?? DBNull.Value),
                    new OracleParameter("p_horario_servicio", (object?)m.HorarioServicio ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar AsignacionVehiculosRutas: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, AsignacionVehiculosRutas m)
        {
            try
            {
                string sql = "BEGIN pkg_asignacion_vehiculos_rutas.update_asignacion(:p_id_asignacion_vehiculo_ruta, :p_id_vehiculo_transporte, :p_id_ruta_transporte, :p_fecha_asignacion, :p_fecha_inicio_vigencia, :p_fecha_fin_vigencia, :p_horario_servicio, :p_activa); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_asignacion_vehiculo_ruta", id),
                    new OracleParameter("p_id_vehiculo_transporte", m.IdVehiculoTransporte),
                    new OracleParameter("p_id_ruta_transporte", m.IdRutaTransporte),
                    new OracleParameter("p_fecha_asignacion", (object?)m.FechaAsignacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio_vigencia", m.FechaInicioVigencia),
                    new OracleParameter("p_fecha_fin_vigencia", (object?)m.FechaFinVigencia ?? DBNull.Value),
                    new OracleParameter("p_horario_servicio", (object?)m.HorarioServicio ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar AsignacionVehiculosRutas: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_asignacion_vehiculos_rutas.delete_asignacion(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar AsignacionVehiculosRutas: {ex.Message}"); throw; }
        }
    }
}
