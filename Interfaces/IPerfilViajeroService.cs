using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPerfilViajeroService
    {
        Task<List<PerfilViajeroModel>> ListarTodo();
        Task<PerfilViajeroModel?> ObtenerPorId(int id);
        Task<bool> Insertar(PerfilViajeroModel modelo);
        Task<bool> Actualizar(int id, PerfilViajeroModel modelo);
        Task<bool> Eliminar(int id);
    }
}
