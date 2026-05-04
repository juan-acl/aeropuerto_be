using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IInspectorAduanaService
    {
        Task<List<InspectorAduana>> ListarTodo();
        Task<InspectorAduana ?> ObtenerPorId(int id);
        Task<bool> Insertar(InspectorAduana m);
        Task<bool> Actualizar(int id, InspectorAduana m);
        Task<bool> Eliminar(int id);
    }
}