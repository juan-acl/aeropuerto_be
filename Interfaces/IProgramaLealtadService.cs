using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IProgramaLealtadService
    {
        Task<List<ProgramaLealtadModel>> ListarTodo();
        Task<ProgramaLealtadModel?> ObtenerPorId(int id);
        Task<bool> Insertar(ProgramaLealtadModel modelo);
        Task<bool> Actualizar(int id, ProgramaLealtadModel modelo);
        Task<bool> Eliminar(int id);
    }
}
