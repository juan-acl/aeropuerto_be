using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITransporteTerrestreService
    {
        Task<List<TransporteTerrestreModel>> ListarTodo();
        Task<TransporteTerrestreModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(TransporteTerrestreModel m);
        Task<bool> Actualizar(int id, TransporteTerrestreModel m);
        Task<bool> Eliminar(int id);
    }
}