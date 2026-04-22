using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICampanaMarketingService
    {
        Task<List<CampanasMarketing>> ListarTodo();
        Task<CampanasMarketing?> ObtenerPorId(int id);
        Task<bool> Insertar(CampanasMarketing modelo);
        Task<bool> Actualizar(int id, CampanasMarketing modelo);
        Task<bool> Eliminar(int id);
    }
}
