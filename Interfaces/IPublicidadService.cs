using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPublicidadService
    {
        Task<List<PublicidadModel>> ListarTodo();
        Task<PublicidadModel?> ObtenerPorId(int id);
        Task<bool> Insertar(PublicidadModel modelo);
        Task<bool> Actualizar(int id, PublicidadModel modelo);
        Task<bool> Eliminar(int id);
    }
}
