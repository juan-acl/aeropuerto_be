using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IProgramasCompensacionAmbientalService
    {
        Task<List<ProgramasCompensacionAmbiental>> ListarTodo();
        Task<ProgramasCompensacionAmbiental ?> ObtenerPorId(int id);
        Task<bool> Insertar(ProgramasCompensacionAmbiental m);
        Task<bool> Actualizar(int id, ProgramasCompensacionAmbiental m);
        Task<bool> Eliminar(int id);
    }
}