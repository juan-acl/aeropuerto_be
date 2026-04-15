using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class DiasOperacionService : IDiasOperacionService
    {
        private readonly DBContext _context;

        public DiasOperacionService(DBContext context)
        {
            _context = context;
        }

        // 1. INSERTAR
        public async Task<bool> Insertar(DiaOperacionModel m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_dia", m.IdDia),
                new OracleParameter("p_nombre_dia", m.NombreDia),
                new OracleParameter("p_numero_dia", (object?)m.NumeroDia ?? DBNull.Value),
                new OracleParameter("p_activo", m.Activo)
            };

            string sql = "BEGIN pkg_dias_operacion.insert_dia(:p_id_dia, :p_nombre_dia, :p_numero_dia, :p_activo); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        // 2. ACTUALIZAR
        public async Task<bool> Actualizar(int id, string nombreDia, int activo)
        {
            // Primero obtenemos el registro para no perder el "numero_dia" 
            // ya que el SP update_dia lo requiere obligatoriamente.
            var actual = await ObtenerPorId(id);
            if (actual == null) return false;

            var sql = "BEGIN pkg_dias_operacion.update_dia(:p_id_dia, :p_nombre_dia, :p_numero_dia, :p_activo); END;";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_id_dia", id),
                new OracleParameter("p_nombre_dia", nombreDia),
                new OracleParameter("p_numero_dia", (object?)actual.NumeroDia ?? DBNull.Value),
                new OracleParameter("p_activo", activo));

            return true;
        }

        // 3. ELIMINAR
        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_dias_operacion.delete_dia(:p_id_dia); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_dia", id));
            return true;
        }

        // 4. LISTAR
        public async Task<List<DiaOperacionModel>> ListarTodo()
        {
            return await _context.DiasOperacion.ToListAsync();
        }

        // 5. OBTENER POR ID
        public async Task<DiaOperacionModel?> ObtenerPorId(int id)
        {
            return await _context.DiasOperacion.FirstOrDefaultAsync(x => x.IdDia == id);
        }
    }
}

