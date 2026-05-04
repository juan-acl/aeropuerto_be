using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAvionService
    {
        Task<List<AvionModel>> ListarTodo();
        Task<AvionModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(AvionModel m);
        Task<bool> Actualizar(int id, AvionModel m);
        Task<bool> Eliminar(int id);
    }
}