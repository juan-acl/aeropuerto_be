using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IReaccionPromocionService
    {
        Task<List<ReaccionesPromociones>> ListarTodo();
        Task<ReaccionesPromociones?> ObtenerPorId(int id);
        Task<bool> Insertar(ReaccionesPromociones modelo);
        Task<bool> Actualizar(int id, ReaccionesPromociones modelo);
        Task<bool> Eliminar(int id);
    }
}
