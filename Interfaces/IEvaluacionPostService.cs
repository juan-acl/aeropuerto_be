using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEvaluacionPostService
    {
        Task<List<EvaluacionesPostEmergencia>> ListarTodo();
        Task<EvaluacionesPostEmergencia?> ObtenerPorId(int id);
        Task<bool> Insertar(EvaluacionesPostEmergencia modelo);
        Task<bool> Actualizar(int id, EvaluacionesPostEmergencia modelo);
        Task<bool> Eliminar(int id);
    }
}
