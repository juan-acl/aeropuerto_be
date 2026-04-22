using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISurtidorCombustibleService
    {
        Task<List<SurtidoresCombustible>> ListarTodo();
        Task<SurtidoresCombustible?> ObtenerPorId(int id);
        Task<bool> Insertar(SurtidoresCombustible modelo);
        Task<bool> Actualizar(int id, SurtidoresCombustible modelo);
        Task<bool> Eliminar(int id);
    }
}
