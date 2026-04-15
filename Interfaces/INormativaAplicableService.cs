using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface INormativaAplicableService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(NormativasAplicables modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, NormativasAplicables modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<NormativasAplicables>> ListarTodo();

        // Buscar por ID específico
        Task<NormativasAplicables?> ObtenerPorId(int id);
    }
}


