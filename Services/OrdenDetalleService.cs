using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class OrdenDetalleService : IOrdenDetalleService
    {
        private readonly DBContext _context;
        public OrdenDetalleService(DBContext context) => _context = context;

        public async Task<List<OrdenDetalle>> ListarTodo() => 
            await _context.ORDENES_DETALLE.ToListAsync();

        public async Task<OrdenDetalle?> ObtenerPorId(int id) =>
            await _context.ORDENES_DETALLE.FindAsync(id);

        public async Task<bool> Insertar(OrdenDetalle m)
        {
            try
            {
                // Siguiendo el estándar de tus paquetes de Oracle
                string sql = "BEGIN pkg_ordenes_detalle.insert_detalle(:p1, :p2, :p3, :p4, :p5, :p6); END;";
                var parameters = CrearParametros(m);
                await _context.Database.ExecuteSqlRawAsync(sql, parameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR INSERT ORDEN_DETALLE: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Actualizar(OrdenDetalle m)
        {
            try
            {
                string sql = "BEGIN pkg_ordenes_detalle.update_detalle(:p1, :p2, :p3, :p4, :p5, :p6); END;";
                var parameters = CrearParametros(m);
                await _context.Database.ExecuteSqlRawAsync(sql, parameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR UPDATE ORDEN_DETALLE: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_ordenes_detalle.delete_detalle(:p1); END;";
                var parameter = new OracleParameter("p1", id);
                await _context.Database.ExecuteSqlRawAsync(sql, parameter);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR DELETE ORDEN_DETALLE: {ex.Message}");
                return false;
            }
        }

        // Método privado para evitar la duplicidad de parámetros
        private OracleParameter[] CrearParametros(OrdenDetalle m)
        {
            return new OracleParameter[]
            {
                new OracleParameter("p1", m.id_detalle),
                new OracleParameter("p2", m.id_orden),
                new OracleParameter("p3", m.descripcion),
                new OracleParameter("p4", m.cantidad),
                new OracleParameter("p5", m.precio_unitario),
                new OracleParameter("p6", m.observaciones)
            };
        }
    }
}