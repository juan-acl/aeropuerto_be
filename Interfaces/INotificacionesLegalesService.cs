using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface INotificacionesLegalesService
    {
        Task<List<NotificacionesLegales>> ListarTodo();
        Task<NotificacionesLegales ?> ObtenerPorId(int id);
        Task<bool> Insertar(NotificacionesLegales m);
        Task<bool> Actualizar(int id, NotificacionesLegales m);
        Task<bool> Eliminar(int id);
    }
}