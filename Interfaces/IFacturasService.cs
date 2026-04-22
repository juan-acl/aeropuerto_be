using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IFacturasService
    {
        Task<List<FacturasModel>> ListarTodo();
        Task<FacturasModel?> ObtenerPorId(int id);
        Task<bool> Insertar(FacturasModel modelo);
        Task<bool> Actualizar(int id, FacturasModel modelo);
        Task<bool> Eliminar(int id);
    }
}
