using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRolPermisoModuloService
    {
        Task<List<RolesPermisosModulos>> ListarTodo();
        Task<RolesPermisosModulos?> ObtenerPorId(int id);
        Task<bool> Insertar(RolesPermisosModulos modelo);
        Task<bool> Actualizar(int id, RolesPermisosModulos modelo);
        Task<bool> Eliminar(int id);
    }
}
