using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRutaTransporteService
    {
        Task<List<RutasTransporteTerrestre>> ListarTodo();
        Task<RutasTransporteTerrestre?> ObtenerPorId(int id);
        Task<bool> Insertar(RutasTransporteTerrestre modelo);
        Task<bool> Actualizar(int id, RutasTransporteTerrestre modelo);
        Task<bool> Eliminar(int id);
    }
}
