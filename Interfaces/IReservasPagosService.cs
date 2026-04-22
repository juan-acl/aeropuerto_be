using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IReservasPagosService
    {
        Task<List<ReservasPagosModel>> ListarTodo();
        Task<ReservasPagosModel?> ObtenerPorId(int id);
        Task<bool> Insertar(ReservasPagosModel modelo);
        Task<bool> Actualizar(int id, ReservasPagosModel modelo);
        Task<bool> Eliminar(int id);
    }
}
