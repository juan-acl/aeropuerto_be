using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAuditoriaSeguridadService
    {
        Task<List<AuditoriasSeguridad>> ListarTodo();
        Task<AuditoriasSeguridad?> ObtenerPorId(int id);
        Task<bool> Insertar(AuditoriasSeguridad modelo);
        Task<bool> Actualizar(int id, AuditoriasSeguridad modelo);
        Task<bool> Eliminar(int id);
    }
}
