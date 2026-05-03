using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class EmpCapaService : IEmpCapaService
    {
        private readonly DBContext _context;
        public EmpCapaService(DBContext context) => _context = context;

        public async Task<List<EmpleadoCapacitacion>> ListarTodo() => await _context.EMPLEADOS_CAPACITACION.ToListAsync();
        public async Task<EmpleadoCapacitacion?> ObtenerPorId(int id) => await _context.EMPLEADOS_CAPACITACION.FindAsync(id);

        public async Task<bool> Insertar(EmpleadoCapacitacion m)
        {
            try
            {
                string sql = "BEGIN pkg_empleados_capacitacion.insert_empleado_capacitacion(:p1, :p2, :p3, :p4, :p5, :p6, :p7); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT EMP_CAPA: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(EmpleadoCapacitacion m)
        {
            try
            {
                string sql = "BEGIN pkg_empleados_capacitacion.update_empleado_capacitacion(:p1, :p2, :p3, :p4, :p5, :p6, :p7); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE EMP_CAPA: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_empleados_capacitacion.delete_empleado_capacitacion(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE EMP_CAPA: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(EmpleadoCapacitacion m) => new OracleParameter[]
        {
            new OracleParameter("p1", m.id_empleado),
            new OracleParameter("p2", m.id_capacitacion),
            new OracleParameter("p3", (object?)m.fecha_asignacion ?? DBNull.Value),
            new OracleParameter("p4", (object?)m.estado ?? DBNull.Value),
            new OracleParameter("p5", (object?)m.fecha_completado ?? DBNull.Value),
            new OracleParameter("p6", (object?)m.calificacion ?? DBNull.Value),
            new OracleParameter("p7", (object?)m.certificado_obtenido ?? DBNull.Value)
        };
    }
}