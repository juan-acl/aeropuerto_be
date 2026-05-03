using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IInspectorAduanaService
    {
        Task<List<InspectorAduanas>> ListarTodo();
        Task<bool> Insertar(InspectorAduanas modelo);
        Task<InspectorAduanas?> ObtenerPorId(int id);
        Task<bool> Actualizar(InspectorAduanas modelo);
        Task<bool> Eliminar(int id);
    }
}