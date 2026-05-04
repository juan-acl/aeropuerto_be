using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPosicionesRadarService
    {
        Task<List<PosicionesRadar>> ListarTodo();
        Task<PosicionesRadar ?> ObtenerPorId(int id);
        Task<bool> Insertar(PosicionesRadar m);
        Task<bool> Actualizar(int id, PosicionesRadar m);
        Task<bool> Eliminar(int id);
    }
}