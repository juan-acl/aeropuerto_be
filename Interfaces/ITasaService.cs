using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITasaService
    {
        Task<List<TasaAeroportuaria>> ListarTodo();
        Task<bool> Insertar(TasaAeroportuaria modelo);
    }
}