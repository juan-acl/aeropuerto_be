using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IIncidentesInvolucradosService
    {
        Task<bool> Insertar(IncidentesInvolucradosModel modelo);
        Task<List<IncidentesInvolucradosModel>> ListarPorIncidente(int idIncidente);
        Task<bool> ActualizarDeclaracion(int id, string nuevaDeclaracion);
        Task<bool> EliminarFisico(int id);
    }
}