using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IUniformeEquipamientoService
    {
        Task<List<UniformeEquipamiento>> ListarTodo();
        Task<UniformeEquipamiento ?> ObtenerPorId(int id);
        Task<bool> Insertar(UniformeEquipamiento m);
        Task<bool> Actualizar(int id, UniformeEquipamiento m);
        Task<bool> Eliminar(int id);
    }
}