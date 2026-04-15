using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class TipoAerolineaService : ITipoAerolineaService
    {
        private readonly DBContext _context;

        public TipoAerolineaService(DBContext context)
        {
            _context = context;
        }

        // 1. INSERTAR
        public async Task<bool> Insertar(TipoAerolineaModel m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_tipo_aerolinea", m.IdTipoAerolinea),
                new OracleParameter("p_descripcion", m.Descripcion),
                new OracleParameter("p_activo", m.Activo)
            };

            string sql = "BEGIN pkg_tipos_aerolinea.insert_tipo(:p_id_tipo_aerolinea, :p_descripcion, :p_activo); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        // 2. ACTUALIZAR
        public async Task<bool> Actualizar(int id, string descripcion, int activo)
        {
            var sql = "BEGIN pkg_tipos_aerolinea.update_tipo(:p_id_tipo_aerolinea, :p_descripcion, :p_activo); END;";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_id_tipo_aerolinea", id),
                new OracleParameter("p_descripcion", descripcion),
                new OracleParameter("p_activo", activo));

            return true;
        }

        // 3. ELIMINAR
        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_tipos_aerolinea.delete_tipo(:p_id_tipo_aerolinea); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_tipo_aerolinea", id));
            return true;
        }

        // 4. LISTAR
        public async Task<List<TipoAerolineaModel>> ListarTodo()
        {
            return await _context.TiposAerolinea.ToListAsync();
        }

        // 5. OBTENER POR ID
        public async Task<TipoAerolineaModel?> ObtenerPorId(int id)
        {
            return await _context.TiposAerolinea.FirstOrDefaultAsync(x => x.IdTipoAerolinea == id);
        }
    }
}

