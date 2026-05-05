using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IHistorialReservasService
    {
        Task<List<HistorialReservasModel>> ListarTodo();
        Task<HistorialReservasModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(HistorialReservasModel m);
        Task<bool> Actualizar(int id, HistorialReservasModel m);
        Task<bool> Eliminar(int id);
    }
}