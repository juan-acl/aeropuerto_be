using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IHistorialReservasService
    {
        Task<bool> Insertar(HistorialReservasModel modelo);
        Task<List<HistorialReservasModel>> ListarPorReserva(int idReserva);
        Task<bool> Actualizar(int id, HistorialReservasModel modelo);
        Task<bool> EliminarFisico(int id);
    }
}