using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IFabricanteAvionService
    {
        Task<List<FabricanteAvionModel>> ListarTodo();
        Task<FabricanteAvionModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(FabricanteAvionModel m);
        Task<bool> Actualizar(int id, FabricanteAvionModel m);
        Task<bool> Eliminar(int id);
    }
}