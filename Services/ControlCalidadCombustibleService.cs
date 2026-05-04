using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ControlCalidadCombustibleService : IControlCalidadCombustibleService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ControlCalidadCombustibleService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ControlCalidadCombustible>> ListarTodo()
        {
            try { return await _replica.ControlCalidadCombustible.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ControlCalidadCombustible: {ex.Message}"); return new List<ControlCalidadCombustible>(); }
        }

        public async Task<ControlCalidadCombustible ?> ObtenerPorId(int id)
        {
            try { return await _replica.ControlCalidadCombustible.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ControlCalidadCombustible: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ControlCalidadCombustible m)
        {
            try
            {
                string sql = "BEGIN pkg_control_calidad_combustible.insert_muestra(:p_id_tanque, :p_fecha_muestra, :p_fecha_analisis, :p_numero_muestra, :p_tipo_analisis, :p_analista, :p_densidad_medida, :p_temperatura_prueba, :p_presencia_agua, :p_particulas_suspendidas, :p_conductividad, :p_resultado, :p_aprobado_por, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_tanque", (object?)m.IdTanque ?? DBNull.Value),
                    new OracleParameter("p_fecha_muestra", (object?)m.FechaMuestra ?? DBNull.Value),
                    new OracleParameter("p_fecha_analisis", (object?)m.FechaAnalisis ?? DBNull.Value),
                    new OracleParameter("p_numero_muestra", (object?)m.NumeroMuestra ?? DBNull.Value),
                    new OracleParameter("p_tipo_analisis", (object?)m.TipoAnalisis ?? DBNull.Value),
                    new OracleParameter("p_analista", (object?)m.Analista ?? DBNull.Value),
                    new OracleParameter("p_densidad_medida", (object?)m.DensidadMedida ?? DBNull.Value),
                    new OracleParameter("p_temperatura_prueba", (object?)m.TemperaturaPrueba ?? DBNull.Value),
                    new OracleParameter("p_presencia_agua", (object?)m.PresenciaAgua ?? DBNull.Value),
                    new OracleParameter("p_particulas_suspendidas", (object?)m.ParticulasSuspendidas ?? DBNull.Value),
                    new OracleParameter("p_conductividad", (object?)m.Conductividad ?? DBNull.Value),
                    new OracleParameter("p_resultado", (object?)m.Resultado ?? DBNull.Value),
                    new OracleParameter("p_aprobado_por", (object?)m.AprobadoPor ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ControlCalidadCombustible: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, ControlCalidadCombustible m)
        {
            try
            {
                string sql = "BEGIN pkg_control_calidad_combustible.update_muestra(:p_id_muestra, :p_id_tanque, :p_fecha_muestra, :p_fecha_analisis, :p_numero_muestra, :p_tipo_analisis, :p_analista, :p_densidad_medida, :p_temperatura_prueba, :p_presencia_agua, :p_particulas_suspendidas, :p_conductividad, :p_resultado, :p_aprobado_por, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_muestra", id),
                    new OracleParameter("p_id_tanque", (object?)m.IdTanque ?? DBNull.Value),
                    new OracleParameter("p_fecha_muestra", (object?)m.FechaMuestra ?? DBNull.Value),
                    new OracleParameter("p_fecha_analisis", (object?)m.FechaAnalisis ?? DBNull.Value),
                    new OracleParameter("p_numero_muestra", (object?)m.NumeroMuestra ?? DBNull.Value),
                    new OracleParameter("p_tipo_analisis", (object?)m.TipoAnalisis ?? DBNull.Value),
                    new OracleParameter("p_analista", (object?)m.Analista ?? DBNull.Value),
                    new OracleParameter("p_densidad_medida", (object?)m.DensidadMedida ?? DBNull.Value),
                    new OracleParameter("p_temperatura_prueba", (object?)m.TemperaturaPrueba ?? DBNull.Value),
                    new OracleParameter("p_presencia_agua", (object?)m.PresenciaAgua ?? DBNull.Value),
                    new OracleParameter("p_particulas_suspendidas", (object?)m.ParticulasSuspendidas ?? DBNull.Value),
                    new OracleParameter("p_conductividad", (object?)m.Conductividad ?? DBNull.Value),
                    new OracleParameter("p_resultado", (object?)m.Resultado ?? DBNull.Value),
                    new OracleParameter("p_aprobado_por", (object?)m.AprobadoPor ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ControlCalidadCombustible: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_control_calidad_combustible.delete_muestra(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ControlCalidadCombustible: {ex.Message}"); throw; }
        }
    }
}
