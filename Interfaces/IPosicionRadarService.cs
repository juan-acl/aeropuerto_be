using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface IPosicionRadarService
    {
        Task<List<PosicionesRadar>> ListarTodo();
        Task<PosicionesRadar?> ObtenerPorId(int id);
        Task<bool> Insertar(PosicionesRadar modelo);
        Task<bool> Actualizar(int id, PosicionesRadar modelo);
        Task<bool> Eliminar(int id);
    }
}
