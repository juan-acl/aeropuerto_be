using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ProveedorRepuestoService : IProveedorRepuestoService
    {
        private readonly DBContext _context;
        public ProveedorRepuestoService(DBContext context) => _context = context;

        public async Task<List<ProveedorRepuesto>> ListarTodo() => await _context.PROVEEDORES_REPUESTOS.ToListAsync();

        public async Task<bool> Insertar(ProveedorRepuesto m)
        {
            try {
                string sql = "BEGIN pkg_proveedores_repuestos.insert_prov_rep(:p_nom, :p_tel, :p_email, :p_esp); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_nom", m.NombreProveedor),
                    new OracleParameter("p_tel", m.Telefono),
                    new OracleParameter("p_email", m.Email),
                    new OracleParameter("p_esp", m.Especialidad)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            } catch { return false; }
        }
    }
}