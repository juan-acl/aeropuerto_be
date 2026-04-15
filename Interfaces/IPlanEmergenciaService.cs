using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPlanEmergenciaService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(PlanesEmergencia modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, PlanesEmergencia modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<PlanesEmergencia>> ListarTodo();

        // Buscar por ID específico
        Task<PlanesEmergencia?> ObtenerPorId(int id);
    }
}
