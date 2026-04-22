using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IProveedorCombustibleService
    {
        Task<List<ProveedoresCombustible>> ListarTodo();
        Task<ProveedoresCombustible?> ObtenerPorId(int id);
        Task<bool> Insertar(ProveedoresCombustible modelo);
        Task<bool> Actualizar(int id, ProveedoresCombustible modelo);
        Task<bool> Eliminar(int id);
    }
}
