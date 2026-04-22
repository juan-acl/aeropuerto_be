using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IQuejaTransporteService
    {
        Task<List<QuejasTransporteTerrestre>> ListarTodo();
        Task<QuejasTransporteTerrestre?> ObtenerPorId(int id);
        Task<bool> Insertar(QuejasTransporteTerrestre modelo);
        Task<bool> Actualizar(int id, QuejasTransporteTerrestre modelo);
        Task<bool> Eliminar(int id);
    }
}
