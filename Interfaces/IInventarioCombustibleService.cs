using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IInventarioCombustibleService
    {
        Task<List<InventarioCombustible>> ListarTodo();
        Task<InventarioCombustible?> ObtenerPorId(int id);
        Task<bool> Insertar(InventarioCombustible modelo);
        Task<bool> Actualizar(int id, InventarioCombustible modelo);
        Task<bool> Eliminar(int id);
    }
}
