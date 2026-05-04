using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IMenorNoAcompanadoService
    {
        Task<List<MenorNoAcompanado>> ListarTodo();
        Task<MenorNoAcompanado ?> ObtenerPorId(int id);
        Task<bool> Insertar(MenorNoAcompanado m);
        Task<bool> Actualizar(int id, MenorNoAcompanado m);
        Task<bool> Eliminar(int id);
    }
}