using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class RestaurantesMenusService : IRestaurantesMenusService
    {
        private readonly DBContext _context;
        public RestaurantesMenusService(DBContext context) => _context = context;

        public async Task<List<RestaurantesMenusModel>> ListarTodo()
        {
            try { return await _context.RestaurantesMenus.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo RestaurantesMenusModel: {ex.Message}"); return new List<RestaurantesMenusModel>(); }
        }

        public async Task<RestaurantesMenusModel?> ObtenerPorId(int id)
        {
            try { return await _context.RestaurantesMenus.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId RestaurantesMenusModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(RestaurantesMenusModel m)
        {
            try
            {
                string sql = "BEGIN pkg_restaurantes_menus.insert_menu(:p_id_concesion, :p_nombre_plato, :p_descripcion, :p_categoria_menu, :p_precio, :p_moneda, :p_disponible, :p_tiempo_preparacion_minutos, :p_calorias, :p_restricciones_alimenticias); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_concesion", (object?)m.IdConcesion ?? DBNull.Value),
                new OracleParameter("p_nombre_plato", (object?)m.NombrePlato ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_categoria_menu", (object?)m.CategoriaMenu ?? DBNull.Value),
                new OracleParameter("p_precio", (object?)m.Precio ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_disponible", m.Disponible),
                new OracleParameter("p_tiempo_preparacion_minutos", (object?)m.TiempoPreparacionMinutos ?? DBNull.Value),
                new OracleParameter("p_calorias", (object?)m.Calorias ?? DBNull.Value),
                new OracleParameter("p_restricciones_alimenticias", (object?)m.RestriccionesAlimenticias ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar RestaurantesMenusModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, RestaurantesMenusModel m)
        {
            try
            {
                string sql = "BEGIN pkg_restaurantes_menus.update_menu(:p_id_menu, :p_id_concesion, :p_nombre_plato, :p_descripcion, :p_categoria_menu, :p_precio, :p_moneda, :p_disponible, :p_tiempo_preparacion_minutos, :p_calorias, :p_restricciones_alimenticias); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_menu", id),
                new OracleParameter("p_id_concesion", (object?)m.IdConcesion ?? DBNull.Value),
                new OracleParameter("p_nombre_plato", (object?)m.NombrePlato ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_categoria_menu", (object?)m.CategoriaMenu ?? DBNull.Value),
                new OracleParameter("p_precio", (object?)m.Precio ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_disponible", m.Disponible),
                new OracleParameter("p_tiempo_preparacion_minutos", (object?)m.TiempoPreparacionMinutos ?? DBNull.Value),
                new OracleParameter("p_calorias", (object?)m.Calorias ?? DBNull.Value),
                new OracleParameter("p_restricciones_alimenticias", (object?)m.RestriccionesAlimenticias ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar RestaurantesMenusModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_restaurantes_menus.delete_menu(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar RestaurantesMenusModel: {ex.Message}"); return false; }
        }
    }
}
