using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IDocumentosImportantesService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(DocumentosImportantes modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, DocumentosImportantes modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<DocumentosImportantes>> ListarTodo();

        // Buscar por ID específico
        Task<DocumentosImportantes?> ObtenerPorId(int id);
    }
}


