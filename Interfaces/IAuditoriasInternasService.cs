using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAuditoriasInternasService
    {
        Task<List<AuditoriasInternas>> ListarTodo();
        Task<AuditoriasInternas ?> ObtenerPorId(int id);
        Task<bool> Insertar(AuditoriasInternas m);
        Task<bool> Actualizar(int id, AuditoriasInternas m);
        Task<bool> Eliminar(int id);
    }
}