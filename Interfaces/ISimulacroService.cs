using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISimulacroService
    {
        Task<List<Simulacros>> ListarTodo();
        Task<Simulacros?> ObtenerPorId(int id);
        Task<bool> Insertar(Simulacros modelo);
        Task<bool> Actualizar(int id, Simulacros modelo);
        Task<bool> Eliminar(int id);
    }
}
