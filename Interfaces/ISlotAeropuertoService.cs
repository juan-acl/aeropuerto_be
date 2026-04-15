using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISlotAeropuertoService
    {
        Task<List<SlotsAeropuerto>>  ListarTodo();
        Task<SlotsAeropuerto?>       ObtenerPorId(int id);
        Task<bool>                   Insertar(SlotsAeropuerto modelo);
        Task<bool>                   Actualizar(int id, SlotsAeropuerto modelo);
        Task<bool>                   Eliminar(int id);
    }
}
