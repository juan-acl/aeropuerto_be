using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface INotificacionOaciService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(NotificacionesOaci modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, NotificacionesOaci modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<NotificacionesOaci>> ListarTodo();

        // Buscar por ID específico
        Task<NotificacionesOaci?> ObtenerPorId(int id);
    }
}


