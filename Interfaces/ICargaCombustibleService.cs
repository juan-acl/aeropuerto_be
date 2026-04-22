using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICargaCombustibleService
    {
        Task<List<CargasCombustible>> ListarTodo();
        Task<CargasCombustible?> ObtenerPorId(int id);
        Task<bool> Insertar(CargasCombustible modelo);
        Task<bool> Actualizar(int id, CargasCombustible modelo);
        Task<bool> Eliminar(int id);
    }
}
