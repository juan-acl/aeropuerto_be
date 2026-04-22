using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRecepcionCombustibleService
    {
        Task<List<RecepcionesCombustible>> ListarTodo();
        Task<RecepcionesCombustible?> ObtenerPorId(int id);
        Task<bool> Insertar(RecepcionesCombustible modelo);
        Task<bool> Actualizar(int id, RecepcionesCombustible modelo);
        Task<bool> Eliminar(int id);
    }
}
