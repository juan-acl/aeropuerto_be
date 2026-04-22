using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPuntoEncuentroService
    {
        Task<List<PuntosEncuentro>> ListarTodo();
        Task<PuntosEncuentro?> ObtenerPorId(int id);
        Task<bool> Insertar(PuntosEncuentro modelo);
        Task<bool> Actualizar(int id, PuntosEncuentro modelo);
        Task<bool> Eliminar(int id);
    }
}
