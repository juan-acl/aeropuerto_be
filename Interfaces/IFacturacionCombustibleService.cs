using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IFacturacionCombustibleService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(FacturacionCombustible modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, FacturacionCombustible modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<FacturacionCombustible>> ListarTodo();

        // Buscar por ID específico
        Task<FacturacionCombustible?> ObtenerPorId(int id);
    }
}

