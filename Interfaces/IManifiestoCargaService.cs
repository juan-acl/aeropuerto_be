using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IManifiestoCargaService
    {
        Task<List<ManifiestoCarga>> ListarTodo();
        Task<bool> Insertar(ManifiestoCarga modelo);
        Task<ManifiestoCarga?> ObtenerPorId(int id);
        Task<bool> Actualizar(ManifiestoCarga modelo);
        Task<bool> Eliminar(int id);
    }
}