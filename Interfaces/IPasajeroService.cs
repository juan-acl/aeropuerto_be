using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasajeroService
    {
        Task<List<PasajeroModel>> ListarTodo();
        Task<PasajeroModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(PasajeroModel m);
        Task<bool> Actualizar(int id, PasajeroModel m);
        Task<bool> Eliminar(int id);
    }
}