using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasajeroMascotaService
    {
        Task<List<PasajeroMascota>> ListarTodo();
        Task<bool> Insertar(PasajeroMascota modelo);
        Task<PasajeroMascota?> ObtenerPorId(int id);
        Task<bool> Actualizar(PasajeroMascota modelo);
        Task<bool> Eliminar(int id);
    }
}