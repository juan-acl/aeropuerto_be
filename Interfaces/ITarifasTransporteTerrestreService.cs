using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITarifasTransporteTerrestreService
    {
        Task<List<TarifasTransporteTerrestre>> ListarTodo();
        Task<TarifasTransporteTerrestre ?> ObtenerPorId(int id);
        Task<bool> Insertar(TarifasTransporteTerrestre m);
        Task<bool> Actualizar(int id, TarifasTransporteTerrestre m);
        Task<bool> Eliminar(int id);
    }
}