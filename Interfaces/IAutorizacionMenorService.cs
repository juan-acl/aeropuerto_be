using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAutorizacionMenorService
    {
        Task<List<AutorizacionMenor>> ListarTodo();
        Task<bool> Insertar(AutorizacionMenor modelo);
    }
}