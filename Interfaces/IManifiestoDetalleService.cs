using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IManifiestoDetalleService
    {
        Task<List<ManifiestoDetalle>> ListarTodo();
        Task<bool> Insertar(ManifiestoDetalle modelo);
    }
}