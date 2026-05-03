using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IMovimientoBancarioService
    {
        Task<List<MovimientoBancario>> ListarTodo();
        Task<bool> Insertar(MovimientoBancario modelo);
        Task<MovimientoBancario?> ObtenerPorId(int id);
        Task<bool> Actualizar(MovimientoBancario modelo);
        Task<bool> Eliminar(int id);
    }
}