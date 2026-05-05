using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRetrasosTiempoRealService
    {
        Task<List<RetrasosTiempoReal>> ListarTodo();
        Task<RetrasosTiempoReal ?> ObtenerPorId(int id);
        Task<bool> Insertar(RetrasosTiempoReal m);
        Task<bool> Actualizar(int id, RetrasosTiempoReal m);
        Task<bool> Eliminar(int id);
    }
}