using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IConvenioHotelService
    {
        Task<List<ConveniosHotelesTransporte>> ListarTodo();
        Task<ConveniosHotelesTransporte?> ObtenerPorId(int id);
        Task<bool> Insertar(ConveniosHotelesTransporte modelo);
        Task<bool> Actualizar(int id, ConveniosHotelesTransporte modelo);
        Task<bool> Eliminar(int id);
    }
}
