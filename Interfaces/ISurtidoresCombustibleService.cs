using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISurtidoresCombustibleService
    {
        Task<List<SurtidoresCombustible>> ListarTodo();
        Task<SurtidoresCombustible ?> ObtenerPorId(int id);
        Task<bool> Insertar(SurtidoresCombustible m);
        Task<bool> Actualizar(int id, SurtidoresCombustible m);
        Task<bool> Eliminar(int id);
    }
}