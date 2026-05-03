using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITareaEjecutadaService
    {
        Task<List<TareaEjecutada>> ListarTodo();
        Task<bool> Insertar(TareaEjecutada modelo);
        Task<TareaEjecutada?> ObtenerPorId(int id);
        Task<bool> Actualizar(TareaEjecutada modelo);
        Task<bool> Eliminar(int id);
    }
}