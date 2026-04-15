using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISimulacroService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(Simulacros modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, Simulacros modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<Simulacros>> ListarTodo();

        // Buscar por ID específico
        Task<Simulacros?> ObtenerPorId(int id);
    }
}


