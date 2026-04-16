using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITareaEjecutadaService
    {
        Task<List<TareaEjecutada>> ListarTodo();
        Task<bool> Insertar(TareaEjecutada modelo);
    }
}