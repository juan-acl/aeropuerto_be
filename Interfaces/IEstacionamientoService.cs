using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEstacionamientoService
    {
        Task<List<EstacionamientoModel>> ListarTodo();
        Task<EstacionamientoModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(EstacionamientoModel m);
        Task<bool> Actualizar(int id, EstacionamientoModel m);
        Task<bool> Eliminar(int id);
    }
}