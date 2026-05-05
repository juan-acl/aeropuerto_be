using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IProveedoresCombustibleService
    {
        Task<List<ProveedoresCombustible>> ListarTodo();
        Task<ProveedoresCombustible ?> ObtenerPorId(int id);
        Task<bool> Insertar(ProveedoresCombustible m);
        Task<bool> Actualizar(int id, ProveedoresCombustible m);
        Task<bool> Eliminar(int id);
    }
}