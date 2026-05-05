using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IOfertasPersonalizadasService
    {
        Task<List<OfertasPersonalizadas>> ListarTodo();
        Task<OfertasPersonalizadas ?> ObtenerPorId(int id);
        Task<bool> Insertar(OfertasPersonalizadas m);
        Task<bool> Actualizar(int id, OfertasPersonalizadas m);
        Task<bool> Eliminar(int id);
    }
}