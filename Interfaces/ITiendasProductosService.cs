using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITiendasProductosService
    {
        Task<List<TiendasProductosModel>> ListarTodo();
        Task<TiendasProductosModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(TiendasProductosModel m);
        Task<bool> Actualizar(int id, TiendasProductosModel m);
        Task<bool> Eliminar(int id);
    }
}