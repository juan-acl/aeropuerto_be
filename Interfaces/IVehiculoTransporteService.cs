using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IVehiculoTransporteService
    {
        Task<List<VehiculosTransporte>> ListarTodo();
        Task<VehiculosTransporte?> ObtenerPorId(int id);
        Task<bool> Insertar(VehiculosTransporte modelo);
        Task<bool> Actualizar(int id, VehiculosTransporte modelo);
        Task<bool> Eliminar(int id);
    }
}
