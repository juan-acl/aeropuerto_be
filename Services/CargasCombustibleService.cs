using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class CargasCombustibleService : ICargasCombustibleService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public CargasCombustibleService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<CargasCombustible>> ListarTodo()
        {
            try { return await _replica.CargasCombustible.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo CargasCombustible: {ex.Message}"); return new List<CargasCombustible>(); }
        }

        public async Task<CargasCombustible ?> ObtenerPorId(int id)
        {
            try { return await _replica.CargasCombustible.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId CargasCombustible: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(CargasCombustible m)
        {
            try
            {
                string sql = "BEGIN pkg_cargas_combustible.insert_carga(:p_id_pedido_combustible, :p_id_surtidor, :p_cantidad_real_litros, :p_temperatura_combustible, :p_densidad_combustible, :p_fecha_inicio_carga, :p_fecha_fin_carga, :p_duracion_minutos, :p_operador_carga, :p_verificador, :p_lectura_inicial_contador, :p_lectura_final_contador, :p_incidencia_tecnica, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_pedido_combustible", m.IdPedidoCombustible),
                    new OracleParameter("p_id_surtidor", (object?)m.IdSurtidor ?? DBNull.Value),
                    new OracleParameter("p_cantidad_real_litros", (object?)m.CantidadRealLitros ?? DBNull.Value),
                    new OracleParameter("p_temperatura_combustible", (object?)m.TemperaturaCombustible ?? DBNull.Value),
                    new OracleParameter("p_densidad_combustible", (object?)m.DensidadCombustible ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio_carga", (object?)m.FechaInicioCarga ?? DBNull.Value),
                    new OracleParameter("p_fecha_fin_carga", (object?)m.FechaFinCarga ?? DBNull.Value),
                    new OracleParameter("p_duracion_minutos", (object?)m.DuracionMinutos ?? DBNull.Value),
                    new OracleParameter("p_operador_carga", (object?)m.OperadorCarga ?? DBNull.Value),
                    new OracleParameter("p_verificador", (object?)m.Verificador ?? DBNull.Value),
                    new OracleParameter("p_lectura_inicial_contador", (object?)m.LecturaInicialContador ?? DBNull.Value),
                    new OracleParameter("p_lectura_final_contador", (object?)m.LecturaFinalContador ?? DBNull.Value),
                    new OracleParameter("p_incidencia_tecnica", (object?)m.IncidenciaTecnica ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar CargasCombustible: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, CargasCombustible m)
        {
            try
            {
                string sql = "BEGIN pkg_cargas_combustible.update_carga(:p_id_carga_combustible, :p_id_pedido_combustible, :p_id_surtidor, :p_cantidad_real_litros, :p_temperatura_combustible, :p_densidad_combustible, :p_fecha_inicio_carga, :p_fecha_fin_carga, :p_duracion_minutos, :p_operador_carga, :p_verificador, :p_lectura_inicial_contador, :p_lectura_final_contador, :p_incidencia_tecnica, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_carga_combustible", id),
                    new OracleParameter("p_id_pedido_combustible", m.IdPedidoCombustible),
                    new OracleParameter("p_id_surtidor", (object?)m.IdSurtidor ?? DBNull.Value),
                    new OracleParameter("p_cantidad_real_litros", (object?)m.CantidadRealLitros ?? DBNull.Value),
                    new OracleParameter("p_temperatura_combustible", (object?)m.TemperaturaCombustible ?? DBNull.Value),
                    new OracleParameter("p_densidad_combustible", (object?)m.DensidadCombustible ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio_carga", (object?)m.FechaInicioCarga ?? DBNull.Value),
                    new OracleParameter("p_fecha_fin_carga", (object?)m.FechaFinCarga ?? DBNull.Value),
                    new OracleParameter("p_duracion_minutos", (object?)m.DuracionMinutos ?? DBNull.Value),
                    new OracleParameter("p_operador_carga", (object?)m.OperadorCarga ?? DBNull.Value),
                    new OracleParameter("p_verificador", (object?)m.Verificador ?? DBNull.Value),
                    new OracleParameter("p_lectura_inicial_contador", (object?)m.LecturaInicialContador ?? DBNull.Value),
                    new OracleParameter("p_lectura_final_contador", (object?)m.LecturaFinalContador ?? DBNull.Value),
                    new OracleParameter("p_incidencia_tecnica", (object?)m.IncidenciaTecnica ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar CargasCombustible: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_cargas_combustible.delete_carga(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar CargasCombustible: {ex.Message}"); throw; }
        }
    }
}
