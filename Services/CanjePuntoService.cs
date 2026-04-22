using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class CanjePuntoService : ICanjePuntoService
    {
        private readonly DBContext _context;
        public CanjePuntoService(DBContext context) => _context = context;

        public async Task<List<CanjesPuntos>> ListarTodo()
        {
            try { return await _context.CanjesPuntos.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo CanjesPuntos: {ex.Message}"); return new List<CanjesPuntos>(); }
        }

        public async Task<CanjesPuntos?> ObtenerPorId(int id)
        {
            try { return await _context.CanjesPuntos.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId CanjesPuntos: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(CanjesPuntos m)
        {
            try
            {
                string sql = "BEGIN pkg_canjes_puntos.insert_canje(:p_id_pasajero, :p_id_lealtad, :p_fecha_canje, :p_puntos_utilizados, :p_tipo_canje, :p_descripcion_canje, :p_id_vuelo, :p_id_producto, :p_valor_monetario, :p_moneda, :p_estado_canje, :p_procesado_por, :p_observaciones); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_id_lealtad", m.IdLealtad),
                new OracleParameter("p_fecha_canje", (object?)m.FechaCanje ?? DBNull.Value),
                new OracleParameter("p_puntos_utilizados", m.PuntosUtilizados),
                new OracleParameter("p_tipo_canje", (object?)m.TipoCanje ?? DBNull.Value),
                new OracleParameter("p_descripcion_canje", (object?)m.DescripcionCanje ?? DBNull.Value),
                new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                new OracleParameter("p_id_producto", (object?)m.IdProducto ?? DBNull.Value),
                new OracleParameter("p_valor_monetario", (object?)m.ValorMonetario ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_estado_canje", (object?)m.EstadoCanje ?? DBNull.Value),
                new OracleParameter("p_procesado_por", (object?)m.ProcesadoPor ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar CanjesPuntos: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, CanjesPuntos m)
        {
            try
            {
                string sql = "BEGIN pkg_canjes_puntos.update_canje(:p_id_canje_puntos, :p_id_pasajero, :p_id_lealtad, :p_fecha_canje, :p_puntos_utilizados, :p_tipo_canje, :p_descripcion_canje, :p_id_vuelo, :p_id_producto, :p_valor_monetario, :p_moneda, :p_estado_canje, :p_procesado_por, :p_observaciones); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_canje_puntos", id),
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_id_lealtad", m.IdLealtad),
                new OracleParameter("p_fecha_canje", (object?)m.FechaCanje ?? DBNull.Value),
                new OracleParameter("p_puntos_utilizados", m.PuntosUtilizados),
                new OracleParameter("p_tipo_canje", (object?)m.TipoCanje ?? DBNull.Value),
                new OracleParameter("p_descripcion_canje", (object?)m.DescripcionCanje ?? DBNull.Value),
                new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                new OracleParameter("p_id_producto", (object?)m.IdProducto ?? DBNull.Value),
                new OracleParameter("p_valor_monetario", (object?)m.ValorMonetario ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_estado_canje", (object?)m.EstadoCanje ?? DBNull.Value),
                new OracleParameter("p_procesado_por", (object?)m.ProcesadoPor ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar CanjesPuntos: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_canjes_puntos.delete_canje(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar CanjesPuntos: {ex.Message}"); return false; }
        }
    }
}
