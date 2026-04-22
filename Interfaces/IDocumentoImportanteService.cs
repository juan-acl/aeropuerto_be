using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IDocumentoImportanteService
    {
        Task<List<DocumentosImportantes>> ListarTodo();
        Task<DocumentosImportantes?> ObtenerPorId(int id);
        Task<bool> Insertar(DocumentosImportantes modelo);
        Task<bool> Actualizar(int id, DocumentosImportantes modelo);
        Task<bool> Eliminar(int id);
    }
}
