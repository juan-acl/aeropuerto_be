using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface ICapacidadTerminalTiempoRealService
    {
        Task<List<CapacidadTerminalTiempoReal>> ListarTodo();
        Task<CapacidadTerminalTiempoReal?> ObtenerPorId(int id);
        Task<bool> Insertar(CapacidadTerminalTiempoReal modelo);
        Task<bool> Actualizar(int id, CapacidadTerminalTiempoReal modelo);
        Task<bool> Eliminar(int id);
    }
}
