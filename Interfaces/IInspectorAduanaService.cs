using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IInspectorAduanaService
    {
        Task<List<InspectorAduana>> ListarTodo();
        Task<bool> Insertar(InspectorAduana modelo);
    }
}