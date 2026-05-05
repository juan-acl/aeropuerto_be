using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPromocionesService
    {
        Task<List<PromocionesModel>> ListarTodo();
        Task<PromocionesModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(PromocionesModel m);
        Task<bool> Actualizar(int id, PromocionesModel m);
        Task<bool> Eliminar(int id);
    }
}