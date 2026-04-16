using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEvaluacionService
    {
        Task<List<EvaluacionDesempeno>> ListarTodo();
        Task<bool> Insertar(EvaluacionDesempeno modelo);
    }
}