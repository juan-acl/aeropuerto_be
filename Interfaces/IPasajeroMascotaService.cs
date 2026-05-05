using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasajeroMascotaService
    {
        Task<List<PasajeroMascota>> ListarTodo();
        Task<PasajeroMascota ?> ObtenerPorId(int id);
        Task<bool> Insertar(PasajeroMascota m);
        Task<bool> Actualizar(int id, PasajeroMascota m);
        Task<bool> Eliminar(int id);
    }
}