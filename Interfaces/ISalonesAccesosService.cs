using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISalonesAccesosService
    {
        Task<List<SalonesAccesosModel>> ListarTodo();
        Task<SalonesAccesosModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(SalonesAccesosModel m);
        Task<bool> Actualizar(int id, SalonesAccesosModel m);
        Task<bool> Eliminar(int id);
    }
}