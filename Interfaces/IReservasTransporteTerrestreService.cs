using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IReservasTransporteTerrestreService
    {
        Task<List<ReservasTransporteTerrestre>> ListarTodo();
        Task<ReservasTransporteTerrestre ?> ObtenerPorId(int id);
        Task<bool> Insertar(ReservasTransporteTerrestre m);
        Task<bool> Actualizar(int id, ReservasTransporteTerrestre m);
        Task<bool> Eliminar(int id);
    }
}