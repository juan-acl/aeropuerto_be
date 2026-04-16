using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IReservasService
    {
        Task<bool> Insertar(ReservasModel modelo);
        Task<List<ReservasModel>> ListarPorPasajero(int idPasajero);
        Task<ReservasModel?> ObtenerPorCodigo(string codigo);
        Task<bool> Actualizar(int id, ReservasModel modelo);
        Task<bool> EliminarFisico(int id);
    }
}