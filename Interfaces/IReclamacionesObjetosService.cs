using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IReclamacionesObjetosService
    {
        Task<List<ReclamacionesObjetosModel>> ListarTodo();
        Task<ReclamacionesObjetosModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(ReclamacionesObjetosModel m);
        Task<bool> Actualizar(int id, ReclamacionesObjetosModel m);
        Task<bool> Eliminar(int id);
    }
}