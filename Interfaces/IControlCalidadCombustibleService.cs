using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IControlCalidadCombustibleService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(ControlCalidadCombustible modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, ControlCalidadCombustible modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<ControlCalidadCombustible>> ListarTodo();

        // Buscar por ID específico
        Task<ControlCalidadCombustible?> ObtenerPorId(int id);
    }
}


