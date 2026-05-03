using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IChecklistMantenimientoService
    {
        Task<List<ChecklistMantenimiento>> ListarTodo();
        Task<bool> Insertar(ChecklistMantenimiento modelo);
        Task<ChecklistMantenimiento?> ObtenerPorId(int id);
        Task<bool> Actualizar(ChecklistMantenimiento modelo);
        Task<bool> Eliminar(int id);
    }
}