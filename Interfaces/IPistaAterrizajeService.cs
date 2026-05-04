using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPistaAterrizajeService
    {
        Task<List<PistaAterrizajeModel>> ListarTodo();
        Task<PistaAterrizajeModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(PistaAterrizajeModel m);
        Task<bool> Actualizar(int id, PistaAterrizajeModel m);
        Task<bool> Eliminar(int id);
    }
}