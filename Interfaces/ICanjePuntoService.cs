using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICanjePuntoService
    {
        Task<List<CanjesPuntos>> ListarTodo();
        Task<CanjesPuntos?> ObtenerPorId(int id);
        Task<bool> Insertar(CanjesPuntos modelo);
        Task<bool> Actualizar(int id, CanjesPuntos modelo);
        Task<bool> Eliminar(int id);
    }
}
