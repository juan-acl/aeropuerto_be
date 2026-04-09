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
            var sql = @"INSERT INTO categorias_objetos 
                        (nombre_categoria, descripcion, activo) 
                        VALUES (:p_nom, :p_desc, :p_act)";

            var parametros = new[] {
                new OracleParameter("p_nom", m.NombreCategoria),
                new OracleParameter("p_desc", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_act", m.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
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
            var sql = "UPDATE categorias_objetos SET activo = 0 WHERE id_categoria = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM categorias_objetos WHERE id_categoria = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}