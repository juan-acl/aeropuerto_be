using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class SeguimientoCargaService : ISeguimientoCargaService
    {
        private readonly DBContext _context;
        public SeguimientoCargaService(DBContext context) => _context = context;

        public async Task<List<SeguimientoCarga>> ListarTodo() => await _context.SEGUIMIENTO_CARGA.ToListAsync();
        public async Task<SeguimientoCarga?> ObtenerPorId(int id) => await _context.SEGUIMIENTO_CARGA.FindAsync(id);

        public async Task<bool> Insertar(SeguimientoCarga m)
        {
            try
            {
                string sql = "BEGIN pkg_seguimiento_carga.insert_seguimiento(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT SEGUIMIENTO_CARGA: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(SeguimientoCarga m)
        {
            try
            {
                string sql = "BEGIN pkg_seguimiento_carga.update_seguimiento(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE SEGUIMIENTO_CARGA: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_seguimiento_carga.delete_seguimiento(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE SEGUIMIENTO_CARGA: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(SeguimientoCarga m) => new OracleParameter[]
        {
            new OracleParameter("p1", m.id_seguimiento),
            new OracleParameter("p2", m.id_envio),
            new OracleParameter("p3", m.fecha_hora),
            new OracleParameter("p4", m.ubicacion),
            new OracleParameter("p5", m.estado),
            new OracleParameter("p6", m.responsable),
            new OracleParameter("p7", m.observaciones),
            new OracleParameter("p8", m.temperatura_registrada),
            new OracleParameter("p9", m.incidente)
        };
    }
}