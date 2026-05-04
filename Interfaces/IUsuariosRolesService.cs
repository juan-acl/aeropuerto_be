using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IUsuariosRolesService
    {
        Task<List<UsuariosRoles>> ListarTodo();
        Task<UsuariosRoles ?> ObtenerPorId(int id);
        Task<bool> Insertar(UsuariosRoles m);
        Task<bool> Actualizar(int id, UsuariosRoles m);
        Task<bool> Eliminar(int id);
    }
}