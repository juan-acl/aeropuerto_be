using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRecursosEmergenciaService
    {
        Task<List<RecursosEmergencia>> ListarTodo();
        Task<RecursosEmergencia ?> ObtenerPorId(int id);
        Task<bool> Insertar(RecursosEmergencia m);
        Task<bool> Actualizar(int id, RecursosEmergencia m);
        Task<bool> Eliminar(int id);
    }
}