using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IDiaOperacionService
    {
        Task<List<DiaOperacionModel>> ListarTodo();
        Task<DiaOperacionModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(DiaOperacionModel m);
        Task<bool> Actualizar(int id, DiaOperacionModel m);
        Task<bool> Eliminar(int id);
    }
}