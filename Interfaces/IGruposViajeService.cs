using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IGruposViajeService
    {
        Task<List<GruposViajeModel>> ListarTodo();
        Task<GruposViajeModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(GruposViajeModel m);
        Task<bool> Actualizar(int id, GruposViajeModel m);
        Task<bool> Eliminar(int id);
    }
}