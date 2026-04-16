using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IVentasDetalleService
    {
        Task<bool> RegistrarDetalle(VentasDetalleModel modelo);
        Task<bool> RegistrarMultiplesDetalles(List<VentasDetalleModel> detalles);
        Task<List<VentasDetalleModel>> ListarPorVenta(int idVenta);
        Task<bool> EliminarFisico(int id);
    }
}