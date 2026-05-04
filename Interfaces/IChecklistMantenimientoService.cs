using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IChecklistMantenimientoService
    {
        Task<List<ChecklistMantenimiento>> ListarTodo();
        Task<ChecklistMantenimiento ?> ObtenerPorId(int id);
        Task<bool> Insertar(ChecklistMantenimiento m);
        Task<bool> Actualizar(int id, ChecklistMantenimiento m);
        Task<bool> Eliminar(int id);
    }
}