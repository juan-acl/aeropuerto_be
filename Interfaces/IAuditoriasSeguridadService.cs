using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAuditoriasSeguridadService
    {
        Task<List<AuditoriasSeguridad>> ListarTodo();
        Task<AuditoriasSeguridad ?> ObtenerPorId(int id);
        Task<bool> Insertar(AuditoriasSeguridad m);
        Task<bool> Actualizar(int id, AuditoriasSeguridad m);
        Task<bool> Eliminar(int id);
    }
}