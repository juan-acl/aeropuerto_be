using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITiendasVentasService
    {
        Task<List<TiendasVentasModel>> ListarTodo();
        Task<TiendasVentasModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(TiendasVentasModel m);
        Task<bool> Actualizar(int id, TiendasVentasModel m);
        Task<bool> Eliminar(int id);
    }
}