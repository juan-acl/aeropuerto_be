using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IControlCalidadCombustibleService
    {
        Task<List<ControlCalidadCombustible>> ListarTodo();
        Task<ControlCalidadCombustible ?> ObtenerPorId(int id);
        Task<bool> Insertar(ControlCalidadCombustible m);
        Task<bool> Actualizar(int id, ControlCalidadCombustible m);
        Task<bool> Eliminar(int id);
    }
}