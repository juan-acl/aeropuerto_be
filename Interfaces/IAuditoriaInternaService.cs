using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAuditoriaInternaService
    {
        Task<List<AuditoriasInternas>> ListarTodo();
        Task<AuditoriasInternas?> ObtenerPorId(int id);
        Task<bool> Insertar(AuditoriasInternas modelo);
        Task<bool> Actualizar(int id, AuditoriasInternas modelo);
        Task<bool> Eliminar(int id);
    }
}
