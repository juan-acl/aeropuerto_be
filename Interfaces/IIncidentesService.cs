using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IIncidentesService
    {
        Task<bool> Insertar(IncidentesModel modelo);
        Task<List<IncidentesModel>> ListarPorFiltro(string? gravedad, string? estado);
        Task<IncidentesModel?> ObtenerPorId(int id);
        Task<bool> ResolverIncidente(int id, string resolucion);
        Task<bool> EliminarFisico(int id);
    }
}