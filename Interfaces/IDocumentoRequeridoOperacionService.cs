using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IDocumentoRequeridoOperacionService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(DocumentosRequeridosOperacion modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, DocumentosRequeridosOperacion modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<DocumentosRequeridosOperacion>> ListarTodo();

        // Buscar por ID específico
        Task<DocumentosRequeridosOperacion?> ObtenerPorId(int id);
    }
}


