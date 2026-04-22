using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITiendasVentasService
    {
        Task<List<TiendasVentasModel>> ListarTodo();
        Task<TiendasVentasModel?> ObtenerPorId(int id);
        Task<bool> Insertar(TiendasVentasModel modelo);
        Task<bool> Actualizar(int id, TiendasVentasModel modelo);
        Task<bool> Eliminar(int id);
    }
}
