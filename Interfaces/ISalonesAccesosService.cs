using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISalonesAccesosService
    {
        Task<List<SalonesAccesosModel>> ListarTodo();
        Task<SalonesAccesosModel?> ObtenerPorId(int id);
        Task<bool> Insertar(SalonesAccesosModel modelo);
        Task<bool> Actualizar(int id, SalonesAccesosModel modelo);
        Task<bool> Eliminar(int id);
    }
}
