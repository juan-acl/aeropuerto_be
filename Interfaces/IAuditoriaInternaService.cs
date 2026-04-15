using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAuditoriaInternaService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(AuditoriasInternas modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, AuditoriasInternas modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<AuditoriasInternas>> ListarTodo();

        // Buscar por ID específico
        Task<AuditoriasInternas?> ObtenerPorId(int id);
    }
}


