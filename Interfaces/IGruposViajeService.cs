using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IGruposViajeService
    {
        Task<List<GruposViajeModel>> ListarTodo();
        Task<GruposViajeModel?> ObtenerPorId(int id);
        Task<bool> Insertar(GruposViajeModel modelo);
        Task<bool> Actualizar(int id, GruposViajeModel modelo);
        Task<bool> Eliminar(int id);
    }
}
