using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class OrdenCompraService : IOrdenCompraService
    {
        private readonly DBContext _context;
        public OrdenCompraService(DBContext context) => _context = context;

        public async Task<List<OrdenCompra>> ListarTodo() => await _context.ORDENES_COMPRA.ToListAsync();
        public async Task<OrdenCompra?> ObtenerPorId(int id) => await _context.ORDENES_COMPRA.FindAsync(id);

        public async Task<bool> Insertar(OrdenCompra m)
        {
            try
            {
                string sql = "BEGIN pkg_ordenes_compra.insert_orden(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11, :p12); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT ORDEN_COMPRA: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(OrdenCompra m)
        {
            try
            {
                string sql = "BEGIN pkg_ordenes_compra.update_orden(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11, :p12); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE ORDEN_COMPRA: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_ordenes_compra.delete_orden(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE ORDEN_COMPRA: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(OrdenCompra m) => new OracleParameter[]
        {
            new OracleParameter("p1",  m.id_orden),
            new OracleParameter("p2",  m.id_proveedor),
            new OracleParameter("p3",  m.fecha_orden),
            new OracleParameter("p4",  m.fecha_entrega_estimada),
            new OracleParameter("p5",  m.fecha_entrega_real),
            new OracleParameter("p6",  m.estado),
            new OracleParameter("p7",  m.subtotal),
            new OracleParameter("p8",  m.impuestos),
            new OracleParameter("p9",  m.total),
            new OracleParameter("p10", m.condiciones_entrega),
            new OracleParameter("p11", m.solicitado_por),
            new OracleParameter("p12", m.autorizado_por)
        };
    }
}