using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasajeroMascotaService
    {
        Task<List<PasajeroMascota>> ListarTodo();
        Task<bool> Insertar(PasajeroMascota modelo);
    }
}