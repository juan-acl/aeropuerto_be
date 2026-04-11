using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAduanaCargaService
    {
        Task<List<AduanaCarga>> ListarTodo();
        Task<bool> Insertar(AduanaCarga modelo);
    }
}