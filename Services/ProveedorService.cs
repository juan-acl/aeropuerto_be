using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly DBContext _context;
        public ProveedorService(DBContext context) => _context = context;

        public async Task<List<Proveedor>> ListarTodo() => await _context.PROVEEDORES.ToListAsync();
        public async Task<Proveedor?> ObtenerPorId(int id) => await _context.PROVEEDORES.FindAsync(id);

        public async Task<bool> Insertar(Proveedor m)
        {
            try
            {
                string sql = "BEGIN pkg_proveedores.insert_proveedor(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11, :p12); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT PROVEEDOR: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(Proveedor m)
        {
            try
            {
                string sql = "BEGIN pkg_proveedores.update_proveedor(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11, :p12); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE PROVEEDOR: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_proveedores.delete_proveedor(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE PROVEEDOR: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(Proveedor m) => new OracleParameter[]
        {
            new OracleParameter("p1",  m.id_proveedor),
            new OracleParameter("p2",  m.nombre_proveedor),
            new OracleParameter("p3",  m.tipo_proveedor),
            new OracleParameter("p4",  m.nit),
            new OracleParameter("p5",  m.direccion),
            new OracleParameter("p6",  m.telefono),
            new OracleParameter("p7",  m.email),
            new OracleParameter("p8",  m.contacto_nombre),
            new OracleParameter("p9",  m.contacto_telefono),
            new OracleParameter("p10", m.condiciones_pago),
            new OracleParameter("p11", m.calificacion),
            new OracleParameter("p12", m.activo)
        };
    }
}