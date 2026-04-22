using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAtencionEspecialService
    {
        Task<List<AtencionEspecialModel>> ListarTodo();
        Task<AtencionEspecialModel?> ObtenerPorId(int id);
        Task<bool> Insertar(AtencionEspecialModel modelo);
        Task<bool> Actualizar(int id, AtencionEspecialModel modelo);
        Task<bool> Eliminar(int id);
    }
}
