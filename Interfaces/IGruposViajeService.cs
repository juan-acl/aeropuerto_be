using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IGruposViajeService
    {
        Task<bool> Insertar(GruposViajeModel modelo);
        Task<List<GruposViajeModel>> ListarTodos();
        Task<GruposViajeModel?> ObtenerPorId(int id);
        Task<bool> Actualizar(int id, GruposViajeModel modelo);
        Task<bool> EliminarFisico(int id);
    }
}