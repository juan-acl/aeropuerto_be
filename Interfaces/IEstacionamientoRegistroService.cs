using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEstacionamientoRegistroService
    {
        Task<List<EstacionamientoRegistroModel>> ListarTodo();
        Task<EstacionamientoRegistroModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(EstacionamientoRegistroModel m);
        Task<bool> Actualizar(int id, EstacionamientoRegistroModel m);
        Task<bool> Eliminar(int id);
    }
}