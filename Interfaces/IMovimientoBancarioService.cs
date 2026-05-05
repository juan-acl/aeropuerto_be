using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IMovimientoBancarioService
    {
        Task<List<MovimientoBancario>> ListarTodo();
        Task<MovimientoBancario ?> ObtenerPorId(int id);
        Task<bool> Insertar(MovimientoBancario m);
        Task<bool> Actualizar(int id, MovimientoBancario m);
        Task<bool> Eliminar(int id);
    }
}