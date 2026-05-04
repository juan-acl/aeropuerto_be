using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IVehiculosTransporteService
    {
        Task<List<VehiculosTransporte>> ListarTodo();
        Task<VehiculosTransporte ?> ObtenerPorId(int id);
        Task<bool> Insertar(VehiculosTransporte m);
        Task<bool> Actualizar(int id, VehiculosTransporte m);
        Task<bool> Eliminar(int id);
    }
}