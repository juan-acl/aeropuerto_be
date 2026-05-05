using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface INormativasAplicablesService
    {
        Task<List<NormativasAplicables>> ListarTodo();
        Task<NormativasAplicables ?> ObtenerPorId(int id);
        Task<bool> Insertar(NormativasAplicables m);
        Task<bool> Actualizar(int id, NormativasAplicables m);
        Task<bool> Eliminar(int id);
    }
}