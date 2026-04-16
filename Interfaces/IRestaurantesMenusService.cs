using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRestaurantesMenusService
    {
        Task<bool> RegistrarPlato(RestaurantesMenusModel modelo);
        Task<List<RestaurantesMenusModel>> ListarPorConcesion(int idConcesion);
        Task<List<RestaurantesMenusModel>> ListarDisponiblesPorConcesion(int idConcesion);
        Task<bool> CambiarDisponibilidad(int idMenu, int disponible);
        Task<bool> EliminarFisico(int id);
    }
}