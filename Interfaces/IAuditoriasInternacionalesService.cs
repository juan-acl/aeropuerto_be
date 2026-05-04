using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAuditoriasInternacionalesService
    {
        Task<List<AuditoriasInternacionales>> ListarTodo();
        Task<AuditoriasInternacionales ?> ObtenerPorId(int id);
        Task<bool> Insertar(AuditoriasInternacionales m);
        Task<bool> Actualizar(int id, AuditoriasInternacionales m);
        Task<bool> Eliminar(int id);
    }
}