using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IIncidentesInvolucradosService
    {
        Task<List<IncidentesInvolucradosModel>> ListarTodo();
        Task<IncidentesInvolucradosModel?> ObtenerPorId(int id);
        Task<bool> Insertar(IncidentesInvolucradosModel modelo);
        Task<bool> Actualizar(int id, IncidentesInvolucradosModel modelo);
        Task<bool> Eliminar(int id);
    }
}
