using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IProgramaVueloService
    {
        Task<List<ProgramaVueloModel>> ListarTodo();
        Task<ProgramaVueloModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(ProgramaVueloModel m);
        Task<bool> Actualizar(int id, ProgramaVueloModel m);
        Task<bool> Eliminar(int id);
    }
}