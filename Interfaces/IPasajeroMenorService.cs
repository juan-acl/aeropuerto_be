using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasajeroMenorService
    {
        Task<List<PasajeroMenor>> ListarTodo();
        Task<bool> Insertar(PasajeroMenor modelo);
        Task<PasajeroMenor?> ObtenerPorId(int id);
        Task<bool> Actualizar(PasajeroMenor modelo);
        Task<bool> Eliminar(int id);
    }
}