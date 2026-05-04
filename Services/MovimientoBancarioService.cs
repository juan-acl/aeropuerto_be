using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class MovimientoBancarioService : IMovimientoBancarioService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public MovimientoBancarioService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<MovimientoBancario>> ListarTodo()
        {
            try { return await _replica.MOVIMIENTOS_BANCARIOS.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo MovimientoBancario: {ex.Message}"); return new List<MovimientoBancario>(); }
        }

        public async Task<MovimientoBancario ?> ObtenerPorId(int id)
        {
            try { return await _replica.MOVIMIENTOS_BANCARIOS.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId MovimientoBancario: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(MovimientoBancario m)
        {
            try
            {
                string sql = "BEGIN pkg_movimientos_bancarios.insert_movimiento(:p_id_cuenta, :p_fecha, :p_tipo_movimiento, :p_concepto, :p_monto, :p_saldo_resultante, :p_referencia, :p_conciliado); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_cuenta", DBNull.Value),
                    new OracleParameter("p_fecha", m.Fecha),
                    new OracleParameter("p_tipo_movimiento", (object?)m.TipoMovimiento ?? DBNull.Value),
                    new OracleParameter("p_concepto", DBNull.Value),
                    new OracleParameter("p_monto", m.Monto),
                    new OracleParameter("p_saldo_resultante", DBNull.Value),
                    new OracleParameter("p_referencia", DBNull.Value),
                    new OracleParameter("p_conciliado", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar MovimientoBancario: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, MovimientoBancario m)
        {
            try
            {
                string sql = "BEGIN pkg_movimientos_bancarios.update_movimiento(:p_id_movimiento, :p_id_cuenta, :p_fecha, :p_tipo_movimiento, :p_concepto, :p_monto, :p_saldo_resultante, :p_referencia, :p_conciliado); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_movimiento", id),
                    new OracleParameter("p_id_cuenta", DBNull.Value),
                    new OracleParameter("p_fecha", m.Fecha),
                    new OracleParameter("p_tipo_movimiento", (object?)m.TipoMovimiento ?? DBNull.Value),
                    new OracleParameter("p_concepto", DBNull.Value),
                    new OracleParameter("p_monto", m.Monto),
                    new OracleParameter("p_saldo_resultante", DBNull.Value),
                    new OracleParameter("p_referencia", DBNull.Value),
                    new OracleParameter("p_conciliado", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar MovimientoBancario: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_movimientos_bancarios.delete_movimiento(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar MovimientoBancario: {ex.Message}"); throw; }
        }
    }
}
