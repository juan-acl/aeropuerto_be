using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IIncidentesSeguridadInformaticaService
    {
        Task<List<IncidentesSeguridadInformatica>> ListarTodo();
        Task<IncidentesSeguridadInformatica ?> ObtenerPorId(int id);
        Task<bool> Insertar(IncidentesSeguridadInformatica m);
        Task<bool> Actualizar(int id, IncidentesSeguridadInformatica m);
        Task<bool> Eliminar(int id);
    }
}