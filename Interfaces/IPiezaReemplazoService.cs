using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPiezaReemplazoService
    {
        Task<List<PiezaReemplazo>> ListarTodo();
        Task<PiezaReemplazo ?> ObtenerPorId(int id);
        Task<bool> Insertar(PiezaReemplazo m);
        Task<bool> Actualizar(int id, PiezaReemplazo m);
        Task<bool> Eliminar(int id);
    }
}