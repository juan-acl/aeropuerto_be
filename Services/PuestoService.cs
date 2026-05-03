using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PuestoService : IPuestoService
    {
        private readonly DBContext _context;
        public PuestoService(DBContext context) => _context = context;

        public async Task<List<PuestoTrabajo>> ListarTodo() => await _context.PUESTOS_TRABAJO.ToListAsync();
        public async Task<PuestoTrabajo?> ObtenerPorId(int id) => await _context.PUESTOS_TRABAJO.FindAsync(id);

        public async Task<bool> Insertar(PuestoTrabajo m)
        {
            try
            {
                string sql = "BEGIN pkg_puestos_trabajo.insert_puesto(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT PUESTO: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(PuestoTrabajo m)
        {
            try
            {
                string sql = "BEGIN pkg_puestos_trabajo.update_puesto(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE PUESTO: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_puestos_trabajo.delete_puesto(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE PUESTO: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(PuestoTrabajo m) => new OracleParameter[]
        {
            new OracleParameter("p1", m.id_puesto),
            new OracleParameter("p2", m.nombre_puesto),
            new OracleParameter("p3", m.id_departamento),
            new OracleParameter("p4", m.nivel_jerarquico),
            new OracleParameter("p5", m.salario_minimo),
            new OracleParameter("p6", m.salario_maximo),
            new OracleParameter("p7", m.descripcion_funciones),
            new OracleParameter("p8", m.requisitos),
            new OracleParameter("p9", m.activo)
        };
    }
}