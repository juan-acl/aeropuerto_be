using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRevisionesDocumentosService
    {
        Task<List<RevisionesDocumentos>> ListarTodo();
        Task<RevisionesDocumentos ?> ObtenerPorId(int id);
        Task<bool> Insertar(RevisionesDocumentos m);
        Task<bool> Actualizar(int id, RevisionesDocumentos m);
        Task<bool> Eliminar(int id);
    }
}