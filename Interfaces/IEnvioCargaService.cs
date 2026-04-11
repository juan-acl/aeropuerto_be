using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEnvioCargaService
    {
        Task<List<EnvioCarga>> ListarTodo();
        Task<bool> Insertar(EnvioCarga modelo);
    }
}