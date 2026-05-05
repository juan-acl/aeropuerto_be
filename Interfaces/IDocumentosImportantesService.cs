using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IDocumentosImportantesService
    {
        Task<List<DocumentosImportantes>> ListarTodo();
        Task<DocumentosImportantes ?> ObtenerPorId(int id);
        Task<bool> Insertar(DocumentosImportantes m);
        Task<bool> Actualizar(int id, DocumentosImportantes m);
        Task<bool> Eliminar(int id);
    }
}