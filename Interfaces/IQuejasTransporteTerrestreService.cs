using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IQuejasTransporteTerrestreService
    {
        Task<List<QuejasTransporteTerrestre>> ListarTodo();
        Task<QuejasTransporteTerrestre ?> ObtenerPorId(int id);
        Task<bool> Insertar(QuejasTransporteTerrestre m);
        Task<bool> Actualizar(int id, QuejasTransporteTerrestre m);
        Task<bool> Eliminar(int id);
    }
}