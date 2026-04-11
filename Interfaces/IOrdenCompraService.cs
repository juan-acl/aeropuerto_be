using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IOrdenCompraService
    {
        Task<List<OrdenCompra>> ListarTodo();
        Task<bool> Insertar(OrdenCompra modelo);
    }
}