using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRetrasoVueloService
    {
        Task<List<RetrasoVueloModel>> ListarTodo();
        Task<RetrasoVueloModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(RetrasoVueloModel m);
        Task<bool> Actualizar(int id, RetrasoVueloModel m);
        Task<bool> Eliminar(int id);
    }
}