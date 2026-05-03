using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ManifiestoCargaService : IManifiestoCargaService
    {
        private readonly DBContext _context;
        public ManifiestoCargaService(DBContext context) => _context = context;

        public async Task<List<ManifiestoCarga>> ListarTodo() => await _context.MANIFIESTOS_CARGA.ToListAsync();
        public async Task<ManifiestoCarga?> ObtenerPorId(int id) => await _context.MANIFIESTOS_CARGA.FindAsync(id);

        public async Task<bool> Insertar(ManifiestoCarga m)
        {
            try
            {
                string sql = "BEGIN pkg_manifiestos_carga.insert_manifiesto(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11, :p12); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT MANIFIESTO_CARGA: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(ManifiestoCarga m)
        {
            try
            {
                string sql = "BEGIN pkg_manifiestos_carga.update_manifiesto(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11, :p12); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE MANIFIESTO_CARGA: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_manifiestos_carga.delete_manifiesto(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE MANIFIESTO_CARGA: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(ManifiestoCarga m) => new OracleParameter[]
        {
            new OracleParameter("p1",  m.id_manifiesto),
            new OracleParameter("p2",  m.numero_manifiesto),
            new OracleParameter("p3",  m.id_vuelo),
            new OracleParameter("p4",  m.fecha_emision),
            new OracleParameter("p5",  m.total_bultos),
            new OracleParameter("p6",  m.peso_total_kg),
            new OracleParameter("p7",  m.volumen_total_m3),
            new OracleParameter("p8",  m.valor_total),
            new OracleParameter("p9",  m.agente_carga),
            new OracleParameter("p10", m.documento_adjunto),
            new OracleParameter("p11", m.estado),
            new OracleParameter("p12", m.emitido_por)
        };
    }
}