using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface I
    {
        Task<List<TarifasTransporteTerrestre>> ListarTodo();
        Task<TarifasTransporteTerrestre?> ObtenerPorId(int id);
        Task<bool> Insertar(TarifasTransporteTerrestre modelo);
        Task<bool> Actualizar(int id, TarifasTransporteTerrestre modelo);
        Task<bool> Eliminar(int id);
    }
}
