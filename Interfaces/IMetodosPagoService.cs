using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IMetodosPagoService
    {
        Task<bool> Insertar(MetodosPagoModel modelo);
        Task<List<MetodosPagoModel>> ListarActivos();
        Task<bool> Actualizar(int id, MetodosPagoModel modelo);
        Task<bool> EliminarFisico(int id);
    }
}