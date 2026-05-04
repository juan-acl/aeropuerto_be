using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITiposIncidentesService
    {
        Task<List<TiposIncidentesModel>> ListarTodo();
        Task<TiposIncidentesModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(TiposIncidentesModel m);
        Task<bool> Actualizar(int id, TiposIncidentesModel m);
        Task<bool> Eliminar(int id);
    }
}