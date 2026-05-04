using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITorreControlComunicacionesService
    {
        Task<List<TorreControlComunicaciones>> ListarTodo();
        Task<TorreControlComunicaciones ?> ObtenerPorId(int id);
        Task<bool> Insertar(TorreControlComunicaciones m);
        Task<bool> Actualizar(int id, TorreControlComunicaciones m);
        Task<bool> Eliminar(int id);
    }
}