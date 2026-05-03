using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IManifiestoDetalleService
    {
        Task<List<ManifiestoDetalle>> ListarTodo();
        Task<bool> Insertar(ManifiestoDetalle modelo);
        Task<ManifiestoDetalle?> ObtenerPorId(int id);
        Task<bool> Actualizar(ManifiestoDetalle modelo);
        Task<bool> Eliminar(int id);
    }
}