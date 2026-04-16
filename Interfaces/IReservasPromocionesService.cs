using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IReservasPromocionesService
    {
        Task<bool> AplicarPromocion(ReservasPromocionesModel modelo);
        Task<List<ReservasPromocionesModel>> ListarPorReserva(int idReserva);
        Task<bool> EliminarRelacion(int idReserva, int idPromocion);
    }
}