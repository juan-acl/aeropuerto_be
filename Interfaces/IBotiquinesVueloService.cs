using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IBotiquinesVueloService
    {
        Task<bool> RegistrarVerificacion(BotiquinesVueloModel modelo);
        Task<List<BotiquinesVueloModel>> ListarPorVuelo(int idVuelo);
        Task<BotiquinesVueloModel?> ObtenerUltimaVerificacion(int idVuelo);
        Task<bool> Actualizar(int id, BotiquinesVueloModel modelo);
        Task<bool> EliminarFisico(int id);
    }
}