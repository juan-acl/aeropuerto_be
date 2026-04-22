using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IProgramaCompensacionService
    {
        Task<List<ProgramasCompensacionAmbiental>> ListarTodo();
        Task<ProgramasCompensacionAmbiental?> ObtenerPorId(int id);
        Task<bool> Insertar(ProgramasCompensacionAmbiental modelo);
        Task<bool> Actualizar(int id, ProgramasCompensacionAmbiental modelo);
        Task<bool> Eliminar(int id);
    }
}
