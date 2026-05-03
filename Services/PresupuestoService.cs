using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PresupuestoService : IPresupuestoService
    {
        private readonly DBContext _context;
        public PresupuestoService(DBContext context) => _context = context;

        public async Task<List<Presupuesto>> ListarTodo() => await _context.PRESUPUESTOS.ToListAsync();
        public async Task<Presupuesto?> ObtenerPorId(int id) => await _context.PRESUPUESTOS.FindAsync(id);

        public async Task<bool> Insertar(Presupuesto m)
        {
            try
            {
                string sql = "BEGIN pkg_presupuestos.insert_presupuesto(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT PRESUPUESTO: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(Presupuesto m)
        {
            try
            {
                string sql = "BEGIN pkg_presupuestos.update_presupuesto(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE PRESUPUESTO: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_presupuestos.delete_presupuesto(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE PRESUPUESTO: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(Presupuesto m) => new OracleParameter[]
        {
            new OracleParameter("p1",  m.id_presupuesto),
            new OracleParameter("p2",  m.anio_fiscal),
            new OracleParameter("p3",  m.mes),
            new OracleParameter("p4",  m.concepto),
            new OracleParameter("p5",  m.id_departamento),
            new OracleParameter("p6",  m.monto_asignado),
            new OracleParameter("p7",  m.monto_ejecutado),
            new OracleParameter("p8",  m.tipo_gasto),
            new OracleParameter("p9",  m.observaciones),
            new OracleParameter("p10", m.fecha_actualizacion)
        };
    }
}