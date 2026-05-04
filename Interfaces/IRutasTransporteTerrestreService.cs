using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRutasTransporteTerrestreService
    {
        Task<List<RutasTransporteTerrestre>> ListarTodo();
        Task<RutasTransporteTerrestre ?> ObtenerPorId(int id);
        Task<bool> Insertar(RutasTransporteTerrestre m);
        Task<bool> Actualizar(int id, RutasTransporteTerrestre m);
        Task<bool> Eliminar(int id);
    }
}