using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICargasCombustibleService
    {
        Task<List<CargasCombustible>> ListarTodo();
        Task<CargasCombustible ?> ObtenerPorId(int id);
        Task<bool> Insertar(CargasCombustible m);
        Task<bool> Actualizar(int id, CargasCombustible m);
        Task<bool> Eliminar(int id);
    }
}