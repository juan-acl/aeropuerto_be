using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class BodegaCargaService : IBodegaCargaService
    {
        private readonly DBContext _context;
        public BodegaCargaService(DBContext context) => _context = context;

        public async Task<List<BodegaCarga>> ListarTodo() => await _context.BODEGAS_CARGA.ToListAsync();
        public async Task<BodegaCarga?> ObtenerPorId(int id) => await _context.BODEGAS_CARGA.FindAsync(id);

        public async Task<bool> Insertar(BodegaCarga m)
        {
            try
            {
                string sql = "BEGIN pkg_bodegas_carga.insert_bodega(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT BODEGA_CARGA: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(BodegaCarga m)
        {
            try
            {
                string sql = "BEGIN pkg_bodegas_carga.update_bodega(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE BODEGA_CARGA: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_bodegas_carga.delete_bodega(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE BODEGA_CARGA: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(BodegaCarga m) => new OracleParameter[]
        {
            new OracleParameter("p1",  m.id_bodega),
            new OracleParameter("p2",  m.codigo_bodega),
            new OracleParameter("p3",  m.nombre_bodega),
            new OracleParameter("p4",  m.ubicacion),
            new OracleParameter("p5",  m.capacidad_m3),
            new OracleParameter("p6",  m.capacidad_kg),
            new OracleParameter("p7",  m.tiene_refrigeracion),
            new OracleParameter("p8",  m.temperatura_controlada),
            new OracleParameter("p9",  m.tiene_acceso_restringido),
            new OracleParameter("p10", m.activo)
        };
    }
}