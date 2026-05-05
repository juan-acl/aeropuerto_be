using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasesAbordajeService
    {
        Task<List<PasesAbordajeModel>> ListarTodo();
        Task<PasesAbordajeModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(PasesAbordajeModel m);
        Task<bool> Actualizar(int id, PasesAbordajeModel m);
        Task<bool> Eliminar(int id);
    }
}