using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IGastoService
    {
        Task<List<Gasto>> ListarTodo();
        Task<Gasto ?> ObtenerPorId(int id);
        Task<bool> Insertar(Gasto m);
        Task<bool> Actualizar(int id, Gasto m);
        Task<bool> Eliminar(int id);
    }
}