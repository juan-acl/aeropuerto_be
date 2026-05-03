using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly DBContext _context;
        public DepartamentoService(DBContext context) => _context = context;

        public async Task<List<Departamento>> ListarTodo() => await _context.DEPARTAMENTOS.ToListAsync();
        public async Task<Departamento?> ObtenerPorId(int id) => await _context.DEPARTAMENTOS.FindAsync(id);

        public async Task<bool> Insertar(Departamento m)
        {
            try
            {
                string sql = "BEGIN pkg_departamentos.insert_departamento(:p1, :p2, :p3, :p4, :p5, :p6, :p7); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT DEPARTAMENTO: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(Departamento m)
        {
            try
            {
                string sql = "BEGIN pkg_departamentos.update_departamento(:p1, :p2, :p3, :p4, :p5, :p6, :p7); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE DEPARTAMENTO: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_departamentos.delete_departamento(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE DEPARTAMENTO: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(Departamento m) => new OracleParameter[]
        {
            new OracleParameter("p1", m.id_departamento),
            new OracleParameter("p2", m.nombre_departamento),
            new OracleParameter("p3", m.descripcion),
            new OracleParameter("p4", m.ubicacion),
            new OracleParameter("p5", m.presupuesto_anual),
            new OracleParameter("p6", m.gerente_id),
            new OracleParameter("p7", m.activo)
        };
    }
}