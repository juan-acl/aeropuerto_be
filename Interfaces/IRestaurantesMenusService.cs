using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRestaurantesMenusService
    {
        Task<List<RestaurantesMenusModel>> ListarTodo();
        Task<RestaurantesMenusModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(RestaurantesMenusModel m);
        Task<bool> Actualizar(int id, RestaurantesMenusModel m);
        Task<bool> Eliminar(int id);
    }
}