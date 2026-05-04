using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IHistorialPreciosCombustibleService
    {
        Task<List<HistorialPreciosCombustible>> ListarTodo();
        Task<HistorialPreciosCombustible ?> ObtenerPorId(int id);
        Task<bool> Insertar(HistorialPreciosCombustible m);
        Task<bool> Actualizar(int id, HistorialPreciosCombustible m);
        Task<bool> Eliminar(int id);
    }
}