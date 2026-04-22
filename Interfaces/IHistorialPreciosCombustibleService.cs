using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IHistorialPreciosCombustibleService
    {
        Task<List<HistorialPreciosCombustible>> ListarTodo();
        Task<HistorialPreciosCombustible?> ObtenerPorId(int id);
        Task<bool> Insertar(HistorialPreciosCombustible modelo);
        Task<bool> Actualizar(int id, HistorialPreciosCombustible modelo);
        Task<bool> Eliminar(int id);
    }
}
