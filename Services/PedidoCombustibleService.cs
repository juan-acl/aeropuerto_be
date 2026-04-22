using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class PedidoCombustibleService : IPedidoCombustibleService
    {
        private readonly DBContext _context;
        public PedidoCombustibleService(DBContext context) => _context = context;

        public async Task<List<PedidosCombustible>> ListarTodo()
        {
            try { return await _context.PedidosCombustible.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PedidosCombustible: {ex.Message}"); return new List<PedidosCombustible>(); }
        }

        public async Task<PedidosCombustible?> ObtenerPorId(int id)
        {
            try { return await _context.PedidosCombustible.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PedidosCombustible: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PedidosCombustible m)
        {
            try
            {
                string sql = "BEGIN pkg_pedidos_combustible.insert_pedido(:p_numero_pedido, :p_id_vuelo, :p_cantidad_solicitada_litros, :p_tipo_combustible, :p_fecha_pedido, :p_fecha_requerida, :p_estado_pedido, :p_prioridad, :p_solicitado_por, :p_aprobado_por, :p_observaciones); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_numero_pedido", (object?)m.NumeroPedido ?? DBNull.Value),
                new OracleParameter("p_id_vuelo", m.IdVuelo),
                new OracleParameter("p_cantidad_solicitada_litros", (object?)m.CantidadSolicitadaLitros ?? DBNull.Value),
                new OracleParameter("p_tipo_combustible", (object?)m.TipoCombustible ?? DBNull.Value),
                new OracleParameter("p_fecha_pedido", (object?)m.FechaPedido ?? DBNull.Value),
                new OracleParameter("p_fecha_requerida", (object?)m.FechaRequerida ?? DBNull.Value),
                new OracleParameter("p_estado_pedido", (object?)m.EstadoPedido ?? DBNull.Value),
                new OracleParameter("p_prioridad", (object?)m.Prioridad ?? DBNull.Value),
                new OracleParameter("p_solicitado_por", (object?)m.SolicitadoPor ?? DBNull.Value),
                new OracleParameter("p_aprobado_por", (object?)m.AprobadoPor ?? DBNull.Value),
                new OracleParameter("p_observaciones", DBNull.Value /* Observaciones */)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar PedidosCombustible: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, PedidosCombustible m)
        {
            try
            {
                string sql = "BEGIN pkg_pedidos_combustible.update_pedido(:p_id_pedido_combustible, :p_numero_pedido, :p_id_vuelo, :p_cantidad_solicitada_litros, :p_tipo_combustible, :p_fecha_pedido, :p_fecha_requerida, :p_estado_pedido, :p_prioridad, :p_solicitado_por, :p_aprobado_por, :p_observaciones); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_pedido_combustible", id),
                new OracleParameter("p_numero_pedido", (object?)m.NumeroPedido ?? DBNull.Value),
                new OracleParameter("p_id_vuelo", m.IdVuelo),
                new OracleParameter("p_cantidad_solicitada_litros", (object?)m.CantidadSolicitadaLitros ?? DBNull.Value),
                new OracleParameter("p_tipo_combustible", (object?)m.TipoCombustible ?? DBNull.Value),
                new OracleParameter("p_fecha_pedido", (object?)m.FechaPedido ?? DBNull.Value),
                new OracleParameter("p_fecha_requerida", (object?)m.FechaRequerida ?? DBNull.Value),
                new OracleParameter("p_estado_pedido", (object?)m.EstadoPedido ?? DBNull.Value),
                new OracleParameter("p_prioridad", (object?)m.Prioridad ?? DBNull.Value),
                new OracleParameter("p_solicitado_por", (object?)m.SolicitadoPor ?? DBNull.Value),
                new OracleParameter("p_aprobado_por", (object?)m.AprobadoPor ?? DBNull.Value),
                new OracleParameter("p_observaciones", DBNull.Value /* Observaciones */)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar PedidosCombustible: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_pedidos_combustible.delete_pedido(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar PedidosCombustible: {ex.Message}"); return false; }
        }
    }
}
