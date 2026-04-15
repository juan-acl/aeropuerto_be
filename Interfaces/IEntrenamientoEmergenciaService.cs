using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEntrenamientoEmergenciaService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(EntrenamientosEmergencia modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, EntrenamientosEmergencia modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<EntrenamientosEmergencia>> ListarTodo();

        // Buscar por ID específico
        Task<EntrenamientosEmergencia?> ObtenerPorId(int id);
    }
}



