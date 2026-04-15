using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IMonitoreoAireService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(MonitoreoAire modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, MonitoreoAire modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<MonitoreoAire>> ListarTodo();

        // Buscar por ID específico
        Task<MonitoreoAire?> ObtenerPorId(int id);
    }
}
