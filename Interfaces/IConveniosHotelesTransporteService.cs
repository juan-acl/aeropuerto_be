using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IConveniosHotelesTransporteService
    {
        Task<List<ConveniosHotelesTransporte>> ListarTodo();
        Task<ConveniosHotelesTransporte ?> ObtenerPorId(int id);
        Task<bool> Insertar(ConveniosHotelesTransporte m);
        Task<bool> Actualizar(int id, ConveniosHotelesTransporte m);
        Task<bool> Eliminar(int id);
    }
}