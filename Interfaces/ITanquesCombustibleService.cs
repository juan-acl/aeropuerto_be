using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITanquesCombustibleService
    {
        Task<List<TanquesCombustible>> ListarTodo();
        Task<TanquesCombustible ?> ObtenerPorId(int id);
        Task<bool> Insertar(TanquesCombustible m);
        Task<bool> Actualizar(int id, TanquesCombustible m);
        Task<bool> Eliminar(int id);
    }
}