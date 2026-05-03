using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IUniformeService
    {
        Task<List<UniformeEquipamiento>> ListarTodo();
        Task<bool> Insertar(UniformeEquipamiento modelo);
        Task<UniformeEquipamiento?> ObtenerPorId(int id);
        Task<bool> Actualizar(UniformeEquipamiento modelo);
        Task<bool> Eliminar(int id);
    }
}