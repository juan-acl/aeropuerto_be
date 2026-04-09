using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAcompanantesViajeService
    {
        Task<bool> Insertar(AcompanantesViajeModel modelo);
        Task<List<AcompanantesViajeModel>> ListarPorPasajeroPrincipal(int idPasajeroPrincipal);
        Task<bool> Actualizar(int id, AcompanantesViajeModel modelo);
        Task<bool> EliminarFisico(int id);
    }
}