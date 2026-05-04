using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IProgramaLealtadService
    {
        Task<List<ProgramaLealtadModel>> ListarTodo();
        Task<ProgramaLealtadModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(ProgramaLealtadModel m);
        Task<bool> Actualizar(int id, ProgramaLealtadModel m);
        Task<bool> Eliminar(int id);
    }
}