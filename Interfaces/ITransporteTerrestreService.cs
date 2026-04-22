using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITransporteTerrestreService
    {
        Task<List<TransporteTerrestreModel>> ListarTodo();
        Task<TransporteTerrestreModel?> ObtenerPorId(int id);
        Task<bool> Insertar(TransporteTerrestreModel modelo);
        Task<bool> Actualizar(int id, TransporteTerrestreModel modelo);
        Task<bool> Eliminar(int id);
    }
}
