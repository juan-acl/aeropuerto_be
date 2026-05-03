using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PiezaReemplazoService : IPiezaReemplazoService
    {
        private readonly DBContext _context;
        public PiezaReemplazoService(DBContext context) => _context = context;

        public async Task<List<PiezaReemplazo>> ListarTodo() => await _context.PIEZAS_REEMPLAZO.ToListAsync();
        public async Task<PiezaReemplazo?> ObtenerPorId(int id) => await _context.PIEZAS_REEMPLAZO.FindAsync(id);

        public async Task<bool> Insertar(PiezaReemplazo m)
        {
            try
            {
                string sql = "BEGIN pkg_piezas_reemplazo.insert_pieza_reemplazo(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11, :p12, :p13, :p14, :p15); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT PIEZA_REEMPLAZO: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(PiezaReemplazo m)
        {
            try
            {
                string sql = "BEGIN pkg_piezas_reemplazo.update_pieza_reemplazo(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11, :p12, :p13, :p14, :p15); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE PIEZA_REEMPLAZO: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_piezas_reemplazo.delete_pieza_reemplazo(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE PIEZA_REEMPLAZO: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(PiezaReemplazo m) => new OracleParameter[]
        {
            new OracleParameter("p1", m.id_pieza),
            new OracleParameter("p2", (object?)m.codigo_pieza ?? DBNull.Value),
            new OracleParameter("p3", (object?)m.nombre_pieza ?? DBNull.Value),
            new OracleParameter("p4", (object?)m.descripcion ?? DBNull.Value),
            new OracleParameter("p5", (object?)m.id_modelo_avion ?? DBNull.Value),
            new OracleParameter("p6", (object?)m.id_fabricante ?? DBNull.Value),
            new OracleParameter("p7", (object?)m.numero_parte_fabricante ?? DBNull.Value),
            new OracleParameter("p8", (object?)m.stock_actual ?? DBNull.Value),
            new OracleParameter("p9", (object?)m.stock_minimo ?? DBNull.Value),
            new OracleParameter("p10", (object?)m.stock_maximo ?? DBNull.Value),
            new OracleParameter("p11", (object?)m.ubicacion_almacen ?? DBNull.Value),
            new OracleParameter("p12", (object?)m.precio_unitario ?? DBNull.Value),
            new OracleParameter("p13", (object?)m.moneda ?? DBNull.Value),
            new OracleParameter("p14", (object?)m.tiempo_reorden_dias ?? DBNull.Value),
            new OracleParameter("p15", (object?)m.activo ?? DBNull.Value)
        };
    }
}