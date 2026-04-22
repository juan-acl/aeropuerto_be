using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITiposIncidentesService
    {
        Task<List<TiposIncidentesModel>> ListarTodo();
        Task<TiposIncidentesModel?> ObtenerPorId(int id);
        Task<bool> Insertar(TiposIncidentesModel modelo);
        Task<bool> Actualizar(int id, TiposIncidentesModel modelo);
        Task<bool> Eliminar(int id);
    }
}
