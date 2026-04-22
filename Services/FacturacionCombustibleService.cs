using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class FacturacionCombustibleService : IFacturacionCombustibleService
    {
        private readonly DBContext _context;
        public FacturacionCombustibleService(DBContext context) => _context = context;

        public async Task<List<FacturacionCombustible>> ListarTodo()
        {
            try { return await _context.FacturacionCombustible.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo FacturacionCombustible: {ex.Message}"); return new List<FacturacionCombustible>(); }
        }

        public async Task<FacturacionCombustible?> ObtenerPorId(int id)
        {
            try { return await _context.FacturacionCombustible.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId FacturacionCombustible: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(FacturacionCombustible m)
        {
            try
            {
                string sql = "BEGIN pkg_facturacion_combustible.insert_factura(:p_id_carga_combustible, :p_numero_factura, :p_id_aerolinea, :p_fecha_emision, :p_cantidad_litros, :p_precio_unitario, :p_subtotal, :p_impuestos, :p_total, :p_moneda, :p_fecha_vencimiento, :p_pagada, :p_fecha_pago, :p_forma_pago); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_carga_combustible", m.IdCargaCombustible),
                new OracleParameter("p_numero_factura", (object?)m.NumeroFactura ?? DBNull.Value),
                new OracleParameter("p_id_aerolinea", m.IdAerolinea),
                new OracleParameter("p_fecha_emision", (object?)m.FechaEmision ?? DBNull.Value),
                new OracleParameter("p_cantidad_litros", (object?)m.CantidadLitros ?? DBNull.Value),
                new OracleParameter("p_precio_unitario", (object?)m.PrecioUnitario ?? DBNull.Value),
                new OracleParameter("p_subtotal", (object?)m.Subtotal ?? DBNull.Value),
                new OracleParameter("p_impuestos", (object?)m.Impuestos ?? DBNull.Value),
                new OracleParameter("p_total", (object?)m.Total ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                new OracleParameter("p_pagada", (object?)m.Pagada ?? DBNull.Value),
                new OracleParameter("p_fecha_pago", (object?)m.FechaPago ?? DBNull.Value),
                new OracleParameter("p_forma_pago", (object?)m.FormaPago ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar FacturacionCombustible: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, FacturacionCombustible m)
        {
            try
            {
                string sql = "BEGIN pkg_facturacion_combustible.update_factura(:p_id_factura_combustible, :p_id_carga_combustible, :p_numero_factura, :p_id_aerolinea, :p_fecha_emision, :p_cantidad_litros, :p_precio_unitario, :p_subtotal, :p_impuestos, :p_total, :p_moneda, :p_fecha_vencimiento, :p_pagada, :p_fecha_pago, :p_forma_pago); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_factura_combustible", id),
                new OracleParameter("p_id_carga_combustible", m.IdCargaCombustible),
                new OracleParameter("p_numero_factura", (object?)m.NumeroFactura ?? DBNull.Value),
                new OracleParameter("p_id_aerolinea", m.IdAerolinea),
                new OracleParameter("p_fecha_emision", (object?)m.FechaEmision ?? DBNull.Value),
                new OracleParameter("p_cantidad_litros", (object?)m.CantidadLitros ?? DBNull.Value),
                new OracleParameter("p_precio_unitario", (object?)m.PrecioUnitario ?? DBNull.Value),
                new OracleParameter("p_subtotal", (object?)m.Subtotal ?? DBNull.Value),
                new OracleParameter("p_impuestos", (object?)m.Impuestos ?? DBNull.Value),
                new OracleParameter("p_total", (object?)m.Total ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                new OracleParameter("p_pagada", (object?)m.Pagada ?? DBNull.Value),
                new OracleParameter("p_fecha_pago", (object?)m.FechaPago ?? DBNull.Value),
                new OracleParameter("p_forma_pago", (object?)m.FormaPago ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar FacturacionCombustible: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_facturacion_combustible.delete_factura(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar FacturacionCombustible: {ex.Message}"); return false; }
        }
    }
}
