using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IIncidenteVueloService
    {
        Task<List<IncidenteVueloModel>> ListarTodo();
        Task<IncidenteVueloModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(IncidenteVueloModel m);
        Task<bool> Actualizar(int id, IncidenteVueloModel m);
        Task<bool> Eliminar(int id);
    }
}