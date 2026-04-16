using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IProveedorService
    {
        Task<List<Proveedor>> ListarTodo();
        Task<bool> Insertar(Proveedor modelo);
    }
}