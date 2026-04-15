using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAuditoriaInternacionalService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(AuditoriasInternacionales modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, AuditoriasInternacionales modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<AuditoriasInternacionales>> ListarTodo();

        // Buscar por ID específico
        Task<AuditoriasInternacionales?> ObtenerPorId(int id);
    }
}

