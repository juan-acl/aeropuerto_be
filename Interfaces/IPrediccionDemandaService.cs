using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPrediccionDemandaService
    {
        Task<List<PrediccionDemanda>> ListarTodo();
        Task<PrediccionDemanda ?> ObtenerPorId(int id);
        Task<bool> Insertar(PrediccionDemanda m);
        Task<bool> Actualizar(int id, PrediccionDemanda m);
        Task<bool> Eliminar(int id);
    }
}