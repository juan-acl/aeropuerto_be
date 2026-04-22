using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAuditoriaInternacionalService
    {
        Task<List<AuditoriasInternacionales>> ListarTodo();
        Task<AuditoriasInternacionales?> ObtenerPorId(int id);
        Task<bool> Insertar(AuditoriasInternacionales modelo);
        Task<bool> Actualizar(int id, AuditoriasInternacionales modelo);
        Task<bool> Eliminar(int id);
    }
}
