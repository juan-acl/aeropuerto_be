using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISimulacrosService
    {
        Task<List<Simulacros>> ListarTodo();
        Task<Simulacros ?> ObtenerPorId(int id);
        Task<bool> Insertar(Simulacros m);
        Task<bool> Actualizar(int id, Simulacros m);
        Task<bool> Eliminar(int id);
    }
}