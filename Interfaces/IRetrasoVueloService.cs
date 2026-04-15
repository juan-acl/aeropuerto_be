using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface IRetrasoVueloService
    {
        Task<List<RetrasoVueloModel>> ListarTodo();
        Task<RetrasoVueloModel?> ObtenerPorId(int id);
        Task<bool> Insertar(RetrasoVueloModel modelo);
        Task<bool> Actualizar(int id, RetrasoVueloModel modelo);
        Task<bool> Eliminar(int id);
    }
}
