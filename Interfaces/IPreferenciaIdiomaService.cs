using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPreferenciaIdiomaService
    {
        Task<List<PreferenciaIdiomaModel>> ListarTodo();
        Task<PreferenciaIdiomaModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(PreferenciaIdiomaModel m);
        Task<bool> Actualizar(int id, PreferenciaIdiomaModel m);
        Task<bool> Eliminar(int id);
    }
}