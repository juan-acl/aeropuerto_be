using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IIncidentesEvidenciaService
    {
        Task<bool> CargarEvidencia(IncidentesEvidenciaModel modelo);
        Task<List<IncidentesEvidenciaModel>> ListarPorIncidente(int idIncidente);
        Task<IncidentesEvidenciaModel?> ObtenerPorId(int id);
        Task<bool> EliminarFisico(int id);
    }
}