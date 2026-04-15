using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class TipoAeropuertoService : ITipoAeropuertoService
    {
        private readonly DBContext _context;

        public TipoAeropuertoService(DBContext context)
        {
            _context = context;
        }

        // 1. INSERTAR
        public async Task<bool> Insertar(TipoAeropuertoModel m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_tipo_aeropuerto", m.IdTipoAeropuerto),
                new OracleParameter("p_descripcion", m.Descripcion),
                new OracleParameter("p_codigo", m.Codigo),
                new OracleParameter("p_activo", m.Activo)
            };

            string sql = "BEGIN pkg_tipos_aeropuerto.insert_tipo(:p_id_tipo_aeropuerto, :p_descripcion, :p_codigo, :p_activo); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        // 2. ACTUALIZAR
        public async Task<bool> Actualizar(int id, string descripcion, string codigo, int activo)
        {
            var sql = "BEGIN pkg_tipos_aeropuerto.update_tipo(:p_id_tipo_aeropuerto, :p_descripcion, :p_codigo, :p_activo); END;";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_id_tipo_aeropuerto", id),
                new OracleParameter("p_descripcion", descripcion),
                new OracleParameter("p_codigo", codigo),
                new OracleParameter("p_activo", activo));

            return true;
        }

        // 3. ELIMINAR
        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_tipos_aeropuerto.delete_tipo(:p_id_tipo_aeropuerto); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_tipo_aeropuerto", id));
            return true;
        }

        // 4. LISTAR
        public async Task<List<TipoAeropuertoModel>> ListarTodo()
        {
            return await _context.TiposAeropuerto.ToListAsync();
        }

        // 5. OBTENER POR ID
        public async Task<TipoAeropuertoModel?> ObtenerPorId(int id)
        {
            return await _context.TiposAeropuerto.FirstOrDefaultAsync(x => x.IdTipoAeropuerto == id);
        }
    }
}

