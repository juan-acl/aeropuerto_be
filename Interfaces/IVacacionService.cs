using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IVacacionesService
    {
        Task<List<VacacionPermiso>> ListarTodo();
        Task<bool> Insertar(VacacionPermiso modelo);
        Task<VacacionPermiso?> ObtenerPorId(int id);
        Task<bool> Actualizar(VacacionPermiso modelo);
        Task<bool> Eliminar(int id);
    }
}