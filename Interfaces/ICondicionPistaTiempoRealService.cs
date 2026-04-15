using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface ICondicionPistaTiempoRealService
    {
        Task<List<CondicionesPistaTiempoReal>> ListarTodo();
        Task<CondicionesPistaTiempoReal?> ObtenerPorId(int id);
        Task<bool> Insertar(CondicionesPistaTiempoReal modelo);
        Task<bool> Actualizar(int id, CondicionesPistaTiempoReal modelo);
        Task<bool> Eliminar(int id);
    }
}
