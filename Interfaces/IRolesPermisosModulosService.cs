using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRolesPermisosModulosService
    {
        Task<List<RolesPermisosModulos>> ListarTodo();
        Task<RolesPermisosModulos ?> ObtenerPorId(int id);
        Task<bool> Insertar(RolesPermisosModulos m);
        Task<bool> Actualizar(int id, RolesPermisosModulos m);
        Task<bool> Eliminar(int id);
    }
}