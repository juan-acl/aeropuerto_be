using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class CanjePuntoService : ICanjePuntoService
    {
        private readonly DBContext _context;
        public CanjePuntoService(DBContext context) => _context = context;

        public async Task<bool> Insertar(CanjesPuntos m)
        {
            var p = new[] {
                new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_id_lealtad", (object?)m.IdLealtad ?? DBNull.Value),
                new OracleParameter("p_fecha_canje", (object?)m.FechaCanje ?? DBNull.Value),
                new OracleParameter("p_puntos_utilizados", (object?)m.PuntosUtilizados ?? DBNull.Value),
                new OracleParameter("p_tipo_canje", (object?)m.TipoCanje ?? DBNull.Value),
                new OracleParameter("p_descripcion_canje", (object?)m.DescripcionCanje ?? DBNull.Value),
                new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                new OracleParameter("p_id_producto", (object?)m.IdProducto ?? DBNull.Value),
                new OracleParameter("p_valor_monetario", (object?)m.ValorMonetario ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_estado_canje", (object?)m.EstadoCanje ?? DBNull.Value),
                new OracleParameter("p_procesado_por", (object?)m.ProcesadoPor ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_canjes_puntos.insert_canje(:p_id_pasajero, :p_id_lealtad, :p_fecha_canje, :p_puntos_utilizados, :p_tipo_canje, :p_descripcion_canje, :p_id_vuelo, :p_id_producto, :p_valor_monetario, :p_moneda, :p_estado_canje, :p_procesado_por, :p_observaciones); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, CanjesPuntos m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_canje_puntos", m.IdCanjePuntos)
            };
            p.AddRange(new[] {
                new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_id_lealtad", (object?)m.IdLealtad ?? DBNull.Value),
                new OracleParameter("p_fecha_canje", (object?)m.FechaCanje ?? DBNull.Value),
                new OracleParameter("p_puntos_utilizados", (object?)m.PuntosUtilizados ?? DBNull.Value),
                new OracleParameter("p_tipo_canje", (object?)m.TipoCanje ?? DBNull.Value),
                new OracleParameter("p_descripcion_canje", (object?)m.DescripcionCanje ?? DBNull.Value),
                new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                new OracleParameter("p_id_producto", (object?)m.IdProducto ?? DBNull.Value),
                new OracleParameter("p_valor_monetario", (object?)m.ValorMonetario ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_estado_canje", (object?)m.EstadoCanje ?? DBNull.Value),
                new OracleParameter("p_procesado_por", (object?)m.ProcesadoPor ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_canjes_puntos.update_canje(:p_id_canje_puntos, :p_id_pasajero, :p_id_lealtad, :p_fecha_canje, :p_puntos_utilizados, :p_tipo_canje, :p_descripcion_canje, :p_id_vuelo, :p_id_producto, :p_valor_monetario, :p_moneda, :p_estado_canje, :p_procesado_por, :p_observaciones); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_canjes_puntos.delete_canje(:p_id_canje_puntos); END;", 
                new OracleParameter("p_id_canje_puntos", id));
            return true;
        }

        public async Task<List<CanjesPuntos>> ListarTodo() => await _context.Set<CanjesPuntos>().ToListAsync();

        public async Task<CanjesPuntos?> ObtenerPorId(int id) => await _context.Set<CanjesPuntos>().FindAsync(id);
    }
}
