using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IMenorNoAcompanadoService
    {
        Task<List<MenorNoAcompanado>> ListarTodo();
        Task<bool> Insertar(MenorNoAcompanado modelo);
        Task<MenorNoAcompanado?> ObtenerPorId(int id);
        Task<bool> Actualizar(MenorNoAcompanado modelo);
        Task<bool> Eliminar(int id);
    }
}