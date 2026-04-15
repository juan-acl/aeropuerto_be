using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRecursoEmergenciaService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(RecursosEmergencia modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, RecursosEmergencia modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<RecursosEmergencia>> ListarTodo();

        // Buscar por ID específico
        Task<RecursosEmergencia?> ObtenerPorId(int id);
    }
}


