using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IIncidentesInvolucradosService
    {
        Task<List<IncidentesInvolucradosModel>> ListarTodo();
        Task<IncidentesInvolucradosModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(IncidentesInvolucradosModel m);
        Task<bool> Actualizar(int id, IncidentesInvolucradosModel m);
        Task<bool> Eliminar(int id);
    }
}