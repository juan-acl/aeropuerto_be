using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IMonitoreoRuidoService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(MonitoreoRuido modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, MonitoreoRuido modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<MonitoreoRuido>> ListarTodo();

        // Buscar por ID específico
        Task<MonitoreoRuido?> ObtenerPorId(int id);
    }
}


