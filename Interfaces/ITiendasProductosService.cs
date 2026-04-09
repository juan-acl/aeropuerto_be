using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITiendasProductosService
    {
        Task<bool> RegistrarProducto(TiendasProductosModel modelo);
        Task<List<TiendasProductosModel>> ListarPorConcesion(int idConcesion);
        Task<List<TiendasProductosModel>> ListarBajoStockMinimo(int idConcesion);
        Task<bool> ActualizarStock(int idProducto, int nuevoStock);
        Task<bool> DesactivarProducto(int id);
        Task<bool> EliminarFisico(int id);
    }
}