using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAtencionEspecialService
    {
        Task<List<AtencionEspecialModel>> ListarTodo();
        Task<AtencionEspecialModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(AtencionEspecialModel m);
        Task<bool> Actualizar(int id, AtencionEspecialModel m);
        Task<bool> Eliminar(int id);
    }
}