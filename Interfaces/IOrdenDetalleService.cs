using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IOrdenDetalleService
    {
        Task<List<OrdenDetalle>> ListarTodo();
        Task<OrdenDetalle ?> ObtenerPorId(int id);
        Task<bool> Insertar(OrdenDetalle m);
        Task<bool> Actualizar(int id, OrdenDetalle m);
        Task<bool> Eliminar(int id);
    }
}