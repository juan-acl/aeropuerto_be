using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IControlAbordajeService
    {
        Task<List<ControlAbordajeModel>> ListarTodo();
        Task<ControlAbordajeModel?> ObtenerPorId(int id);
        Task<bool> Insertar(ControlAbordajeModel modelo);
        Task<bool> Actualizar(int id, ControlAbordajeModel modelo);
        Task<bool> Eliminar(int id);
    }
}
