using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITarifasEspecialesService
    {
        Task<bool> Insertar(TarifasEspecialesModel modelo);
        Task<List<TarifasEspecialesModel>> ListarPorAerolinea(int idAerolinea);
        Task<List<TarifasEspecialesModel>> ListarActivas();
        Task<bool> Actualizar(int id, TarifasEspecialesModel modelo);
        Task<bool> EliminarFisico(int id);
    }
}