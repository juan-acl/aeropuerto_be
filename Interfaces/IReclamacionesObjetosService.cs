using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IReclamacionesObjetosService
    {
        Task<List<ReclamacionesObjetosModel>> ListarTodo();
        Task<ReclamacionesObjetosModel?> ObtenerPorId(int id);
        Task<bool> Insertar(ReclamacionesObjetosModel modelo);
        Task<bool> Actualizar(int id, ReclamacionesObjetosModel modelo);
        Task<bool> Eliminar(int id);
    }
}
