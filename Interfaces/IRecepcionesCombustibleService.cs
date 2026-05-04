using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRecepcionesCombustibleService
    {
        Task<List<RecepcionesCombustible>> ListarTodo();
        Task<RecepcionesCombustible ?> ObtenerPorId(int id);
        Task<bool> Insertar(RecepcionesCombustible m);
        Task<bool> Actualizar(int id, RecepcionesCombustible m);
        Task<bool> Eliminar(int id);
    }
}