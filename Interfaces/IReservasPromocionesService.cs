using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IReservasPromocionesService
    {
        Task<List<ReservasPromocionesModel>> ListarTodo();
        Task<ReservasPromocionesModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(ReservasPromocionesModel m);
        Task<bool> Actualizar(int id, ReservasPromocionesModel m);
        Task<bool> Eliminar(int id);
    }
}