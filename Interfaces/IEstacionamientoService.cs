using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEstacionamientoService
    {
        Task<List<EstacionamientoModel>> ListarTodo();
        Task<EstacionamientoModel?> ObtenerPorId(int id);
        Task<bool> Insertar(EstacionamientoModel modelo);
        Task<bool> Actualizar(int id, EstacionamientoModel modelo);
        Task<bool> Eliminar(int id);
    }
}
