using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasajeroMenorService
    {
        Task<List<PasajeroMenor>> ListarTodo();
        Task<bool> Insertar(PasajeroMenor modelo);
    }
}