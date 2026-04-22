using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAsignacionVehiculoRutaService
    {
        Task<List<AsignacionVehiculosRutas>> ListarTodo();
        Task<AsignacionVehiculosRutas?> ObtenerPorId(int id);
        Task<bool> Insertar(AsignacionVehiculosRutas modelo);
        Task<bool> Actualizar(int id, AsignacionVehiculosRutas modelo);
        Task<bool> Eliminar(int id);
    }
}
