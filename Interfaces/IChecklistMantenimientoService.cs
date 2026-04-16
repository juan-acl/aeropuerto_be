using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IChecklistMantenimientoService
    {
        Task<List<ChecklistMantenimiento>> ListarTodo();
        Task<bool> Insertar(ChecklistMantenimiento modelo);
    }
}