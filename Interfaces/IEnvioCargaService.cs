using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEnvioCargaService
    {
        Task<List<EnvioCarga>> ListarTodo();
        Task<bool> Insertar(EnvioCarga modelo);
        Task<EnvioCarga?> ObtenerPorId(int id);
        Task<bool> Actualizar(EnvioCarga modelo);
        Task<bool> Eliminar(int id);
    }
}