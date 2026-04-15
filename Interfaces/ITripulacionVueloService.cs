using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface ITripulacionVueloService
    {
        Task<List<TripulacionVueloModel>> ListarTodo();
        Task<TripulacionVueloModel?> ObtenerPorId(int id);
        Task<bool> Insertar(TripulacionVueloModel modelo);
        Task<bool> Actualizar(int id, TripulacionVueloModel modelo);
        Task<bool> Eliminar(int id);
    }
}
