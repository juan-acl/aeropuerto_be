using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IOrdenCompraService
    {
        Task<List<OrdenCompra>> ListarTodo();
        Task<bool> Insertar(OrdenCompra modelo);
        Task<OrdenCompra?> ObtenerPorId(int id);
        Task<bool> Actualizar(OrdenCompra modelo);
        Task<bool> Eliminar(int id);
    }
}