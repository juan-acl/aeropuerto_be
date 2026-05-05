using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IInventarioCombustibleService
    {
        Task<List<InventarioCombustible>> ListarTodo();
        Task<InventarioCombustible ?> ObtenerPorId(int id);
        Task<bool> Insertar(InventarioCombustible m);
        Task<bool> Actualizar(int id, InventarioCombustible m);
        Task<bool> Eliminar(int id);
    }
}