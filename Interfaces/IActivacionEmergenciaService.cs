using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IActivacionEmergenciaService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(ActivacionesEmergencia modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, ActivacionesEmergencia modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<ActivacionesEmergencia>> ListarTodo();

        // Buscar por ID específico
        Task<ActivacionesEmergencia?> ObtenerPorId(int id);
    }
}
