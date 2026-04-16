using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IReclamacionesObjetosService
    {
        Task<bool> RegistrarReclamacion(ReclamacionesObjetosModel modelo);
        Task<List<ReclamacionesObjetosModel>> ListarPendientes();
        Task<List<ReclamacionesObjetosModel>> ListarPorPasajero(int idPasajero);
        Task<bool> ResolverReclamacion(int idReclamacion, string estado, string resolucion, string resueltoPor);
        Task<bool> EliminarFisico(int id);
    }
}