using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IReservasPagosService
    {
        Task<List<ReservasPagosModel>> ListarTodo();
        Task<ReservasPagosModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(ReservasPagosModel m);
        Task<bool> Actualizar(int id, ReservasPagosModel m);
        Task<bool> Eliminar(int id);
    }
}