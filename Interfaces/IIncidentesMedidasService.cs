using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IIncidentesMedidasService
    {
        Task<List<IncidentesMedidasModel>> ListarTodo();
        Task<IncidentesMedidasModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(IncidentesMedidasModel m);
        Task<bool> Actualizar(int id, IncidentesMedidasModel m);
        Task<bool> Eliminar(int id);
    }
}