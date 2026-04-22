using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IMetodosPagoService
    {
        Task<List<MetodosPagoModel>> ListarTodo();
        Task<MetodosPagoModel?> ObtenerPorId(int id);
        Task<bool> Insertar(MetodosPagoModel modelo);
        Task<bool> Actualizar(int id, MetodosPagoModel modelo);
        Task<bool> Eliminar(int id);
    }
}
