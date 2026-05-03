using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ManifiestoDetalleService : IManifiestoDetalleService
    {
        private readonly DBContext _context;
        public ManifiestoDetalleService(DBContext context) => _context = context;

        public async Task<List<ManifiestoDetalle>> ListarTodo() => await _context.MANIFIESTOS_DETALLE.ToListAsync();
        public async Task<ManifiestoDetalle?> ObtenerPorId(int id) => await _context.MANIFIESTOS_DETALLE.FindAsync(id);

        public async Task<bool> Insertar(ManifiestoDetalle m)
        {
            try
            {
                string sql = "BEGIN pkg_manifiestos_detalle.insert_detalle(:p1, :p2, :p3, :p4, :p5); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT MANIFIESTO_DETALLE: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(ManifiestoDetalle m)
        {
            try
            {
                string sql = "BEGIN pkg_manifiestos_detalle.update_detalle(:p1, :p2, :p3, :p4, :p5); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE MANIFIESTO_DETALLE: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_manifiestos_detalle.delete_detalle(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE MANIFIESTO_DETALLE: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(ManifiestoDetalle m) => new OracleParameter[]
        {
            new OracleParameter("p1", m.id_detalle),
            new OracleParameter("p2", m.id_manifiesto),
            new OracleParameter("p3", m.id_envio),
            new OracleParameter("p4", m.numero_orden),
            new OracleParameter("p5", m.observaciones)
        };
    }
}