using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface IPistaAterrizajeService
    {
        Task<List<PistaAterrizajeModel>> ListarTodo();
        Task<PistaAterrizajeModel?> ObtenerPorId(int id);
        Task<bool> Insertar(PistaAterrizajeModel modelo);
        Task<bool> Actualizar(int id, PistaAterrizajeModel modelo);
        Task<bool> Eliminar(int id);
    }
}
