using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAsignacionPistasTiempoRealService
    {
        Task<List<AsignacionPistasTiempoReal>> ListarTodo();
        Task<AsignacionPistasTiempoReal?> ObtenerPorId(int id);
        Task<bool> Insertar(AsignacionPistasTiempoReal modelo);
        Task<bool> Actualizar(int id, AsignacionPistasTiempoReal modelo);
        Task<bool> Eliminar(int id);
    }
}
