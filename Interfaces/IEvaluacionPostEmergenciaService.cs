using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEvaluacionPostEmergenciaService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(EvaluacionesPostEmergencia modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, EvaluacionesPostEmergencia modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<EvaluacionesPostEmergencia>> ListarTodo();

        // Buscar por ID específico
        Task<EvaluacionesPostEmergencia?> ObtenerPorId(int id);
    }
}


