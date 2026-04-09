using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITiposIncidentesService
    {
        Task<bool> Insertar(TiposIncidentesModel modelo);
        Task<List<TiposIncidentesModel>> ListarActivos();
        Task<TiposIncidentesModel?> ObtenerPorId(int id);
        Task<bool> Actualizar(int id, TiposIncidentesModel modelo);
        Task<bool> EliminarLogico(int id);
    }
}