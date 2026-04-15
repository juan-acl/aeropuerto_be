using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface IRevisionDocumentoService
    {
        Task<List<RevisionesDocumentos>> ListarTodo();
        Task<RevisionesDocumentos?> ObtenerPorId(int id);
        Task<bool> Insertar(RevisionesDocumentos modelo);
        Task<bool> Actualizar(int id, RevisionesDocumentos modelo);
        Task<bool> Eliminar(int id);
    }
}
