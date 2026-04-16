using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class FacturasService : IFacturasService
    {
        private readonly DBContext _context;

        public FacturasService(DBContext context) => _context = context;

        public async Task<bool> Insertar(FacturasModel f)
        {
            var sql = @"INSERT INTO facturas 
                        (id_reserva, numero_factura, fecha_emision, subtotal, impuestos, total, moneda, datos_fiscales, pdf_factura) 
                        VALUES (:p_reserva, :p_num, SYSDATE, :p_sub, :p_imp, :p_total, :p_moneda, :p_datos, :p_pdf)";

            var parametros = new[] {
                new OracleParameter("p_reserva", f.IdReserva),
                new OracleParameter("p_num", (object?)f.NumeroFactura ?? DBNull.Value),
                new OracleParameter("p_sub", f.Subtotal),
                new OracleParameter("p_imp", f.Impuestos),
                new OracleParameter("p_total", f.Total),
                new OracleParameter("p_moneda", f.Moneda),
                new OracleParameter("p_datos", (object?)f.DatosFiscales ?? DBNull.Value),
                new OracleParameter("p_pdf", (object?)f.PdfFactura ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<FacturasModel?> ObtenerPorReserva(int idReserva)
        {
            return await _context.Facturas.FirstOrDefaultAsync(f => f.IdReserva == idReserva);
        }

        public async Task<List<FacturasModel>> ListarTodo()
        {
            return await _context.Facturas.ToListAsync();
        }

        public async Task<bool> Actualizar(int id, FacturasModel f)
        {
            var sql = @"UPDATE facturas 
                        SET numero_factura = :p_num, subtotal = :p_sub, impuestos = :p_imp, 
                            total = :p_total, datos_fiscales = :p_datos 
                        WHERE id_factura = :p_id";

            var parametros = new[] {
                new OracleParameter("p_num", f.NumeroFactura),
                new OracleParameter("p_sub", f.Subtotal),
                new OracleParameter("p_imp", f.Impuestos),
                new OracleParameter("p_total", f.Total),
                new OracleParameter("p_datos", f.DatosFiscales),
                new OracleParameter("p_id", id)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM facturas WHERE id_factura = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}