using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISeguimientoCargaService
    {
        Task<List<SeguimientoCarga>> ListarTodo();
        Task<bool> Insertar(SeguimientoCarga modelo);
    }
}