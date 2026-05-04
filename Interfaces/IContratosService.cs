using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IContratosService
    {
        Task<List<Contratos>> ListarTodo();
        Task<Contratos ?> ObtenerPorId(int id);
        Task<bool> Insertar(Contratos m);
        Task<bool> Actualizar(int id, Contratos m);
        Task<bool> Eliminar(int id);
    }
}