using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISolicitudesEspecialesService
    {
        Task<bool> Insertar(SolicitudesEspecialesModel modelo);
        Task<List<SolicitudesEspecialesModel>> ListarPorReserva(int idReserva);
        Task<bool> ResolverSolicitud(int id, string resolucion, string nuevoEstado);
        Task<bool> EliminarFisico(int id);
    }
}