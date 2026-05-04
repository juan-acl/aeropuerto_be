using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IHistorialComunicacionService
    {
        Task<List<HistorialComunicacionModel>> ListarTodo();
        Task<HistorialComunicacionModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(HistorialComunicacionModel m);
        Task<bool> Actualizar(int id, HistorialComunicacionModel m);
        Task<bool> Eliminar(int id);
    }
}