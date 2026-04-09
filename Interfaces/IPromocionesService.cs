using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPromocionesService
    {
        Task<bool> Insertar(PromocionesModel modelo);
        Task<List<PromocionesModel>> ListarTodas();
        Task<PromocionesModel?> ObtenerPorCodigo(string codigo);
        Task<bool> Actualizar(int id, PromocionesModel modelo);
        Task<bool> EliminarFisico(int id);
    }
}