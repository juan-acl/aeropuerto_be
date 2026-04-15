using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface ITorreControlComunicacionService
    {
        Task<List<TorreControlComunicaciones>> ListarTodo();
        Task<TorreControlComunicaciones?> ObtenerPorId(int id);
        Task<bool> Insertar(TorreControlComunicaciones modelo);
        Task<bool> Actualizar(int id, TorreControlComunicaciones modelo);
        Task<bool> Eliminar(int id);
    }
}
