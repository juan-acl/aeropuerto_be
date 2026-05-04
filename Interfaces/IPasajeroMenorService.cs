using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasajeroMenorService
    {
        Task<List<PasajeroMenor>> ListarTodo();
        Task<PasajeroMenor ?> ObtenerPorId(int id);
        Task<bool> Insertar(PasajeroMenor m);
        Task<bool> Actualizar(int id, PasajeroMenor m);
        Task<bool> Eliminar(int id);
    }
}