using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IProveedorService
    {
        Task<List<Proveedor>> ListarTodo();
        Task<Proveedor ?> ObtenerPorId(int id);
        Task<bool> Insertar(Proveedor m);
        Task<bool> Actualizar(int id, Proveedor m);
        Task<bool> Eliminar(int id);
    }
}