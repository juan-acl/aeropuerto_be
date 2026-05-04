using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEquipajeEspecialService
    {
        Task<List<EquipajeEspecialModel>> ListarTodo();
        Task<EquipajeEspecialModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(EquipajeEspecialModel m);
        Task<bool> Actualizar(int id, EquipajeEspecialModel m);
        Task<bool> Eliminar(int id);
    }
}