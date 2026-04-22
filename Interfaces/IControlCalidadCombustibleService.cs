using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IControlCalidadCombustibleService
    {
        Task<List<ControlCalidadCombustible>> ListarTodo();
        Task<ControlCalidadCombustible?> ObtenerPorId(int id);
        Task<bool> Insertar(ControlCalidadCombustible modelo);
        Task<bool> Actualizar(int id, ControlCalidadCombustible modelo);
        Task<bool> Eliminar(int id);
    }
}
