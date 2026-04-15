using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ProveedorCombustibleService  : IProveedorCombustibleService
    {
        private readonly DBContext _context;

        public ProveedorCombustibleService(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(ProveedoresCombustible m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_proveedor", (object?)m.IdProveedor ?? DBNull.Value),
                new OracleParameter("p_tipo_combustible_suministrado", (object?)m.TipoCombustibleSuministrado ?? DBNull.Value),
                new OracleParameter("p_precio_compra_galon", (object?)m.PrecioCompraGalon ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_contrato_vigente", (object?)m.ContratoVigente ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio_contrato", (object?)m.FechaInicioContrato ?? DBNull.Value),
                new OracleParameter("p_fecha_fin_contrato", (object?)m.FechaFinContrato ?? DBNull.Value),
                new OracleParameter("p_volumen_minimo_contrato", (object?)m.VolumenMinimoContrato ?? DBNull.Value),
                new OracleParameter("p_condiciones_especiales", (object?)m.CondicionesEspeciales ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_proveedores_combustible.insert_proveedorcombustible(:p_id_proveedor, :p_tipo_combustible_suministrado, :p_precio_compra_galon, :p_moneda, :p_contrato_vigente, :p_fecha_inicio_contrato, :p_fecha_fin_contrato, :p_volumen_minimo_contrato, :p_condiciones_especiales); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Actualizar(int id, ProveedoresCombustible m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_proveedorcombustible", (object?)m.IdProveedorCombustible ?? DBNull.Value),
                new OracleParameter("p_id_proveedor", (object?)m.IdProveedor ?? DBNull.Value),
                new OracleParameter("p_tipo_combustible_suministrado", (object?)m.TipoCombustibleSuministrado ?? DBNull.Value),
                new OracleParameter("p_precio_compra_galon", (object?)m.PrecioCompraGalon ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_contrato_vigente", (object?)m.ContratoVigente ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio_contrato", (object?)m.FechaInicioContrato ?? DBNull.Value),
                new OracleParameter("p_fecha_fin_contrato", (object?)m.FechaFinContrato ?? DBNull.Value),
                new OracleParameter("p_volumen_minimo_contrato", (object?)m.VolumenMinimoContrato ?? DBNull.Value),
                new OracleParameter("p_condiciones_especiales", (object?)m.CondicionesEspeciales ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_proveedores_combustible.update_proveedorcombustible(:p_id_proveedorcombustible, :p_id_proveedor, :p_tipo_combustible_suministrado, :p_precio_compra_galon, :p_moneda, :p_contrato_vigente, :p_fecha_inicio_contrato, :p_fecha_fin_contrato, :p_volumen_minimo_contrato, :p_condiciones_especiales); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_proveedores_combustible.delete_proveedorcombustible(:p_id_proveedorcombustible); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_proveedorcombustible", id));
            return true;
        }

        public async Task<List<ProveedoresCombustible>> ListarTodo()
        {
            return await _context.Set<ProveedoresCombustible>().ToListAsync();
        }

        public async Task<ProveedoresCombustible?> ObtenerPorId(int id) => await _context.Set<ProveedoresCombustible>().FindAsync(id);
    }
}
