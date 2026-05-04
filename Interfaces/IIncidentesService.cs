using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IIncidentesService
    {
        Task<List<IncidentesModel>> ListarTodo();
        Task<IncidentesModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(IncidentesModel m);
        Task<bool> Actualizar(int id, IncidentesModel m);
        Task<bool> Eliminar(int id);
    }
}