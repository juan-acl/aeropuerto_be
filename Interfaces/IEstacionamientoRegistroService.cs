using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEstacionamientoRegistroService
    {
        Task<List<EstacionamientoRegistroModel>> ListarTodo();
        Task<EstacionamientoRegistroModel?> ObtenerPorId(int id);
        Task<bool> Insertar(EstacionamientoRegistroModel modelo);
        Task<bool> Actualizar(int id, EstacionamientoRegistroModel modelo);
        Task<bool> Eliminar(int id);
    }
}
