using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEscalasTecnicasService
    {
        Task<List<EscalasTecnicasModel>> ListarPorVuelo(int idVuelo);
        Task<EscalasTecnicasModel?> ObtenerPorId(int idEscala);
        Task<bool> Insertar(EscalasTecnicasModel m);
        Task<bool> Actualizar(EscalasTecnicasModel m);
        Task<bool> Eliminar(int idEscala);
    }
}
