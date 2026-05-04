using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAsignacionPistasTiempoRealService
    {
        Task<List<AsignacionPistasTiempoReal>> ListarTodo();
        Task<AsignacionPistasTiempoReal ?> ObtenerPorId(int id);
        Task<bool> Insertar(AsignacionPistasTiempoReal m);
        Task<bool> Actualizar(int id, AsignacionPistasTiempoReal m);
        Task<bool> Eliminar(int id);
    }
}