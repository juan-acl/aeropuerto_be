using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICodigosOaciPaisesService
    {
        Task<List<CodigosOaciPaises>> ListarTodo();
        Task<CodigosOaciPaises ?> ObtenerPorId(int id);
        Task<bool> Insertar(CodigosOaciPaises m);
        Task<bool> Actualizar(int id, CodigosOaciPaises m);
        Task<bool> Eliminar(int id);
    }
}