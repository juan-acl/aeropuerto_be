using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IReaccionesPromocionesService
    {
        Task<List<ReaccionesPromociones>> ListarTodo();
        Task<ReaccionesPromociones ?> ObtenerPorId(int id);
        Task<bool> Insertar(ReaccionesPromociones m);
        Task<bool> Actualizar(int id, ReaccionesPromociones m);
        Task<bool> Eliminar(int id);
    }
}