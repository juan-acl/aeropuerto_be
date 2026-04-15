using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface IPrediccionDemandaService
    {
        Task<List<PrediccionDemanda>> ListarTodo();
        Task<PrediccionDemanda?> ObtenerPorId(int id);
        Task<bool> Insertar(PrediccionDemanda modelo);
        Task<bool> Actualizar(int id, PrediccionDemanda modelo);
        Task<bool> Eliminar(int id);
    }
}
