using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class PedidoCombustibleService : IPedidosCombustibleService
    {
        private readonly DBContext _context;

        public PedidoCombustibleService(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(PedidosCombustible m)
        {
            var parametros = new[] {
                new OracleParameter("p_numero_pedido", (object?)m.NumeroPedido ?? DBNull.Value),
                new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                new OracleParameter("p_cantidad_solicitada_litros", (object?)m.CantidadSolicitadaLitros ?? DBNull.Value),
                new OracleParameter("p_tipo_combustible", (object?)m.TipoCombustible ?? DBNull.Value),
                new OracleParameter("p_fecha_pedido", (object?)m.FechaPedido ?? DBNull.Value),
                new OracleParameter("p_fecha_requerida", (object?)m.FechaRequerida ?? DBNull.Value),
                new OracleParameter("p_estado_pedido", (object?)m.EstadoPedido ?? DBNull.Value),
                new OracleParameter("p_prioridad", (object?)m.Prioridad ?? DBNull.Value),
                new OracleParameter("p_solicitado_por", (object?)m.SolicitadoPor ?? DBNull.Value),
                new OracleParameter("p_aprobado_por", (object?)m.AprobadoPor ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_pedidos_combustible.insert_pedidocombustible(:p_numero_pedido, :p_id_vuelo, :p_cantidad_solicitada_litros, :p_tipo_combustible, :p_fecha_pedido, :p_fecha_requerida, :p_estado_pedido, :p_prioridad, :p_solicitado_por, :p_aprobado_por, :p_observaciones); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Actualizar(int id, PedidosCombustible m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_pedidocombustible", (object?)m.IdPedidoCombustible ?? DBNull.Value),
                new OracleParameter("p_numero_pedido", (object?)m.NumeroPedido ?? DBNull.Value),
                new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                new OracleParameter("p_cantidad_solicitada_litros", (object?)m.CantidadSolicitadaLitros ?? DBNull.Value),
                new OracleParameter("p_tipo_combustible", (object?)m.TipoCombustible ?? DBNull.Value),
                new OracleParameter("p_fecha_pedido", (object?)m.FechaPedido ?? DBNull.Value),
                new OracleParameter("p_fecha_requerida", (object?)m.FechaRequerida ?? DBNull.Value),
                new OracleParameter("p_estado_pedido", (object?)m.EstadoPedido ?? DBNull.Value),
                new OracleParameter("p_prioridad", (object?)m.Prioridad ?? DBNull.Value),
                new OracleParameter("p_solicitado_por", (object?)m.SolicitadoPor ?? DBNull.Value),
                new OracleParameter("p_aprobado_por", (object?)m.AprobadoPor ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_pedidos_combustible.update_pedidocombustible(:p_id_pedidocombustible, :p_numero_pedido, :p_id_vuelo, :p_cantidad_solicitada_litros, :p_tipo_combustible, :p_fecha_pedido, :p_fecha_requerida, :p_estado_pedido, :p_prioridad, :p_solicitado_por, :p_aprobado_por, :p_observaciones); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_pedidos_combustible.delete_pedidocombustible(:p_id_pedidocombustible); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_pedidocombustible", id));
            return true;
        }

        public async Task<List<PedidosCombustible>> ListarTodo()
        {
            return await _context.Set<PedidosCombustible>().ToListAsync();
        }


        public async Task<PedidosCombustible?> ObtenerPorId(int id) => await _context.Set<PedidosCombustible>().FindAsync(id);
    }
}
