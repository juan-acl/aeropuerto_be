using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRolSistemaService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(RolesSistema modelo);



        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<RolesSistema>> ListarTodo();

        // Buscar por ID específico

    }
}
