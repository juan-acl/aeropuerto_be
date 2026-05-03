using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEvaluacionService
    {
        Task<List<EvaluacionDesempeno>> ListarTodo();
        Task<bool> Insertar(EvaluacionDesempeno modelo);
        Task<EvaluacionDesempeno?> ObtenerPorId(int id);
        Task<bool> Actualizar(EvaluacionDesempeno modelo);
        Task<bool> Eliminar(int id);
    }
}