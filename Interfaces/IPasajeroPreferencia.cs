using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasajeroPreferenciaService
    {
        Task<bool> Insertar(PasajeroPreferenciaModel modelo);
        Task<List<PasajeroPreferenciaModel>> ListarPorPasajero(int idPasajero);
        Task<bool> ActualizarPreferencia(int id, string descripcion);
        Task<bool> EliminarLogico(int id);
    }
}