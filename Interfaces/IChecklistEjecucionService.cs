using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IChecklistEjecucionService
    {
        Task<List<ChecklistEjecucion>> ListarTodo();
        Task<bool> Insertar(ChecklistEjecucion modelo);
    }
}