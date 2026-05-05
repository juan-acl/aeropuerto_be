using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IVacacionesPermisoService
    {
        Task<List<VacacionesPermiso>> ListarTodo();
        Task<VacacionesPermiso ?> ObtenerPorId(int id);
        Task<bool> Insertar(VacacionesPermiso m);
        Task<bool> Actualizar(int id, VacacionesPermiso m);
        Task<bool> Eliminar(int id);
    }
}