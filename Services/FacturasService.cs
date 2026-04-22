using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class FacturasService : IFacturasService
    {
        private readonly DBContext _context;
        public FacturasService(DBContext context) => _context = context;

        public async Task<List<FacturasModel>> ListarTodo()
        {
            try { return await _context.Facturas.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo FacturasModel: {ex.Message}"); return new List<FacturasModel>(); }
        }

        public async Task<FacturasModel?> ObtenerPorId(int id)
        {
            try { return await _context.Facturas.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId FacturasModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(FacturasModel m)
        {
            try
            {
                string sql = "BEGIN pkg_facturas.insert_factura(:p_id_reserva, :p_numero_factura, :p_fecha_emision, :p_subtotal, :p_impuestos, :p_total, :p_moneda, :p_datos_fiscales, :p_pdf_factura); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_reserva", m.IdReserva),
                new OracleParameter("p_numero_factura", (object?)m.NumeroFactura ?? DBNull.Value),
                new OracleParameter("p_fecha_emision", (object?)m.FechaEmision ?? DBNull.Value),
                new OracleParameter("p_subtotal", m.Subtotal),
                new OracleParameter("p_impuestos", m.Impuestos),
                new OracleParameter("p_total", m.Total),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_datos_fiscales", (object?)m.DatosFiscales ?? DBNull.Value),
                new OracleParameter("p_pdf_factura", (object?)m.PdfFactura ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar FacturasModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, FacturasModel m)
        {
            try
            {
                string sql = "BEGIN pkg_facturas.update_factura(:p_id_factura, :p_id_reserva, :p_numero_factura, :p_fecha_emision, :p_subtotal, :p_impuestos, :p_total, :p_moneda, :p_datos_fiscales, :p_pdf_factura); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_factura", id),
                new OracleParameter("p_id_reserva", m.IdReserva),
                new OracleParameter("p_numero_factura", (object?)m.NumeroFactura ?? DBNull.Value),
                new OracleParameter("p_fecha_emision", (object?)m.FechaEmision ?? DBNull.Value),
                new OracleParameter("p_subtotal", m.Subtotal),
                new OracleParameter("p_impuestos", m.Impuestos),
                new OracleParameter("p_total", m.Total),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_datos_fiscales", (object?)m.DatosFiscales ?? DBNull.Value),
                new OracleParameter("p_pdf_factura", (object?)m.PdfFactura ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar FacturasModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_facturas.delete_factura(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar FacturasModel: {ex.Message}"); return false; }
        }
    }
}
