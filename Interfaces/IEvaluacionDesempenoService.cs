using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEvaluacionDesempenoService
    {
        Task<List<EvaluacionDesempeno>> ListarTodo();
        Task<EvaluacionDesempeno ?> ObtenerPorId(int id);
        Task<bool> Insertar(EvaluacionDesempeno m);
        Task<bool> Actualizar(int id, EvaluacionDesempeno m);
        Task<bool> Eliminar(int id);
    }
}