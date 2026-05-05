using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAutorizacionMenorService
    {
        Task<List<AutorizacionMenor>> ListarTodo();
        Task<AutorizacionMenor ?> ObtenerPorId(int id);
        Task<bool> Insertar(AutorizacionMenor m);
        Task<bool> Actualizar(int id, AutorizacionMenor m);
        Task<bool> Eliminar(int id);
    }
}