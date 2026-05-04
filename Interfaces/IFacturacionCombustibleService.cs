using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IFacturacionCombustibleService
    {
        Task<List<FacturacionCombustible>> ListarTodo();
        Task<FacturacionCombustible ?> ObtenerPorId(int id);
        Task<bool> Insertar(FacturacionCombustible m);
        Task<bool> Actualizar(int id, FacturacionCombustible m);
        Task<bool> Eliminar(int id);
    }
}