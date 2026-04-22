using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IClausulaContratoService
    {
        Task<List<Contratos>> ListarTodo();
        Task<Contratos?> ObtenerPorId(int id);
        Task<bool> Insertar(Contratos modelo);
        Task<bool> Actualizar(int id, Contratos modelo);
        Task<bool> Eliminar(int id);
    }
}
