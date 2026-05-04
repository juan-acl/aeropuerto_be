using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class OrdenDetalleService : IOrdenDetalleService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public OrdenDetalleService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<OrdenDetalle>> ListarTodo()
        {
            try { return await _replica.ORDENES_DETALLE.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo OrdenDetalle: {ex.Message}"); return new List<OrdenDetalle>(); }
        }

        public async Task<OrdenDetalle ?> ObtenerPorId(int id)
        {
            try { return await _replica.ORDENES_DETALLE.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId OrdenDetalle: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(OrdenDetalle m)
        {
            try
            {
                string sql = "BEGIN pkg_ordenes_detalle.insert_detalle(:p_id_orden, :p_descripcion, :p_cantidad, :p_precio_unitario, :p_subtotal_linea, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_orden", m.IdOrden),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_cantidad", m.Cantidad),
                    new OracleParameter("p_precio_unitario", m.PrecioUnitario),
                    new OracleParameter("p_subtotal_linea", DBNull.Value),
                    new OracleParameter("p_observaciones", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar OrdenDetalle: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, OrdenDetalle m)
        {
            try
            {
                string sql = "BEGIN pkg_ordenes_detalle.update_detalle(:p_id_detalle, :p_id_orden, :p_descripcion, :p_cantidad, :p_precio_unitario, :p_subtotal_linea, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_detalle", id),
                    new OracleParameter("p_id_orden", m.IdOrden),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_cantidad", m.Cantidad),
                    new OracleParameter("p_precio_unitario", m.PrecioUnitario),
                    new OracleParameter("p_subtotal_linea", DBNull.Value),
                    new OracleParameter("p_observaciones", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar OrdenDetalle: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_ordenes_detalle.delete_detalle(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar OrdenDetalle: {ex.Message}"); throw; }
        }
    }
}
