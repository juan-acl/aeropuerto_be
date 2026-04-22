using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRetrasosTiempoRealService
    {
        Task<List<RetrasosTiempoReal>> ListarTodo();
        Task<RetrasosTiempoReal?> ObtenerPorId(int id);
        Task<bool> Insertar(RetrasosTiempoReal modelo);
        Task<bool> Actualizar(int id, RetrasosTiempoReal modelo);
        Task<bool> Eliminar(int id);
    }
}
