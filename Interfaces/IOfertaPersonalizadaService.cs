using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IOfertaPersonalizadaService
    {
        Task<List<OfertasPersonalizadas>> ListarTodo();
        Task<OfertasPersonalizadas?> ObtenerPorId(int id);
        Task<bool> Insertar(OfertasPersonalizadas modelo);
        Task<bool> Actualizar(int id, OfertasPersonalizadas modelo);
        Task<bool> Eliminar(int id);
    }
}
