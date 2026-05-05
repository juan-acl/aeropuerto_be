using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPublicidadService
    {
        Task<List<PublicidadModel>> ListarTodo();
        Task<PublicidadModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(PublicidadModel m);
        Task<bool> Actualizar(int id, PublicidadModel m);
        Task<bool> Eliminar(int id);
    }
}