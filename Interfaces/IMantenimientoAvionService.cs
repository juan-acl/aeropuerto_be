using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IMantenimientoAvionService
    {
        Task<List<MantenimientoAvionModel>> ListarTodo();
        Task<MantenimientoAvionModel?> ObtenerPorId(int id);
        Task<bool> Insertar(MantenimientoAvionModel modelo);
        Task<bool> Actualizar(int id, MantenimientoAvionModel modelo);
        Task<bool> Eliminar(int id);
    }
}
