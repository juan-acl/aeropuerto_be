using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IHotelesCercanosService
    {
        Task<bool> RegistrarHotel(HotelesCercanosModel modelo);
        Task<List<HotelesCercanosModel>> ListarTodo(); // Nuevo método para listar todos
        Task<List<HotelesCercanosModel>> ListarPorAeropuerto(string codigoAeropuerto);
        Task<List<HotelesCercanosModel>> ListarActivos(string codigoAeropuerto, bool? conShuttle = null);
        Task<bool> DesactivarHotel(int id);
        Task<bool> EliminarFisico(int id);
    }
}