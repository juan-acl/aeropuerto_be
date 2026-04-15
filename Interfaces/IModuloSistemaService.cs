using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IModuloSistemaService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(ModulosSistema modelo);


        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<ModulosSistema>> ListarTodo();

        // Buscar por ID específico
        Task<ModulosSistema?> ObtenerPorId(int id);
    }
}



