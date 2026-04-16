using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IOrdenDetalleService
    {
        Task<List<OrdenDetalle>> ListarTodo();
        Task<bool> Insertar(OrdenDetalle modelo);
    }
}