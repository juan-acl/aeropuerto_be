using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ClausulaContratoService : IClausulaContratoService
    {
        private readonly DBContext _context;
        public ClausulaContratoService(DBContext context) => _context = context;

        public async Task<bool> Insertar(ClausulasContrato m)
        {
            var p = new[] {
                new OracleParameter("p_id_contrato", (object?)m.IdContrato ?? DBNull.Value),
                new OracleParameter("p_numero_clausula", (object?)m.NumeroClausula ?? DBNull.Value),
                new OracleParameter("p_titulo_clausula", (object?)m.TituloClausula ?? DBNull.Value),
                new OracleParameter("p_texto_clausula", (object?)m.TextoClausula ?? DBNull.Value),
                new OracleParameter("p_tipo_clausula", (object?)m.TipoClausula ?? DBNull.Value),
                new OracleParameter("p_vigente", (object?)m.Vigente ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_clausulas_contrato.insert_clausula(:p_id_contrato, :p_numero_clausula, :p_titulo_clausula, :p_texto_clausula, :p_tipo_clausula, :p_vigente); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, ClausulasContrato m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_clausula_contrato", m.IdClausulaContrato)
            };
            p.AddRange(new[] {
                new OracleParameter("p_id_contrato", (object?)m.IdContrato ?? DBNull.Value),
                new OracleParameter("p_numero_clausula", (object?)m.NumeroClausula ?? DBNull.Value),
                new OracleParameter("p_titulo_clausula", (object?)m.TituloClausula ?? DBNull.Value),
                new OracleParameter("p_texto_clausula", (object?)m.TextoClausula ?? DBNull.Value),
                new OracleParameter("p_tipo_clausula", (object?)m.TipoClausula ?? DBNull.Value),
                new OracleParameter("p_vigente", (object?)m.Vigente ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_clausulas_contrato.update_clausula(:p_id_clausula_contrato, :p_id_contrato, :p_numero_clausula, :p_titulo_clausula, :p_texto_clausula, :p_tipo_clausula, :p_vigente); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_clausulas_contrato.delete_clausula(:p_id_clausula_contrato); END;", 
                new OracleParameter("p_id_clausula_contrato", id));
            return true;
        }

        public async Task<List<ClausulasContrato>> ListarTodo() => await _context.Set<ClausulasContrato>().ToListAsync();

        public async Task<ClausulasContrato?> ObtenerPorId(int id) => await _context.Set<ClausulasContrato>().FindAsync(id);
    }
}
