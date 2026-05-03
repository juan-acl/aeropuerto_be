using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class VacacionesService : IVacacionesService
    {
        private readonly DBContext _context;
        public VacacionesService(DBContext context) => _context = context;

        public async Task<List<VacacionPermiso>> ListarTodo() => await _context.VACACIONES_PERMISOS.ToListAsync();
        public async Task<VacacionPermiso?> ObtenerPorId(int id) => await _context.VACACIONES_PERMISOS.FindAsync(id);

        public async Task<bool> Insertar(VacacionPermiso m)
        {
            try
            {
                string sql = "BEGIN pkg_vacaciones_permisos.insert_solicitud(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11, :p12); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT VACACION: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(VacacionPermiso m)
        {
            try
            {
                string sql = "BEGIN pkg_vacaciones_permisos.update_solicitud(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11, :p12); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE VACACION: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_vacaciones_permisos.delete_solicitud(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE VACACION: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(VacacionPermiso m) => new OracleParameter[]
        {
            new OracleParameter("p1",  m.id_solicitud),
            new OracleParameter("p2",  m.id_empleado),
            new OracleParameter("p3",  m.tipo_solicitud),
            new OracleParameter("p4",  m.fecha_inicio),
            new OracleParameter("p5",  m.fecha_fin),
            new OracleParameter("p6",  m.dias_solicitados),
            new OracleParameter("p7",  m.motivo),
            new OracleParameter("p8",  m.fecha_solicitud),
            new OracleParameter("p9",  m.estado),
            new OracleParameter("p10", m.autorizado_por),
            new OracleParameter("p11", m.fecha_autorizacion),
            new OracleParameter("p12", m.observaciones)
        };
    }
}