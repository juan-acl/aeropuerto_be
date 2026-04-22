using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IVentasDetalleService
    {
        Task<List<VentasDetalleModel>> ListarTodo();
        Task<VentasDetalleModel?> ObtenerPorId(int id);
        Task<bool> Insertar(VentasDetalleModel modelo);
        Task<bool> Actualizar(int id, VentasDetalleModel modelo);
        Task<bool> Eliminar(int id);
    }
}
