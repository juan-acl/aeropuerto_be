using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IChoferesTransporteService
    {
        Task<List<ChoferesTransporte>> ListarTodo();
        Task<ChoferesTransporte ?> ObtenerPorId(int id);
        Task<bool> Insertar(ChoferesTransporte m);
        Task<bool> Actualizar(int id, ChoferesTransporte m);
        Task<bool> Eliminar(int id);
    }
}