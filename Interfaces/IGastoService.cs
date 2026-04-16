using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IGastoService
    {
        Task<List<Gasto>> ListarTodo();
        Task<bool> Insertar(Gasto modelo);
    }
}