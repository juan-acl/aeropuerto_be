using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IOrdenCompraService
    {
        Task<List<OrdenCompra>> ListarTodo();
        Task<OrdenCompra ?> ObtenerPorId(int id);
        Task<bool> Insertar(OrdenCompra m);
        Task<bool> Actualizar(int id, OrdenCompra m);
        Task<bool> Eliminar(int id);
    }
}