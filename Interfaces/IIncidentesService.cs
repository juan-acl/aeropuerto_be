using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IIncidentesService
    {
        Task<List<IncidentesModel>> ListarTodo();
        Task<IncidentesModel?> ObtenerPorId(int id);
        Task<bool> Insertar(IncidentesModel modelo);
        Task<bool> Actualizar(int id, IncidentesModel modelo);
        Task<bool> Eliminar(int id);
    }
}
