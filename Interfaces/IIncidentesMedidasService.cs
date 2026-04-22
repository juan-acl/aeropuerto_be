using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IIncidentesMedidasService
    {
        Task<List<IncidentesMedidasModel>> ListarTodo();
        Task<IncidentesMedidasModel?> ObtenerPorId(int id);
        Task<bool> Insertar(IncidentesMedidasModel modelo);
        Task<bool> Actualizar(int id, IncidentesMedidasModel modelo);
        Task<bool> Eliminar(int id);
    }
}
