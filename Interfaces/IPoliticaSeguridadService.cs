using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPoliticaSeguridadService
    {
        Task<List<PoliticasSeguridad>> ListarTodo();
        Task<PoliticasSeguridad?> ObtenerPorId(int id);
        Task<bool> Insertar(PoliticasSeguridad modelo);
        Task<bool> Actualizar(int id, PoliticasSeguridad modelo);
        Task<bool> Eliminar(int id);
    }
}
