using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICondicionesPistaTiempoRealService
    {
        Task<List<CondicionesPistaTiempoReal>> ListarTodo();
        Task<CondicionesPistaTiempoReal ?> ObtenerPorId(int id);
        Task<bool> Insertar(CondicionesPistaTiempoReal m);
        Task<bool> Actualizar(int id, CondicionesPistaTiempoReal m);
        Task<bool> Eliminar(int id);
    }
}