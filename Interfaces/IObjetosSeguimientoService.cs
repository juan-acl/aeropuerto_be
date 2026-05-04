using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IObjetosSeguimientoService
    {
        Task<List<ObjetosSeguimientoModel>> ListarTodo();
        Task<ObjetosSeguimientoModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(ObjetosSeguimientoModel m);
        Task<bool> Actualizar(int id, ObjetosSeguimientoModel m);
        Task<bool> Eliminar(int id);
    }
}