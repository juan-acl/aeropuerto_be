using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IGestionResiduosService
    {
        Task<List<GestionResiduos>> ListarTodo();
        Task<GestionResiduos ?> ObtenerPorId(int id);
        Task<bool> Insertar(GestionResiduos m);
        Task<bool> Actualizar(int id, GestionResiduos m);
        Task<bool> Eliminar(int id);
    }
}