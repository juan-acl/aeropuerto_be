using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITareaEjecutadaService
    {
        Task<List<TareaEjecutada>> ListarTodo();
        Task<TareaEjecutada ?> ObtenerPorId(int id);
        Task<bool> Insertar(TareaEjecutada m);
        Task<bool> Actualizar(int id, TareaEjecutada m);
        Task<bool> Eliminar(int id);
    }
}