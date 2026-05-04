using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ProveedoresCombustibleService : IProveedoresCombustibleService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ProveedoresCombustibleService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ProveedoresCombustible>> ListarTodo()
        {
            try { return await _replica.ProveedoresCombustible.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ProveedoresCombustible: {ex.Message}"); return new List<ProveedoresCombustible>(); }
        }

        public async Task<ProveedoresCombustible ?> ObtenerPorId(int id)
        {
            try { return await _replica.ProveedoresCombustible.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ProveedoresCombustible: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ProveedoresCombustible m)
        {
            try
            {
                string sql = "BEGIN pkg_proveedores_combustible.insert_proveedor_combustible(:p_id_proveedor, :p_tipo_combustible_suministrado, :p_precio_compra_galon, :p_moneda, :p_contrato_vigente, :p_fecha_inicio_contrato, :p_fecha_fin_contrato, :p_volumen_minimo_contrato, :p_condiciones_especiales); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_proveedor", (object?)m.IdProveedor ?? DBNull.Value),
                    new OracleParameter("p_tipo_combustible_suministrado", (object?)m.TipoCombustibleSuministrado ?? DBNull.Value),
                    new OracleParameter("p_precio_compra_galon", (object?)m.PrecioCompraGalon ?? DBNull.Value),
                    new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                    new OracleParameter("p_contrato_vigente", (object?)m.ContratoVigente ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio_contrato", (object?)m.FechaInicioContrato ?? DBNull.Value),
                    new OracleParameter("p_fecha_fin_contrato", (object?)m.FechaFinContrato ?? DBNull.Value),
                    new OracleParameter("p_volumen_minimo_contrato", (object?)m.VolumenMinimoContrato ?? DBNull.Value),
                    new OracleParameter("p_condiciones_especiales", (object?)m.CondicionesEspeciales ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ProveedoresCombustible: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, ProveedoresCombustible m)
        {
            try
            {
                string sql = "BEGIN pkg_proveedores_combustible.update_proveedor_combustible(:p_id_proveedor_combustible, :p_id_proveedor, :p_tipo_combustible_suministrado, :p_precio_compra_galon, :p_moneda, :p_contrato_vigente, :p_fecha_inicio_contrato, :p_fecha_fin_contrato, :p_volumen_minimo_contrato, :p_condiciones_especiales); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_proveedor_combustible", id),
                    new OracleParameter("p_id_proveedor", (object?)m.IdProveedor ?? DBNull.Value),
                    new OracleParameter("p_tipo_combustible_suministrado", (object?)m.TipoCombustibleSuministrado ?? DBNull.Value),
                    new OracleParameter("p_precio_compra_galon", (object?)m.PrecioCompraGalon ?? DBNull.Value),
                    new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                    new OracleParameter("p_contrato_vigente", (object?)m.ContratoVigente ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio_contrato", (object?)m.FechaInicioContrato ?? DBNull.Value),
                    new OracleParameter("p_fecha_fin_contrato", (object?)m.FechaFinContrato ?? DBNull.Value),
                    new OracleParameter("p_volumen_minimo_contrato", (object?)m.VolumenMinimoContrato ?? DBNull.Value),
                    new OracleParameter("p_condiciones_especiales", (object?)m.CondicionesEspeciales ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ProveedoresCombustible: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_proveedores_combustible.delete_proveedor_combustible(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ProveedoresCombustible: {ex.Message}"); throw; }
        }
    }
}
