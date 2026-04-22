using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRecursoEmergenciaService
    {
        Task<List<RecursosEmergencia>> ListarTodo();
        Task<RecursosEmergencia?> ObtenerPorId(int id);
        Task<bool> Insertar(RecursosEmergencia modelo);
        Task<bool> Actualizar(int id, RecursosEmergencia modelo);
        Task<bool> Eliminar(int id);
    }
}
