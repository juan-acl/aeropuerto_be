using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEquipoEmergenciaService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(EquiposEmergencia modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, EquiposEmergencia modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<EquiposEmergencia>> ListarTodo();

        // Buscar por ID específico
        Task<EquiposEmergencia?> ObtenerPorId(int id);
    }
}



