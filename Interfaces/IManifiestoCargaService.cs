using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IManifiestoCargaService
    {
        Task<List<ManifiestoCarga>> ListarTodo();
        Task<bool> Insertar(ManifiestoCarga modelo);
    }
}