using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class CargaUbicacionService : ICargaUbicacionService
    {
        private readonly DBContext _context;
        public CargaUbicacionService(DBContext context) => _context = context;

        public async Task<List<CargaUbicacion>> ListarTodo() => await _context.CARGA_UBICACION.ToListAsync();
        public async Task<CargaUbicacion?> ObtenerPorId(int id) => await _context.CARGA_UBICACION.FindAsync(id);

        public async Task<bool> Insertar(CargaUbicacion m)
        {
            try
            {
                string sql = "BEGIN pkg_carga_ubicacion.insert_ubicacion(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT CARGA_UBICACION: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(CargaUbicacion m)
        {
            try
            {
                string sql = "BEGIN pkg_carga_ubicacion.update_ubicacion(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE CARGA_UBICACION: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_carga_ubicacion.delete_ubicacion(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE CARGA_UBICACION: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(CargaUbicacion m) => new OracleParameter[]
        {
            new OracleParameter("p1",  m.id_ubicacion),
            new OracleParameter("p2",  m.id_envio),
            new OracleParameter("p3",  m.id_bodega),
            new OracleParameter("p4",  m.fecha_ingreso),
            new OracleParameter("p5",  m.fecha_salida),
            new OracleParameter("p6",  m.posicion_estante),
            new OracleParameter("p7",  m.posicion_fila),
            new OracleParameter("p8",  m.posicion_columna),
            new OracleParameter("p9",  m.responsable_ingreso),
            new OracleParameter("p10", m.responsable_salida)
        };
    }
}