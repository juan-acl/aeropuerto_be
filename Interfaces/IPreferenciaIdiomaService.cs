using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPreferenciaIdiomaService
    {
        Task<bool> Insertar(PreferenciaIdiomaModel modelo);
        Task<List<PreferenciaIdiomaModel>> ListarPorPasajero(int idPasajero);
        Task<bool> Actualizar(int id, PreferenciaIdiomaModel modelo);
        Task<bool> EliminarFisico(int id);
    }
}