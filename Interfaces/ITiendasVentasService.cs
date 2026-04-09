using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITiendasVentasService
    {
        Task<int> RegistrarVentaCabecera(TiendasVentasModel modelo);
        Task<List<TiendasVentasModel>> ListarPorConcesion(int idConcesion);
        Task<List<TiendasVentasModel>> ListarPorPasajero(int idPasajero);
        Task<bool> EliminarFisico(int id);
    }
}