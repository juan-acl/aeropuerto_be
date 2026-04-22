using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface INotificacionOaciService
    {
        Task<List<NotificacionesOaci>> ListarTodo();
        Task<NotificacionesOaci?> ObtenerPorId(int id);
        Task<bool> Insertar(NotificacionesOaci modelo);
        Task<bool> Actualizar(int id, NotificacionesOaci modelo);
        Task<bool> Eliminar(int id);
    }
}
