using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class AlianzaAerolineaService : IAlianzaAerolineaService
    {
        private readonly DBContext _context;

        public AlianzaAerolineaService(DBContext context)
        {
            _context = context;
        }

        // 1. INSERTAR
        public async Task<bool> Insertar(AlianzaAerolineaModel m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_alianza", m.IdAlianza),
                new OracleParameter("p_nombre_alianza", m.NombreAlianza),
                new OracleParameter("p_fecha_fundacion", (object?)m.FechaFundacion ?? DBNull.Value),
                new OracleParameter("p_sede", (object?)m.Sede ?? DBNull.Value),
                new OracleParameter("p_numero_miembros", (object?)m.NumeroMiembros ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value)
            };

            string sql = "BEGIN pkg_alianzas.insert_alianza(:p_id_alianza, :p_nombre_alianza, :p_fecha_fundacion, :p_sede, :p_numero_miembros, :p_descripcion); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        // 2. ACTUALIZAR
        // Se mapea a los parámetros del SP update_alianza
        public async Task<bool> Actualizar(int id, string sede, int numeroMiembros, string descripcion)
        {
            // Nota: Como el SP de Oracle pide nombre y fecha_fundacion, 
            // primero obtenemos el registro actual para no perder esos datos, 
            // o asumimos que el SP maneja actualizaciones parciales.

            var actual = await ObtenerPorId(id);
            if (actual == null) return false;

            var sql = "BEGIN pkg_alianzas.update_alianza(:p_id_alianza, :p_nombre_alianza, :p_fecha_fundacion, :p_sede, :p_numero_miembros, :p_descripcion); END;";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_id_alianza", id),
                new OracleParameter("p_nombre_alianza", actual.NombreAlianza),
                new OracleParameter("p_fecha_fundacion", (object?)actual.FechaFundacion ?? DBNull.Value),
                new OracleParameter("p_sede", (object?)sede ?? DBNull.Value),
                new OracleParameter("p_numero_miembros", numeroMiembros),
                new OracleParameter("p_descripcion", (object?)descripcion ?? DBNull.Value));

            return true;
        }

        // 3. ELIMINAR
        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_alianzas.delete_alianza(:p_id_alianza); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_alianza", id));
            return true;
        }

        // 4. LISTAR
        public async Task<List<AlianzaAerolineaModel>> ListarTodo()
        {
            return await _context.AlianzasAerolineas.ToListAsync();
        }

        // 5. OBTENER POR ID
        public async Task<AlianzaAerolineaModel?> ObtenerPorId(int id)
        {
            return await _context.AlianzasAerolineas.FirstOrDefaultAsync(x => x.IdAlianza == id);
        }
    }
}

