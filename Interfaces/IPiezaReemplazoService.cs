using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPiezaReemplazoService
    {
        Task<List<PiezaReemplazo>> ListarTodo();
        Task<bool> Insertar(PiezaReemplazo modelo);
        Task<PiezaReemplazo?> ObtenerPorId(int id);
        Task<bool> Actualizar(PiezaReemplazo modelo);
        Task<bool> Eliminar(int id);
    }
}