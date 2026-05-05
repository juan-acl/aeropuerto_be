using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class TasaAplicadaService : ITasaAplicadaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public TasaAplicadaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<TasaAplicada>> ListarTodo()
        {
            try { return await _replica.TASAS_APLICADAS.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo TasaAplicada: {ex.Message}"); return new List<TasaAplicada>(); }
        }

        public async Task<TasaAplicada ?> ObtenerPorId(int id)
        {
            try { return await _replica.TASAS_APLICADAS.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId TasaAplicada: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(TasaAplicada m)
        {
            try
            {
                string sql = "BEGIN pkg_tasas_aplicadas.insert_aplicacion(:p_id_tasa, :p_id_vuelo, :p_id_reserva, :p_fecha_aplicacion, :p_monto_aplicado, :p_facturado, :p_fecha_factura); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_tasa", m.IdTasa),
                    new OracleParameter("p_id_vuelo", m.IdVuelo),
                    new OracleParameter("p_id_reserva", DBNull.Value),
                    new OracleParameter("p_fecha_aplicacion", DBNull.Value),
                    new OracleParameter("p_monto_aplicado", DBNull.Value),
                    new OracleParameter("p_facturado", DBNull.Value),
                    new OracleParameter("p_fecha_factura", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar TasaAplicada: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, TasaAplicada m)
        {
            try
            {
                string sql = "BEGIN pkg_tasas_aplicadas.update_aplicacion(:p_id_aplicacion, :p_id_tasa, :p_id_vuelo, :p_id_reserva, :p_fecha_aplicacion, :p_monto_aplicado, :p_facturado, :p_fecha_factura); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_aplicacion", id),
                    new OracleParameter("p_id_tasa", m.IdTasa),
                    new OracleParameter("p_id_vuelo", m.IdVuelo),
                    new OracleParameter("p_id_reserva", DBNull.Value),
                    new OracleParameter("p_fecha_aplicacion", DBNull.Value),
                    new OracleParameter("p_monto_aplicado", DBNull.Value),
                    new OracleParameter("p_facturado", DBNull.Value),
                    new OracleParameter("p_fecha_factura", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar TasaAplicada: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_tasas_aplicadas.delete_aplicacion(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar TasaAplicada: {ex.Message}"); throw; }
        }
    }
}
