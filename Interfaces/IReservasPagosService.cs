using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IReservasPagosService
    {
        Task<bool> Insertar(ReservasPagosModel modelo);
        Task<List<ReservasPagosModel>> ListarPorReserva(int idReserva);
        Task<bool> ActualizarEstado(int idPago, string nuevoEstado);
        Task<bool> EliminarFisico(int idPago);
    }
}