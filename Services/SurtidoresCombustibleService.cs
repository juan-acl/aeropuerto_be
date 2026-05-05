using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class SurtidoresCombustibleService : ISurtidoresCombustibleService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public SurtidoresCombustibleService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<SurtidoresCombustible>> ListarTodo()
        {
            try { return await _replica.SurtidoresCombustible.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo SurtidoresCombustible: {ex.Message}"); return new List<SurtidoresCombustible>(); }
        }

        public async Task<SurtidoresCombustible ?> ObtenerPorId(int id)
        {
            try { return await _replica.SurtidoresCombustible.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId SurtidoresCombustible: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(SurtidoresCombustible m)
        {
            try
            {
                string sql = "BEGIN pkg_surtidores_combustible.insert_surtidor(:p_codigo_surtidor, :p_ubicacion, :p_tipo_combustible, :p_velocidad_carga_litros_hora, :p_disponible, :p_fecha_ultimo_mantenimiento, :p_fecha_proximo_mantenimiento, :p_operativo, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_codigo_surtidor", (object?)m.CodigoSurtidor ?? DBNull.Value),
                    new OracleParameter("p_ubicacion", (object?)m.Ubicacion ?? DBNull.Value),
                    new OracleParameter("p_tipo_combustible", (object?)m.TipoCombustible ?? DBNull.Value),
                    new OracleParameter("p_velocidad_carga_litros_hora", (object?)m.VelocidadCargaLitrosHora ?? DBNull.Value),
                    new OracleParameter("p_disponible", (object?)m.Disponible ?? DBNull.Value),
                    new OracleParameter("p_fecha_ultimo_mantenimiento", (object?)m.FechaUltimoMantenimiento ?? DBNull.Value),
                    new OracleParameter("p_fecha_proximo_mantenimiento", (object?)m.FechaProximoMantenimiento ?? DBNull.Value),
                    new OracleParameter("p_operativo", (object?)m.Operativo ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar SurtidoresCombustible: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, SurtidoresCombustible m)
        {
            try
            {
                string sql = "BEGIN pkg_surtidores_combustible.update_surtidor(:p_id_surtidor, :p_codigo_surtidor, :p_ubicacion, :p_tipo_combustible, :p_velocidad_carga_litros_hora, :p_disponible, :p_fecha_ultimo_mantenimiento, :p_fecha_proximo_mantenimiento, :p_operativo, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_surtidor", id),
                    new OracleParameter("p_codigo_surtidor", (object?)m.CodigoSurtidor ?? DBNull.Value),
                    new OracleParameter("p_ubicacion", (object?)m.Ubicacion ?? DBNull.Value),
                    new OracleParameter("p_tipo_combustible", (object?)m.TipoCombustible ?? DBNull.Value),
                    new OracleParameter("p_velocidad_carga_litros_hora", (object?)m.VelocidadCargaLitrosHora ?? DBNull.Value),
                    new OracleParameter("p_disponible", (object?)m.Disponible ?? DBNull.Value),
                    new OracleParameter("p_fecha_ultimo_mantenimiento", (object?)m.FechaUltimoMantenimiento ?? DBNull.Value),
                    new OracleParameter("p_fecha_proximo_mantenimiento", (object?)m.FechaProximoMantenimiento ?? DBNull.Value),
                    new OracleParameter("p_operativo", (object?)m.Operativo ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar SurtidoresCombustible: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_surtidores_combustible.delete_surtidor(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar SurtidoresCombustible: {ex.Message}"); throw; }
        }
    }
}
