using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ProveedorService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<Proveedor>> ListarTodo()
        {
            try { return await _replica.PROVEEDORES.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo Proveedor: {ex.Message}"); return new List<Proveedor>(); }
        }

        public async Task<Proveedor ?> ObtenerPorId(int id)
        {
            try { return await _replica.PROVEEDORES.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId Proveedor: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(Proveedor m)
        {
            try
            {
                string sql = "BEGIN pkg_proveedores.insert_proveedor(:p_nombre_proveedor, :p_tipo_proveedor, :p_nit, :p_direccion, :p_telefono, :p_email, :p_contacto_nombre, :p_contacto_telefono, :p_condiciones_pago, :p_calificacion, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_nombre_proveedor", DBNull.Value),
                    new OracleParameter("p_tipo_proveedor", DBNull.Value),
                    new OracleParameter("p_nit", (object?)m.Nit ?? DBNull.Value),
                    new OracleParameter("p_direccion", (object?)m.Direccion ?? DBNull.Value),
                    new OracleParameter("p_telefono", (object?)m.Telefono ?? DBNull.Value),
                    new OracleParameter("p_email", (object?)m.Email ?? DBNull.Value),
                    new OracleParameter("p_contacto_nombre", (object?)m.ContactoNombre ?? DBNull.Value),
                    new OracleParameter("p_contacto_telefono", DBNull.Value),
                    new OracleParameter("p_condiciones_pago", DBNull.Value),
                    new OracleParameter("p_calificacion", DBNull.Value),
                    new OracleParameter("p_activo", m.Activo)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar Proveedor: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, Proveedor m)
        {
            try
            {
                string sql = "BEGIN pkg_proveedores.update_proveedor(:p_id_proveedor, :p_nombre_proveedor, :p_tipo_proveedor, :p_nit, :p_direccion, :p_telefono, :p_email, :p_contacto_nombre, :p_contacto_telefono, :p_condiciones_pago, :p_calificacion, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_proveedor", id),
                    new OracleParameter("p_nombre_proveedor", DBNull.Value),
                    new OracleParameter("p_tipo_proveedor", DBNull.Value),
                    new OracleParameter("p_nit", (object?)m.Nit ?? DBNull.Value),
                    new OracleParameter("p_direccion", (object?)m.Direccion ?? DBNull.Value),
                    new OracleParameter("p_telefono", (object?)m.Telefono ?? DBNull.Value),
                    new OracleParameter("p_email", (object?)m.Email ?? DBNull.Value),
                    new OracleParameter("p_contacto_nombre", (object?)m.ContactoNombre ?? DBNull.Value),
                    new OracleParameter("p_contacto_telefono", DBNull.Value),
                    new OracleParameter("p_condiciones_pago", DBNull.Value),
                    new OracleParameter("p_calificacion", DBNull.Value),
                    new OracleParameter("p_activo", m.Activo)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar Proveedor: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_proveedores.delete_proveedor(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar Proveedor: {ex.Message}"); throw; }
        }
    }
}
