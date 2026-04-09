using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEquipajeEspecialService
    {
        Task<bool> Insertar(EquipajeEspecialModel modelo);
        Task<List<EquipajeEspecialModel>> ListarPorReserva(int idReserva);
        Task<bool> AutorizarEquipaje(int id, decimal costo);
        Task<bool> Actualizar(int id, EquipajeEspecialModel modelo);
        Task<bool> EliminarFisico(int id);
    }
}