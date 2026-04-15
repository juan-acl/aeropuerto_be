using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface IAvionService
    {
        Task<List<AvionModel>> ListarTodo();
        Task<AvionModel?> ObtenerPorId(string id);
        Task<bool> Insertar(AvionModel modelo);
        Task<bool> Actualizar(string id, AvionModel modelo);
        Task<bool> Eliminar(string id);
    }
}
