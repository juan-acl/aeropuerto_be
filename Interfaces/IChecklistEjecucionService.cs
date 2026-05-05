using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IChecklistEjecucionService
    {
        Task<List<ChecklistEjecucion>> ListarTodo();
        Task<ChecklistEjecucion ?> ObtenerPorId(int id);
        Task<bool> Insertar(ChecklistEjecucion m);
        Task<bool> Actualizar(int id, ChecklistEjecucion m);
        Task<bool> Eliminar(int id);
    }
}