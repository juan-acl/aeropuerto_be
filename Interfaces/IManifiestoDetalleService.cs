using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IManifiestoDetalleService
    {
        Task<List<ManifiestoDetalle>> ListarTodo();
        Task<ManifiestoDetalle ?> ObtenerPorId(int id);
        Task<bool> Insertar(ManifiestoDetalle m);
        Task<bool> Actualizar(int id, ManifiestoDetalle m);
        Task<bool> Eliminar(int id);
    }
}