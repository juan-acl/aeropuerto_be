using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface IAnalisisComportamientoService
    {
        Task<List<AnalisisComportamiento>> ListarTodo();
        Task<AnalisisComportamiento?> ObtenerPorId(int id);
        Task<bool> Insertar(AnalisisComportamiento modelo);
        Task<bool> Actualizar(int id, AnalisisComportamiento modelo);
        Task<bool> Eliminar(int id);
    }
}
