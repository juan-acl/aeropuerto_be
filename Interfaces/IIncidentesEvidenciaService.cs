using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IIncidentesEvidenciaService
    {
        Task<List<IncidentesEvidenciaModel>> ListarTodo();
        Task<IncidentesEvidenciaModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(IncidentesEvidenciaModel m);
        Task<bool> Actualizar(int id, IncidentesEvidenciaModel m);
        Task<bool> Eliminar(int id);
    }
}