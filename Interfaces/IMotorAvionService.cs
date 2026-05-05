using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IMotorAvionService
    {
        Task<List<MotorAvionModel>> ListarTodo();
        Task<MotorAvionModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(MotorAvionModel m);
        Task<bool> Actualizar(int id, MotorAvionModel m);
        Task<bool> Eliminar(int id);
    }
}