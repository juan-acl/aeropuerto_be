using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITiendasProductosService
    {
        Task<List<TiendasProductosModel>> ListarTodo();
        Task<TiendasProductosModel?> ObtenerPorId(int id);
        Task<bool> Insertar(TiendasProductosModel modelo);
        Task<bool> Actualizar(int id, TiendasProductosModel modelo);
        Task<bool> Eliminar(int id);
    }
}
