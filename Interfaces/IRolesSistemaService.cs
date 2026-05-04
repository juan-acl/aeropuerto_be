using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRolesSistemaService
    {
        Task<List<RolesSistema>> ListarTodo();
        Task<RolesSistema ?> ObtenerPorId(int id);
        Task<bool> Insertar(RolesSistema m);
        Task<bool> Actualizar(int id, RolesSistema m);
        Task<bool> Eliminar(int id);
    }
}