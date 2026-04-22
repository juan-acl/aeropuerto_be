using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface INormativaAplicableService
    {
        Task<List<NormativasAplicables>> ListarTodo();
        Task<NormativasAplicables?> ObtenerPorId(int id);
        Task<bool> Insertar(NormativasAplicables modelo);
        Task<bool> Actualizar(int id, NormativasAplicables modelo);
        Task<bool> Eliminar(int id);
    }
}
