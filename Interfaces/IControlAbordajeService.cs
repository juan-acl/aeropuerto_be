using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IControlAbordajeService
    {
        Task<List<ControlAbordajeModel>> ListarTodo();
        Task<ControlAbordajeModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(ControlAbordajeModel m);
        Task<bool> Actualizar(int id, ControlAbordajeModel m);
        Task<bool> Eliminar(int id);
    }
}