using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface ICodigoOaciPaisService
    {
        Task<List<CodigosOaciPaises>> ListarTodo();
        Task<CodigosOaciPaises?> ObtenerPorId(int id);
        Task<bool> Insertar(CodigosOaciPaises modelo);
        Task<bool> Actualizar(int id, CodigosOaciPaises modelo);
        Task<bool> Eliminar(int id);
    }
}
