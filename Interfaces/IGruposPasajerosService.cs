using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IGruposPasajerosService
    {
        Task<List<GruposPasajerosModel>> ListarTodo();
        Task<GruposPasajerosModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(GruposPasajerosModel m);
        Task<bool> Actualizar(int id, GruposPasajerosModel m);
        Task<bool> Eliminar(int id);
    }
}