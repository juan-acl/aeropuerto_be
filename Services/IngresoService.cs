using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class IngresoService : IIngresoService
    {
        private readonly DBContext _context;
        public IngresoService(DBContext context) => _context = context;

        public async Task<List<Ingreso>> ListarTodo() => await _context.INGRESOS.ToListAsync();
        public async Task<Ingreso?> ObtenerPorId(int id) => await _context.INGRESOS.FindAsync(id);

        public async Task<bool> Insertar(Ingreso m)
        {
            try
            {
                string sql = "BEGIN pkg_ingresos.insert_ingreso(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT INGRESO: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(Ingreso m)
        {
            try
            {
                string sql = "BEGIN pkg_ingresos.update_ingreso(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE INGRESO: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_ingresos.delete_ingreso(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE INGRESO: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(Ingreso m) => new OracleParameter[]
        {
            new OracleParameter("p1",  m.id_ingreso),
            new OracleParameter("p2",  m.fecha),
            new OracleParameter("p3",  m.concepto),
            new OracleParameter("p4",  m.tipo_ingreso),
            new OracleParameter("p5",  m.id_concesion),
            new OracleParameter("p6",  m.id_vuelo),
            new OracleParameter("p7",  m.monto),
            new OracleParameter("p8",  m.moneda),
            new OracleParameter("p9",  m.metodo_pago),
            new OracleParameter("p10", m.comprobante),
            new OracleParameter("p11", m.registrado_por)
        };
    }
}