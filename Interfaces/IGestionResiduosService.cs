using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IGestionResiduosService
    {
        Task<List<GestionResiduos>> ListarTodo();
        Task<GestionResiduos?> ObtenerPorId(int id);
        Task<bool> Insertar(GestionResiduos modelo);
        Task<bool> Actualizar(int id, GestionResiduos modelo);
        Task<bool> Eliminar(int id);
    }
}
