using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly DBContext _context;
        public EmpleadoService(DBContext context) => _context = context;

        public async Task<List<Empleado>> ListarTodo() => await _context.EMPLEADOS.ToListAsync();
        public async Task<Empleado?> ObtenerPorId(int id) => await _context.EMPLEADOS.FindAsync(id);

        public async Task<bool> Insertar(Empleado m)
        {
            try
            {
                string sql = "BEGIN pkg_empleados.insert_empleado(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11, :p12, :p13, :p14, :p15, :p16, :p17, :p18); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT EMPLEADO: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(Empleado m)
        {
            try
            {
                string sql = "BEGIN pkg_empleados.update_empleado(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11, :p12, :p13, :p14, :p15, :p16, :p17, :p18); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE EMPLEADO: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_empleados.delete_empleado(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE EMPLEADO: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(Empleado m) => new OracleParameter[]
        {
            new OracleParameter("p1",  m.id_empleado),
            new OracleParameter("p2",  m.codigo_empleado),
            new OracleParameter("p3",  m.nombres),
            new OracleParameter("p4",  m.apellidos),
            new OracleParameter("p5",  m.tipo_documento),
            new OracleParameter("p6",  m.numero_documento),
            new OracleParameter("p7",  m.fecha_nacimiento),
            new OracleParameter("p8",  m.nacionalidad),
            new OracleParameter("p9",  m.genero),
            new OracleParameter("p10", m.direccion),
            new OracleParameter("p11", m.telefono),
            new OracleParameter("p12", m.email),
            new OracleParameter("p13", m.fecha_contratacion),
            new OracleParameter("p14", m.departamento),
            new OracleParameter("p15", m.cargo),
            new OracleParameter("p16", m.salario_base),
            new OracleParameter("p17", m.tipo_contrato),
            new OracleParameter("p18", m.activo)
        };
    }
}