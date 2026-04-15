using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface IIncidenteVueloService
    {
        Task<List<IncidenteVueloModel>> ListarTodo();
        Task<IncidenteVueloModel?> ObtenerPorId(int id);
        Task<bool> Insertar(IncidenteVueloModel modelo);
        Task<bool> Actualizar(int id, IncidenteVueloModel modelo);
        Task<bool> Eliminar(int id);
    }
}
