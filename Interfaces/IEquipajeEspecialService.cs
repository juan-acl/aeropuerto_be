using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEquipajeEspecialService
    {
        Task<List<EquipajeEspecialModel>> ListarTodo();
        Task<EquipajeEspecialModel?> ObtenerPorId(int id);
        Task<bool> Insertar(EquipajeEspecialModel modelo);
        Task<bool> Actualizar(int id, EquipajeEspecialModel modelo);
        Task<bool> Eliminar(int id);
    }
}
