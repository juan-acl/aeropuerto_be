using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IBodegaCargaService
    {
        Task<List<BodegaCarga>> ListarTodo();
        Task<bool> Insertar(BodegaCarga modelo);
    }
}