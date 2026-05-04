using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEvaluacionesPostEmergenciaService
    {
        Task<List<EvaluacionesPostEmergencia>> ListarTodo();
        Task<EvaluacionesPostEmergencia ?> ObtenerPorId(int id);
        Task<bool> Insertar(EvaluacionesPostEmergencia m);
        Task<bool> Actualizar(int id, EvaluacionesPostEmergencia m);
        Task<bool> Eliminar(int id);
    }
}