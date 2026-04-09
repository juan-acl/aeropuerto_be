using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IIncidentesMedidasService
    {
        Task<bool> AplicarMedida(IncidentesMedidasModel modelo);
        Task<List<IncidentesMedidasModel>> ListarPorIncidente(int idIncidente);
        Task<bool> ActualizarMedida(int id, IncidentesMedidasModel modelo);
        Task<bool> EliminarFisico(int id);
    }
}