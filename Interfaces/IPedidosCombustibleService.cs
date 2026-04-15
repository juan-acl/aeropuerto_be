using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPedidosCombustibleService
    {
        Task<List<PedidosCombustible>>  ListarTodo();
        Task<PedidosCombustible?>       ObtenerPorId(int id);
        Task<bool>                      Insertar(PedidosCombustible modelo);
        Task<bool>                      Actualizar(int id, PedidosCombustible modelo);
        Task<bool>                      Eliminar(int id);
    }
}
