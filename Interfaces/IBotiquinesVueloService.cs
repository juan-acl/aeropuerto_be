using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IBotiquinesVueloService
    {
        Task<List<BotiquinesVueloModel>> ListarTodo();
        Task<BotiquinesVueloModel?> ObtenerPorId(int id);
        Task<bool> Insertar(BotiquinesVueloModel modelo);
        Task<bool> Actualizar(int id, BotiquinesVueloModel modelo);
        Task<bool> Eliminar(int id);
    }
}
