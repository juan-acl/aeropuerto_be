using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IFacturasService
    {
        Task<bool> Insertar(FacturasModel modelo);
        Task<FacturasModel?> ObtenerPorReserva(int idReserva);
        Task<List<FacturasModel>> ListarTodo();
        Task<bool> Actualizar(int id, FacturasModel modelo);
        Task<bool> EliminarFisico(int id);
    }
}