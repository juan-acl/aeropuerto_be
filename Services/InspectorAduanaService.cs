using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class InspectorAduanaService : IInspectorAduanaService
    {
        private readonly DBContext _context;
        public InspectorAduanaService(DBContext context) => _context = context;

        public async Task<List<InspectorAduanas>> ListarTodo() => await _context.INSPECTORES_ADUANAS.ToListAsync();
        public async Task<InspectorAduanas?> ObtenerPorId(int id) => await _context.INSPECTORES_ADUANAS.FindAsync(id);

        public async Task<bool> Insertar(InspectorAduanas m)
        {
            try
            {
                string sql = "BEGIN pkg_inspectores_aduanas.insert_inspector(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT INSPECTOR_ADUANA: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(InspectorAduanas m)
        {
            try
            {
                string sql = "BEGIN pkg_inspectores_aduanas.update_inspector(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE INSPECTOR_ADUANA: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_inspectores_aduanas.delete_inspector(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE INSPECTOR_ADUANA: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(InspectorAduanas m) => new OracleParameter[]
        {
            new OracleParameter("p1", m.id_inspector),
            new OracleParameter("p2", m.id_empleado),
            new OracleParameter("p3", m.numero_licencia),
            new OracleParameter("p4", m.nivel_autorizacion),
            new OracleParameter("p5", m.fecha_certificacion),
            new OracleParameter("p6", m.fecha_vencimiento_certificacion),
            new OracleParameter("p7", m.especialidad),
            new OracleParameter("p8", m.activo)
        };
    }
}