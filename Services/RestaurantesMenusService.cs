using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class RestaurantesMenusService : IRestaurantesMenusService
    {
        private readonly DBContext _context;

        public RestaurantesMenusService(DBContext context) => _context = context;

        public async Task<bool> RegistrarPlato(RestaurantesMenusModel m)
        {
            var sql = @"INSERT INTO restaurantes_menus 
                        (id_concesion, nombre_plato, descripcion, categoria_menu, precio, 
                         moneda, disponible, tiempo_preparacion_minutos, calorias, restricciones_alimenticias) 
                        VALUES (:p_con, :p_nom, :p_desc, :p_cat, :p_pre, 
                                :p_mon, :p_disp, :p_tiempo, :p_cal, :p_rest)";

            var parametros = new[] {
                new OracleParameter("p_con", (object?)m.IdConcesion ?? DBNull.Value),
                new OracleParameter("p_nom", (object?)m.NombrePlato ?? DBNull.Value),
                new OracleParameter("p_desc", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_cat", m.CategoriaMenu),
                new OracleParameter("p_pre", (object?)m.Precio ?? DBNull.Value),
                new OracleParameter("p_mon", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_disp", m.Disponible),
                new OracleParameter("p_tiempo", (object?)m.TiempoPreparacionMinutos ?? DBNull.Value),
                new OracleParameter("p_cal", (object?)m.Calorias ?? DBNull.Value),
                new OracleParameter("p_rest", (object?)m.RestriccionesAlimenticias ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<RestaurantesMenusModel>> ListarPorConcesion(int idConcesion)
        {
            // Para la vista administrativa del restaurante
            return await _context.RestaurantesMenus
                .Where(m => m.IdConcesion == idConcesion)
                .OrderBy(m => m.CategoriaMenu).ThenBy(m => m.NombrePlato)
                .ToListAsync();
        }

        public async Task<List<RestaurantesMenusModel>> ListarDisponiblesPorConcesion(int idConcesion)
        {
            // Para la vista del cliente/pasajero
            return await _context.RestaurantesMenus
                .Where(m => m.IdConcesion == idConcesion && m.Disponible == 1)
                .OrderBy(m => m.CategoriaMenu).ThenBy(m => m.NombrePlato)
                .ToListAsync();
        }

        public async Task<bool> CambiarDisponibilidad(int idMenu, int disponible)
        {
            var sql = @"UPDATE restaurantes_menus 
                        SET disponible = :p_disp 
                        WHERE id_menu = :p_id";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_disp", disponible),
                new OracleParameter("p_id", idMenu));
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM restaurantes_menus WHERE id_menu = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}