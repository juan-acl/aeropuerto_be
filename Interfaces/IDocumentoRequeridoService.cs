using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IDocumentoRequeridoService
    {
        Task<List<DocumentosRequeridosOperacion>> ListarTodo();
        Task<DocumentosRequeridosOperacion?> ObtenerPorId(int id);
        Task<bool> Insertar(DocumentosRequeridosOperacion modelo);
        Task<bool> Actualizar(int id, DocumentosRequeridosOperacion modelo);
        Task<bool> Eliminar(int id);
    }
}
