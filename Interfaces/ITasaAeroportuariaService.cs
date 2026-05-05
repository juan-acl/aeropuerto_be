using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITasaAeroportuariaService
    {
        Task<List<TasaAeroportuaria>> ListarTodo();
        Task<TasaAeroportuaria ?> ObtenerPorId(int id);
        Task<bool> Insertar(TasaAeroportuaria m);
        Task<bool> Actualizar(int id, TasaAeroportuaria m);
        Task<bool> Eliminar(int id);
    }
}