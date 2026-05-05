using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEstandaresInternacionalesService
    {
        Task<List<EstandaresInternacionales>> ListarTodo();
        Task<EstandaresInternacionales ?> ObtenerPorId(int id);
        Task<bool> Insertar(EstandaresInternacionales m);
        Task<bool> Actualizar(int id, EstandaresInternacionales m);
        Task<bool> Eliminar(int id);
    }
}