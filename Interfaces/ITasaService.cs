using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITasaService
    {
        Task<List<TasaAeroportuaria>> ListarTodo();
        Task<bool> Insertar(TasaAeroportuaria modelo);
        Task<TasaAeroportuaria?> ObtenerPorId(int id);
        Task<bool> Actualizar(TasaAeroportuaria modelo);
        Task<bool> Eliminar(int id);
    }
}