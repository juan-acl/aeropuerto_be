using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ProveedorRepuestoService : IProveedorRepuestoService
    {
        private readonly DBContext _context;
        public ProveedorRepuestoService(DBContext context) => _context = context;

        public async Task<List<ProveedorRepuesto>> ListarTodo() => await _context.PROVEEDORES_REPUESTOS.ToListAsync();
        public async Task<ProveedorRepuesto?> ObtenerPorId(int id) => await _context.PROVEEDORES_REPUESTOS.FindAsync(id);

        public async Task<bool> Insertar(ProveedorRepuesto m)
        {
            try
            {
                string sql = "BEGIN pkg_proveedores_repuestos.insert_proveedor_repuesto(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT PROVEEDOR_REPUESTO: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(ProveedorRepuesto m)
        {
            try
            {
                string sql = "BEGIN pkg_proveedores_repuestos.update_proveedor_repuesto(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE PROVEEDOR_REPUESTO: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_proveedores_repuestos.delete_proveedor_repuesto(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE PROVEEDOR_REPUESTO: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(ProveedorRepuesto m) => new OracleParameter[]
        {
            new OracleParameter("p1", m.id_proveedor_repuesto),
            new OracleParameter("p2", (object?)m.id_proveedor ?? DBNull.Value),
            new OracleParameter("p3", (object?)m.id_pieza ?? DBNull.Value),
            new OracleParameter("p4", (object?)m.precio_contrato ?? DBNull.Value),
            new OracleParameter("p5", (object?)m.tiempo_entrega_dias ?? DBNull.Value),
            new OracleParameter("p6", (object?)m.calificacion ?? DBNull.Value),
            new OracleParameter("p7", (object?)m.ultima_compra ?? DBNull.Value),
            new OracleParameter("p8", (object?)m.activo ?? DBNull.Value)
        };
    }
}