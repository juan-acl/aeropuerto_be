using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPedidosCombustibleService
    {
        Task<List<PedidosCombustible>> ListarTodo();
        Task<PedidosCombustible ?> ObtenerPorId(int id);
        Task<bool> Insertar(PedidosCombustible m);
        Task<bool> Actualizar(int id, PedidosCombustible m);
        Task<bool> Eliminar(int id);
    }
}