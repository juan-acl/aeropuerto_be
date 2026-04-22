using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface INotificacionLegalService
    {
        Task<List<NotificacionesLegales>> ListarTodo();
        Task<NotificacionesLegales?> ObtenerPorId(int id);
        Task<bool> Insertar(NotificacionesLegales modelo);
        Task<bool> Actualizar(int id, NotificacionesLegales modelo);
        Task<bool> Eliminar(int id);
    }
}
