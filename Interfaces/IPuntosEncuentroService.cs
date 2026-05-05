using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPuntosEncuentroService
    {
        Task<List<PuntosEncuentro>> ListarTodo();
        Task<PuntosEncuentro ?> ObtenerPorId(int id);
        Task<bool> Insertar(PuntosEncuentro m);
        Task<bool> Actualizar(int id, PuntosEncuentro m);
        Task<bool> Eliminar(int id);
    }
}