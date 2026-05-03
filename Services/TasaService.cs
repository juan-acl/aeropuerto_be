using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class TasaService : ITasaService
    {
        private readonly DBContext _context;
        public TasaService(DBContext context) => _context = context;

        public async Task<List<TasaAeroportuaria>> ListarTodo() => await _context.TASAS_AEROPORTUARIAS.ToListAsync();
        public async Task<TasaAeroportuaria?> ObtenerPorId(int id) => await _context.TASAS_AEROPORTUARIAS.FindAsync(id);

        public async Task<bool> Insertar(TasaAeroportuaria m)
        {
            try
            {
                string sql = "BEGIN pkg_tasas_aeroportuarias.insert_tasa(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT TASA: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(TasaAeroportuaria m)
        {
            try
            {
                string sql = "BEGIN pkg_tasas_aeroportuarias.update_tasa(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE TASA: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_tasas_aeroportuarias.delete_tasa(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE TASA: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(TasaAeroportuaria m) => new OracleParameter[]
        {
            new OracleParameter("p1", m.id_tasa),
            new OracleParameter("p2", m.nombre_tasa),
            new OracleParameter("p3", m.tipo_tasa),
            new OracleParameter("p4", m.monto),
            new OracleParameter("p5", m.moneda),
            new OracleParameter("p6", m.calculo_porcentaje),
            new OracleParameter("p7", m.aplica_a),
            new OracleParameter("p8", m.activa),
            new OracleParameter("p9", m.fecha_actualizacion)
        };
    }
}