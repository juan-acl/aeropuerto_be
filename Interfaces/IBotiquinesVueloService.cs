using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IBotiquinesVueloService
    {
        Task<List<BotiquinesVueloModel>> ListarTodo();
        Task<BotiquinesVueloModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(BotiquinesVueloModel m);
        Task<bool> Actualizar(int id, BotiquinesVueloModel m);
        Task<bool> Eliminar(int id);
    }
}