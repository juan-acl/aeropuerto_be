using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface IEstandarInternacionalService
    {
        Task<List<EstandaresInternacionales>> ListarTodo();
        Task<EstandaresInternacionales?> ObtenerPorId(int id);
        Task<bool> Insertar(EstandaresInternacionales modelo);
        Task<bool> Actualizar(int id, EstandaresInternacionales modelo);
        Task<bool> Eliminar(int id);
    }
}
