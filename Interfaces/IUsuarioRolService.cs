using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IUsuarioRolService
    {
        Task<List<UsuariosRoles>> ListarTodo();
        Task<UsuariosRoles?> ObtenerPorId(int id);
        Task<bool> Insertar(UsuariosRoles modelo);
        Task<bool> Actualizar(int id, UsuariosRoles modelo);
        Task<bool> Eliminar(int id);
    }
}
