using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITanqueCombustibleService
    {
        Task<List<TanquesCombustible>> ListarTodo();
        Task<TanquesCombustible?> ObtenerPorId(int id);
        Task<bool> Insertar(TanquesCombustible modelo);
        Task<bool> Actualizar(int id, TanquesCombustible modelo);
        Task<bool> Eliminar(int id);
    }
}
