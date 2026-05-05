using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAlianzaAerolineaService
    {
        Task<List<AlianzaAerolineaModel>> ListarTodo();
        Task<AlianzaAerolineaModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(AlianzaAerolineaModel m);
        Task<bool> Actualizar(int id, AlianzaAerolineaModel m);
        Task<bool> Eliminar(int id);
    }
}