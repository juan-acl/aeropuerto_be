using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IFacturacionCombustibleService
    {
        Task<List<FacturacionCombustible>> ListarTodo();
        Task<FacturacionCombustible?> ObtenerPorId(int id);
        Task<bool> Insertar(FacturacionCombustible modelo);
        Task<bool> Actualizar(int id, FacturacionCombustible modelo);
        Task<bool> Eliminar(int id);
    }
}
