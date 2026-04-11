using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IMenorNoAcompanadoService
    {
        Task<List<MenorNoAcompanado>> ListarTodo();
        Task<bool> Insertar(MenorNoAcompanado modelo);
    }
}