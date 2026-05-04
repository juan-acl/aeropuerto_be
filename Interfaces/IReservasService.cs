using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IReservasService
    {
        Task<List<ReservasModel>> ListarTodo();
        Task<ReservasModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(ReservasModel m);
        Task<bool> Actualizar(int id, ReservasModel m);
        Task<bool> Eliminar(int id);
    }
}