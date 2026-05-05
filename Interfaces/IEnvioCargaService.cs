using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEnvioCargaService
    {
        Task<List<EnvioCarga>> ListarTodo();
        Task<EnvioCarga ?> ObtenerPorId(int id);
        Task<bool> Insertar(EnvioCarga m);
        Task<bool> Actualizar(int id, EnvioCarga m);
        Task<bool> Eliminar(int id);
    }
}