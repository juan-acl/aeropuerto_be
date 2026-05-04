using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class TanquesCombustibleService : ITanquesCombustibleService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public TanquesCombustibleService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<TanquesCombustible>> ListarTodo()
        {
            try { return await _replica.TanquesCombustible.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo TanquesCombustible: {ex.Message}"); return new List<TanquesCombustible>(); }
        }

        public async Task<TanquesCombustible ?> ObtenerPorId(int id)
        {
            try { return await _replica.TanquesCombustible.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId TanquesCombustible: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(TanquesCombustible m)
        {
            try
            {
                string sql = "BEGIN pkg_tanques_combustible.insert_tanque(:p_codigo_tanque, :p_nombre_tanque, :p_tipo_combustible, :p_capacidad_litros, :p_nivel_actual_litros, :p_porcentaje_llenado, :p_ubicacion, :p_fecha_ultima_inspeccion, :p_fecha_ultima_calibracion, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_codigo_tanque", (object?)m.CodigoTanque ?? DBNull.Value),
                    new OracleParameter("p_nombre_tanque", (object?)m.NombreTanque ?? DBNull.Value),
                    new OracleParameter("p_tipo_combustible", (object?)m.TipoCombustible ?? DBNull.Value),
                    new OracleParameter("p_capacidad_litros", (object?)m.CapacidadLitros ?? DBNull.Value),
                    new OracleParameter("p_nivel_actual_litros", (object?)m.NivelActualLitros ?? DBNull.Value),
                    new OracleParameter("p_porcentaje_llenado", (object?)m.PorcentajeLlenado ?? DBNull.Value),
                    new OracleParameter("p_ubicacion", (object?)m.Ubicacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_ultima_inspeccion", (object?)m.FechaUltimaInspeccion ?? DBNull.Value),
                    new OracleParameter("p_fecha_ultima_calibracion", (object?)m.FechaUltimaCalibracion ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar TanquesCombustible: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, TanquesCombustible m)
        {
            try
            {
                string sql = "BEGIN pkg_tanques_combustible.update_tanque(:p_id_tanque, :p_codigo_tanque, :p_nombre_tanque, :p_tipo_combustible, :p_capacidad_litros, :p_nivel_actual_litros, :p_porcentaje_llenado, :p_ubicacion, :p_fecha_ultima_inspeccion, :p_fecha_ultima_calibracion, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_tanque", id),
                    new OracleParameter("p_codigo_tanque", (object?)m.CodigoTanque ?? DBNull.Value),
                    new OracleParameter("p_nombre_tanque", (object?)m.NombreTanque ?? DBNull.Value),
                    new OracleParameter("p_tipo_combustible", (object?)m.TipoCombustible ?? DBNull.Value),
                    new OracleParameter("p_capacidad_litros", (object?)m.CapacidadLitros ?? DBNull.Value),
                    new OracleParameter("p_nivel_actual_litros", (object?)m.NivelActualLitros ?? DBNull.Value),
                    new OracleParameter("p_porcentaje_llenado", (object?)m.PorcentajeLlenado ?? DBNull.Value),
                    new OracleParameter("p_ubicacion", (object?)m.Ubicacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_ultima_inspeccion", (object?)m.FechaUltimaInspeccion ?? DBNull.Value),
                    new OracleParameter("p_fecha_ultima_calibracion", (object?)m.FechaUltimaCalibracion ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar TanquesCombustible: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_tanques_combustible.delete_tanque(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar TanquesCombustible: {ex.Message}"); throw; }
        }
    }
}
