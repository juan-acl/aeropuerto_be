using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IReservaTransporteService
    {
        Task<List<ReservasTransporteTerrestre>> ListarTodo();
        Task<ReservasTransporteTerrestre?> ObtenerPorId(int id);
        Task<bool> Insertar(ReservasTransporteTerrestre modelo);
        Task<bool> Actualizar(int id, ReservasTransporteTerrestre modelo);
        Task<bool> Eliminar(int id);
    }
}
