using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IMantenimientoAvionService
    {
        Task<IEnumerable<MantenimientoAvionModel>> GetMantenimientosAsync();
        Task<MantenimientoAvionModel> GetMantenimientoByIdAsync(int id);
        Task<MantenimientoAvionModel> AddMantenimientoAsync(MantenimientoAvionModel mantenimiento);
    }
}
