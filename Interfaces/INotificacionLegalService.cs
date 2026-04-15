using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface INotificacionLegalService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(NotificacionesLegales modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, NotificacionesLegales modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<NotificacionesLegales>> ListarTodo();

        // Buscar por ID específico
        Task<NotificacionesLegales?> ObtenerPorId(int id);
    }
}


