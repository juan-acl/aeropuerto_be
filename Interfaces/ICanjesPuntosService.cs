using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICanjesPuntosService
    {
        Task<List<CanjesPuntos>> ListarTodo();
        Task<CanjesPuntos ?> ObtenerPorId(int id);
        Task<bool> Insertar(CanjesPuntos m);
        Task<bool> Actualizar(int id, CanjesPuntos m);
        Task<bool> Eliminar(int id);
    }
}