using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IUniformeService
    {
        Task<List<UniformeEquipamiento>> ListarTodo();
        Task<bool> Insertar(UniformeEquipamiento modelo);
    }
}