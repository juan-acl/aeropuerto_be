using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IProhibicionesVueloService
    {
        Task<bool> Insertar(ProhibicionesVueloModel modelo);
        Task<bool> EsPasajeroProhibido(int idPasajero);
        Task<List<ProhibicionesVueloModel>> ListarPorPasajero(int idPasajero);
        Task<bool> DesactivarProhibicion(int id);
        Task<bool> EliminarFisico(int id);
    }
}