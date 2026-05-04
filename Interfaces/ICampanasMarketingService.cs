using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICampanasMarketingService
    {
        Task<List<CampanasMarketing>> ListarTodo();
        Task<CampanasMarketing ?> ObtenerPorId(int id);
        Task<bool> Insertar(CampanasMarketing m);
        Task<bool> Actualizar(int id, CampanasMarketing m);
        Task<bool> Eliminar(int id);
    }
}