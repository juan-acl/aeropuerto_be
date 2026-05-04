using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IFacturasService
    {
        Task<List<FacturasModel>> ListarTodo();
        Task<FacturasModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(FacturasModel m);
        Task<bool> Actualizar(int id, FacturasModel m);
        Task<bool> Eliminar(int id);
    }
}