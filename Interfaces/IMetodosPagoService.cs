using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IMetodosPagoService
    {
        Task<List<MetodosPagoModel>> ListarTodo();
        Task<MetodosPagoModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(MetodosPagoModel m);
        Task<bool> Actualizar(int id, MetodosPagoModel m);
        Task<bool> Eliminar(int id);
    }
}