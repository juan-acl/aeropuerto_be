using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IDocumentosRequeridosOperacionService
    {
        Task<List<DocumentosRequeridosOperacion>> ListarTodo();
        Task<DocumentosRequeridosOperacion ?> ObtenerPorId(int id);
        Task<bool> Insertar(DocumentosRequeridosOperacion m);
        Task<bool> Actualizar(int id, DocumentosRequeridosOperacion m);
        Task<bool> Eliminar(int id);
    }
}