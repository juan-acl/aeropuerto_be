using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPersonalEmergenciaService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(PersonalEmergencia modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, PersonalEmergencia modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<PersonalEmergencia>> ListarTodo();

        // Buscar por ID específico
        Task<PersonalEmergencia?> ObtenerPorId(int id);
    }
}


