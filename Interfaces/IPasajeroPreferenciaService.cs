using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasajeroPreferenciaService
    {
        Task<List<PasajeroPreferenciaModel>> ListarTodo();
        Task<PasajeroPreferenciaModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(PasajeroPreferenciaModel m);
        Task<bool> Actualizar(int id, PasajeroPreferenciaModel m);
        Task<bool> Eliminar(int id);
    }
}