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

        public async Task<bool> Insertar(Proveedor m)
        {
            try {
                string sql = "BEGIN pkg_proveedores.insert_proveedor(:p_nom, :p_nit, :p_dir, :p_tel, :p_email, :p_cont, :p_act); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_nom", m.Nombre),
                    new OracleParameter("p_nit", m.Nit),
                    new OracleParameter("p_dir", m.Direccion),
                    new OracleParameter("p_tel", m.Telefono),
                    new OracleParameter("p_email", m.Email),
                    new OracleParameter("p_cont", m.ContactoNombre),
                    new OracleParameter("p_act", m.Activo)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            } catch (Exception) { return false; }
        }
    }
}