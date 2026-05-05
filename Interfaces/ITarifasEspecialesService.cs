using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITarifasEspecialesService
    {
        Task<List<TarifasEspecialesModel>> ListarTodo();
        Task<TarifasEspecialesModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(TarifasEspecialesModel m);
        Task<bool> Actualizar(int id, TarifasEspecialesModel m);
        Task<bool> Eliminar(int id);
    }
}