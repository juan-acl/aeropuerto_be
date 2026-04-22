using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IIncidenteSeguridadService
    {
        Task<List<IncidentesSeguridadInformatica>> ListarTodo();
        Task<IncidentesSeguridadInformatica?> ObtenerPorId(int id);
        Task<bool> Insertar(IncidentesSeguridadInformatica modelo);
        Task<bool> Actualizar(int id, IncidentesSeguridadInformatica modelo);
        Task<bool> Eliminar(int id);
    }
}
