using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITripulacionService
    {
        Task<List<TripulacionModel>> ListarTodo();
        Task<TripulacionModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(TripulacionModel m);
        Task<bool> Actualizar(int id, TripulacionModel m);
        Task<bool> Eliminar(int id);
    }
}