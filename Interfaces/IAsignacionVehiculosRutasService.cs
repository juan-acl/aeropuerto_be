using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAsignacionVehiculosRutasService
    {
        Task<List<AsignacionVehiculosRutas>> ListarTodo();
        Task<AsignacionVehiculosRutas ?> ObtenerPorId(int id);
        Task<bool> Insertar(AsignacionVehiculosRutas m);
        Task<bool> Actualizar(int id, AsignacionVehiculosRutas m);
        Task<bool> Eliminar(int id);
    }
}