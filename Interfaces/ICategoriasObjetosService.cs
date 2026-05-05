using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICategoriasObjetosService
    {
        Task<List<CategoriasObjetosModel>> ListarTodo();
        Task<CategoriasObjetosModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(CategoriasObjetosModel m);
        Task<bool> Actualizar(int id, CategoriasObjetosModel m);
        Task<bool> Eliminar(int id);
    }
}