using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface INotificacionesOaciService
    {
        Task<List<NotificacionesOaci>> ListarTodo();
        Task<NotificacionesOaci ?> ObtenerPorId(int id);
        Task<bool> Insertar(NotificacionesOaci m);
        Task<bool> Actualizar(int id, NotificacionesOaci m);
        Task<bool> Eliminar(int id);
    }
}