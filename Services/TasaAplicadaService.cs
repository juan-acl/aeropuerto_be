using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class TasaAplicadaService : ITasaAplicadaService
    {
        private readonly DBContext _context;
        public TasaAplicadaService(DBContext context) => _context = context;

        public async Task<List<TasaAplicada>> ListarTodo() => await _context.TASAS_APLICADAS.ToListAsync();
        public async Task<TasaAplicada?> ObtenerPorId(int id) => await _context.TASAS_APLICADAS.FindAsync(id);

        public async Task<bool> Insertar(TasaAplicada m)
        {
            try
            {
                string sql = "BEGIN pkg_tasas_aplicadas.insert_tasa_aplicada(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT TASA_APLICADA: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(TasaAplicada m)
        {
            try
            {
                string sql = "BEGIN pkg_tasas_aplicadas.update_tasa_aplicada(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE TASA_APLICADA: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_tasas_aplicadas.delete_tasa_aplicada(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE TASA_APLICADA: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(TasaAplicada m) => new OracleParameter[]
        {
            new OracleParameter("p1", m.id_aplicacion),
            new OracleParameter("p2", m.id_tasa),
            new OracleParameter("p3", m.id_vuelo),
            new OracleParameter("p4", m.id_reserva),
            new OracleParameter("p5", m.fecha_aplicacion),
            new OracleParameter("p6", m.monto_aplicado),
            new OracleParameter("p7", m.facturado),
            new OracleParameter("p8", m.fecha_factura)
        };
    }
}