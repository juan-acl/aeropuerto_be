using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class FacturacionCombustibleService : IFacturacionCombustibleService
    {
        private readonly DBContext _context;

        public FacturacionCombustibleService(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(FacturacionCombustible m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_carga_combustible", (object?)m.IdCargaCombustible ?? DBNull.Value),
                new OracleParameter("p_numero_factura", (object?)m.NumeroFactura ?? DBNull.Value),
                new OracleParameter("p_id_aerolinea", (object?)m.IdAerolinea ?? DBNull.Value),
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
                new OracleParameter("p_forma_pago", (object?)m.FormaPago ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_facturacion_combustible.insert_factura(:p_id_carga_combustible, :p_numero_factura, :p_id_aerolinea, :p_fecha_emision, :p_cantidad_litros, :p_precio_unitario, :p_subtotal, :p_impuestos, :p_total, :p_moneda, :p_fecha_vencimiento, :p_pagada, :p_fecha_pago, :p_forma_pago); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Actualizar(int id, FacturacionCombustible m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_factura", (object?)m.IdFacturaCombustible ?? DBNull.Value),
                new OracleParameter("p_id_carga_combustible", (object?)m.IdCargaCombustible ?? DBNull.Value),
                new OracleParameter("p_numero_factura", (object?)m.NumeroFactura ?? DBNull.Value),
                new OracleParameter("p_id_aerolinea", (object?)m.IdAerolinea ?? DBNull.Value),
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
                new OracleParameter("p_forma_pago", (object?)m.FormaPago ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_facturacion_combustible.update_factura(:p_id_factura, :p_id_carga_combustible, :p_numero_factura, :p_id_aerolinea, :p_fecha_emision, :p_cantidad_litros, :p_precio_unitario, :p_subtotal, :p_impuestos, :p_total, :p_moneda, :p_fecha_vencimiento, :p_pagada, :p_fecha_pago, :p_forma_pago); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_facturacion_combustible.delete_factura(:p_id_factura); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_factura", id));
            return true;
        }

        public async Task<List<FacturacionCombustible>> ListarTodo()
        {
            return await _context.Set<FacturacionCombustible>().ToListAsync();
        }

        public async Task<FacturacionCombustible?> ObtenerPorId(int id) => await _context.Set<FacturacionCombustible>().FindAsync(id);
    }
}
