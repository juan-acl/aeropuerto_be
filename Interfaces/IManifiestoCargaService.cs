using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IManifiestoCargaService
    {
        Task<List<ManifiestoCarga>> ListarTodo();
        Task<ManifiestoCarga ?> ObtenerPorId(int id);
        Task<bool> Insertar(ManifiestoCarga m);
        Task<bool> Actualizar(int id, ManifiestoCarga m);
        Task<bool> Eliminar(int id);
    }
}