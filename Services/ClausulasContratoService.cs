using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ClausulasContratoService : IClausulasContratoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ClausulasContratoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ClausulasContrato>> ListarTodo()
        {
            try { return await _replica.ClausulasContrato.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ClausulasContrato: {ex.Message}"); return new List<ClausulasContrato>(); }
        }

        public async Task<ClausulasContrato ?> ObtenerPorId(int id)
        {
            try { return await _replica.ClausulasContrato.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ClausulasContrato: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ClausulasContrato m)
        {
            try
            {
                string sql = "BEGIN pkg_clausulas_contrato.insert_clausula(:p_id_contrato, :p_numero_clausula, :p_titulo_clausula, :p_texto_clausula, :p_tipo_clausula, :p_vigente); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_contrato", m.IdContrato),
                    new OracleParameter("p_numero_clausula", m.NumeroClausula),
                    new OracleParameter("p_titulo_clausula", (object?)m.TituloClausula ?? DBNull.Value),
                    new OracleParameter("p_texto_clausula", (object?)m.TextoClausula ?? DBNull.Value),
                    new OracleParameter("p_tipo_clausula", (object?)m.TipoClausula ?? DBNull.Value),
                    new OracleParameter("p_vigente", (object?)m.Vigente ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ClausulasContrato: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, ClausulasContrato m)
        {
            try
            {
                string sql = "BEGIN pkg_clausulas_contrato.update_clausula(:p_id_clausula_contrato, :p_id_contrato, :p_numero_clausula, :p_titulo_clausula, :p_texto_clausula, :p_tipo_clausula, :p_vigente); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_clausula_contrato", id),
                    new OracleParameter("p_id_contrato", m.IdContrato),
                    new OracleParameter("p_numero_clausula", m.NumeroClausula),
                    new OracleParameter("p_titulo_clausula", (object?)m.TituloClausula ?? DBNull.Value),
                    new OracleParameter("p_texto_clausula", (object?)m.TextoClausula ?? DBNull.Value),
                    new OracleParameter("p_tipo_clausula", (object?)m.TipoClausula ?? DBNull.Value),
                    new OracleParameter("p_vigente", (object?)m.Vigente ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ClausulasContrato: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_clausulas_contrato.delete_clausula(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ClausulasContrato: {ex.Message}"); throw; }
        }
    }
}
