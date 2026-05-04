using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class MetodosPagoService : IMetodosPagoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public MetodosPagoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<MetodosPagoModel>> ListarTodo()
        {
            try { return await _replica.MetodosPago.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo MetodosPagoModel: {ex.Message}"); return new List<MetodosPagoModel>(); }
        }

        public async Task<MetodosPagoModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.MetodosPago.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId MetodosPagoModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(MetodosPagoModel m)
        {
            try
            {
                string sql = "BEGIN pkg_metodos_pago.insert_metodo(:p_descripcion, :p_tipo_pago, :p_procesador, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_tipo_pago", (object?)m.TipoPago ?? DBNull.Value),
                    new OracleParameter("p_procesador", (object?)m.Procesador ?? DBNull.Value),
                    new OracleParameter("p_activo", m.Activo)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar MetodosPagoModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, MetodosPagoModel m)
        {
            try
            {
                string sql = "BEGIN pkg_metodos_pago.update_metodo(:p_id_metodo_pago, :p_descripcion, :p_tipo_pago, :p_procesador, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_metodo_pago", id),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_tipo_pago", (object?)m.TipoPago ?? DBNull.Value),
                    new OracleParameter("p_procesador", (object?)m.Procesador ?? DBNull.Value),
                    new OracleParameter("p_activo", m.Activo)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar MetodosPagoModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_metodos_pago.delete_metodo(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar MetodosPagoModel: {ex.Message}"); throw; }
        }
    }
}
