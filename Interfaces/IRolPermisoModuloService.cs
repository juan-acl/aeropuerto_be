using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRolPermisoModuloService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(RolesPermisosModulos modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<RolesPermisosModulos>> ListarTodo();

    }
}


