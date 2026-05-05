using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITripulacionVueloService
    {
        Task<List<TripulacionVueloModel>> ListarTodo();
        Task<TripulacionVueloModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(TripulacionVueloModel m);
        Task<bool> Actualizar(int id, TripulacionVueloModel m);
        Task<bool> Eliminar(int id);
    }
}