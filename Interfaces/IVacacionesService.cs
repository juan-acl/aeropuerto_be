using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IVacacionesService
    {
        Task<List<VacacionesPermiso>> ListarTodo();
        Task<bool> Insertar(VacacionesPermiso modelo);
    }
}