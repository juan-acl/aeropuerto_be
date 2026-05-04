using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IClausulasContratoService
    {
        Task<List<ClausulasContrato>> ListarTodo();
        Task<ClausulasContrato ?> ObtenerPorId(int id);
        Task<bool> Insertar(ClausulasContrato m);
        Task<bool> Actualizar(int id, ClausulasContrato m);
        Task<bool> Eliminar(int id);
    }
}