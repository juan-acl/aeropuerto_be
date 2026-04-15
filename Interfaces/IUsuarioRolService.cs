using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IUsuarioRolService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(UsuariosRoles modelo);


        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<UsuariosRoles>> ListarTodo();

    }
}


