using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class IngresoService : IIngresoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public IngresoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<Ingreso>> ListarTodo()
        {
            try { return await _replica.INGRESOS.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo Ingreso: {ex.Message}"); return new List<Ingreso>(); }
        }

        public async Task<Ingreso ?> ObtenerPorId(int id)
        {
            try { return await _replica.INGRESOS.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId Ingreso: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(Ingreso m)
        {
            try
            {
                string sql = "BEGIN pkg_ingresos.insert_ingreso(:p_fecha, :p_concepto, :p_tipo_ingreso, :p_id_concesion, :p_id_vuelo, :p_monto, :p_moneda, :p_metodo_pago, :p_comprobante, :p_registrado_por); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_fecha", m.Fecha),
                    new OracleParameter("p_concepto", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_tipo_ingreso", (object?)m.Fuente ?? DBNull.Value),
                    new OracleParameter("p_id_concesion", (object?)m.IdConcesion ?? DBNull.Value),
                    new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                    new OracleParameter("p_monto", m.Monto),
                    new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                    new OracleParameter("p_metodo_pago", (object?)m.MetodoPago ?? DBNull.Value),
                    new OracleParameter("p_comprobante", (object?)m.Comprobante ?? DBNull.Value),
                    new OracleParameter("p_registrado_por", (object?)m.RegistradoPor ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar Ingreso: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, Ingreso m)
        {
            try
            {
                string sql = "BEGIN pkg_ingresos.update_ingreso(:p_id_ingreso, :p_fecha, :p_concepto, :p_tipo_ingreso, :p_id_concesion, :p_id_vuelo, :p_monto, :p_moneda, :p_metodo_pago, :p_comprobante, :p_registrado_por); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_ingreso", id),
                    new OracleParameter("p_fecha", m.Fecha),
                    new OracleParameter("p_concepto", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_tipo_ingreso", (object?)m.Fuente ?? DBNull.Value),
                    new OracleParameter("p_id_concesion", (object?)m.IdConcesion ?? DBNull.Value),
                    new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                    new OracleParameter("p_monto", m.Monto),
                    new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                    new OracleParameter("p_metodo_pago", (object?)m.MetodoPago ?? DBNull.Value),
                    new OracleParameter("p_comprobante", (object?)m.Comprobante ?? DBNull.Value),
                    new OracleParameter("p_registrado_por", (object?)m.RegistradoPor ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar Ingreso: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_ingresos.delete_ingreso(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar Ingreso: {ex.Message}"); throw; }
        }
    }
}
