using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class CategoriasObjetosService : ICategoriasObjetosService
    {
        private readonly DBContext _context;

        public CategoriasObjetosService(DBContext context) => _context = context;

        public async Task<bool> RegistrarCategoria(CategoriasObjetosModel m)
        {
            var sql = "pkg_categorias_objetos.insert_categoria";

            var parametros = new[] {
                new OracleParameter("p_nombre_categoria", m.NombreCategoria),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_activo", m.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_nombre_categoria, :p_descripcion, :p_activo); END;", parametros);
            return true;
        }

        public async Task<List<CategoriasObjetosModel>> ListarTodas()
        {
            return await _context.CategoriasObjetos
                .OrderBy(c => c.NombreCategoria)
                .ToListAsync();
        }

        public async Task<List<CategoriasObjetosModel>> ListarActivas()
        {
            // Útil para poblar los ComboBox/Selects en el frontend
            return await _context.CategoriasObjetos
                .Where(c => c.Activo == 1)
                .OrderBy(c => c.NombreCategoria)
                .ToListAsync();
        }

        public async Task<bool> DesactivarCategoria(int id)
        {
            // Soft delete: Ideal para no romper la integridad referencial histórica
            var sql = "pkg_categorias_objetos.desactivar_categoria";
            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_categoria); END;", new OracleParameter("p_id_categoria", id));
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "pkg_categorias_objetos.delete_categoria";
            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_categoria); END;", new OracleParameter("p_id_categoria", id));
            return true;
        }
    }
}