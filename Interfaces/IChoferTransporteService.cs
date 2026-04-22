using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IChoferTransporteService
    {
        Task<List<ChoferesTransporte>> ListarTodo();
        Task<ChoferesTransporte?> ObtenerPorId(int id);
        Task<bool> Insertar(ChoferesTransporte modelo);
        Task<bool> Actualizar(int id, ChoferesTransporte modelo);
        Task<bool> Eliminar(int id);
    }
}
