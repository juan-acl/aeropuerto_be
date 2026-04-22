using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISegmentoClienteService
    {
        Task<List<SegmentosClientes>> ListarTodo();
        Task<SegmentosClientes?> ObtenerPorId(int id);
        Task<bool> Insertar(SegmentosClientes modelo);
        Task<bool> Actualizar(int id, SegmentosClientes modelo);
        Task<bool> Eliminar(int id);
    }
}
