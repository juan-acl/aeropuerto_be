using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAccesosAreasRestringidasService
    {
        Task<List<AccesosAreasRestringidasModel>> ListarTodo();
        Task<AccesosAreasRestringidasModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(AccesosAreasRestringidasModel m);
        Task<bool> Actualizar(int id, AccesosAreasRestringidasModel m);
        Task<bool> Eliminar(int id);
    }
}