using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPoliticasSeguridadService
    {
        Task<List<PoliticasSeguridad>> ListarTodo();
        Task<PoliticasSeguridad ?> ObtenerPorId(int id);
        Task<bool> Insertar(PoliticasSeguridad m);
        Task<bool> Actualizar(int id, PoliticasSeguridad m);
        Task<bool> Eliminar(int id);
    }
}