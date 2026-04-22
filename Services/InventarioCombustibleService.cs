using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class InventarioCombustibleService : IInventarioCombustibleService
    {
        private readonly DBContext _context;
        public InventarioCombustibleService(DBContext context) => _context = context;

        public async Task<List<InventarioCombustible>> ListarTodo()
        {
            try { return await _context.InventarioCombustible.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo InventarioCombustible: {ex.Message}"); return new List<InventarioCombustible>(); }
        }

        public async Task<InventarioCombustible?> ObtenerPorId(int id)
        {
            try { return await _context.InventarioCombustible.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId InventarioCombustible: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(InventarioCombustible m)
        {
            try
            {
                string sql = "BEGIN pkg_inventario_combustible.insert_inventario(:p_id_tanque, :p_fecha_inventario, :p_nivel_medido_litros, :p_nivel_teorico_litros, :p_diferencia_litros, :p_porcentaje_diferencia, :p_temperatura_promedio, :p_tipo_inventario, :p_realizado_por, :p_verificado_por, :p_observaciones); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_tanque", m.IdTanque),
                new OracleParameter("p_fecha_inventario", m.FechaInventario),
                new OracleParameter("p_nivel_medido_litros", (object?)m.NivelMedidoLitros ?? DBNull.Value),
                new OracleParameter("p_nivel_teorico_litros", (object?)m.NivelTeoricoLitros ?? DBNull.Value),
                new OracleParameter("p_diferencia_litros", (object?)m.DiferenciaLitros ?? DBNull.Value),
                new OracleParameter("p_porcentaje_diferencia", (object?)m.PorcentajeDiferencia ?? DBNull.Value),
                new OracleParameter("p_temperatura_promedio", (object?)m.TemperaturaPromedio ?? DBNull.Value),
                new OracleParameter("p_tipo_inventario", (object?)m.TipoInventario ?? DBNull.Value),
                new OracleParameter("p_realizado_por", (object?)m.RealizadoPor ?? DBNull.Value),
                new OracleParameter("p_verificado_por", (object?)m.VerificadoPor ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar InventarioCombustible: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, InventarioCombustible m)
        {
            try
            {
                string sql = "BEGIN pkg_inventario_combustible.update_inventario(:p_id_inventario, :p_id_tanque, :p_fecha_inventario, :p_nivel_medido_litros, :p_nivel_teorico_litros, :p_diferencia_litros, :p_porcentaje_diferencia, :p_temperatura_promedio, :p_tipo_inventario, :p_realizado_por, :p_verificado_por, :p_observaciones); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_inventario", id),
                new OracleParameter("p_id_tanque", m.IdTanque),
                new OracleParameter("p_fecha_inventario", m.FechaInventario),
                new OracleParameter("p_nivel_medido_litros", (object?)m.NivelMedidoLitros ?? DBNull.Value),
                new OracleParameter("p_nivel_teorico_litros", (object?)m.NivelTeoricoLitros ?? DBNull.Value),
                new OracleParameter("p_diferencia_litros", (object?)m.DiferenciaLitros ?? DBNull.Value),
                new OracleParameter("p_porcentaje_diferencia", (object?)m.PorcentajeDiferencia ?? DBNull.Value),
                new OracleParameter("p_temperatura_promedio", (object?)m.TemperaturaPromedio ?? DBNull.Value),
                new OracleParameter("p_tipo_inventario", (object?)m.TipoInventario ?? DBNull.Value),
                new OracleParameter("p_realizado_por", (object?)m.RealizadoPor ?? DBNull.Value),
                new OracleParameter("p_verificado_por", (object?)m.VerificadoPor ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar InventarioCombustible: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_inventario_combustible.delete_inventario(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar InventarioCombustible: {ex.Message}"); return false; }
        }
    }
}
