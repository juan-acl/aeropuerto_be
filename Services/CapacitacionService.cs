using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class CapacitacionService : ICapacitacionService
    {
        private readonly DBContext _context;
        public CapacitacionService(DBContext context) => _context = context;

        public async Task<List<Capacitacion>> ListarTodo() => await _context.CAPACITACIONES.ToListAsync();
        public async Task<Capacitacion?> ObtenerPorId(int id) => await _context.CAPACITACIONES.FindAsync(id);

        public async Task<bool> Insertar(Capacitacion m)
        {
            try
            {
                string sql = "BEGIN pkg_capacitaciones.insert_capacitacion(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT CAPACITACION: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(Capacitacion m)
        {
            try
            {
                string sql = "BEGIN pkg_capacitaciones.update_capacitacion(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE CAPACITACION: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_capacitaciones.delete_capacitacion(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE CAPACITACION: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(Capacitacion m) => new OracleParameter[]
        {
            new OracleParameter("p1",  m.id_capacitacion),
            new OracleParameter("p2",  m.nombre_curso),
            new OracleParameter("p3",  m.descripcion),
            new OracleParameter("p4",  m.tipo_capacitacion),
            new OracleParameter("p5",  m.duracion_horas),
            new OracleParameter("p6",  m.costo),
            new OracleParameter("p7",  m.proveedor),
            new OracleParameter("p8",  m.fecha_inicio),
            new OracleParameter("p9",  m.fecha_fin),
            new OracleParameter("p10", m.activo)
        };
    }
}