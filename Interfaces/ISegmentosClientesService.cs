using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISegmentosClientesService
    {
        Task<List<SegmentosClientes>> ListarTodo();
        Task<SegmentosClientes ?> ObtenerPorId(int id);
        Task<bool> Insertar(SegmentosClientes m);
        Task<bool> Actualizar(int id, SegmentosClientes m);
        Task<bool> Eliminar(int id);
    }
}