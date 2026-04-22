using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPromocionesService
    {
        Task<List<PromocionesModel>> ListarTodo();
        Task<PromocionesModel?> ObtenerPorId(int id);
        Task<bool> Insertar(PromocionesModel modelo);
        Task<bool> Actualizar(int id, PromocionesModel modelo);
        Task<bool> Eliminar(int id);
    }
}
