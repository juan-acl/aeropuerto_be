using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAcompanantesViajeService
    {
        Task<List<AcompanantesViajeModel>> ListarTodo();
        Task<AcompanantesViajeModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(AcompanantesViajeModel m);
        Task<bool> Actualizar(int id, AcompanantesViajeModel m);
        Task<bool> Eliminar(int id);
    }
}