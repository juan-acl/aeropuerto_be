using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAutorizacionMenorService
    {
        Task<List<AutorizacionMenor>> ListarTodo();
        Task<bool> Insertar(AutorizacionMenor modelo);
        Task<AutorizacionMenor?> ObtenerPorId(int id);
        Task<bool> Actualizar(AutorizacionMenor modelo);
        Task<bool> Eliminar(int id);
    }
}