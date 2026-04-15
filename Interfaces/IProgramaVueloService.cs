using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IProgramaVueloService
    {
        Task<List<ProgramaVueloModel>> ListarTodo();
        Task<ProgramaVueloModel?> ObtenerPorId(int id);
        Task<List<ProgramaVueloModel>> BuscarPorRuta(string origen, string destino);
        Task<List<ProgramaVueloModel>> ListarPorAerolinea(int idAerolinea);
        Task<bool> Insertar(ProgramaVueloModel modelo);
        Task<bool> Actualizar(int id, ProgramaVueloModel modelo);
        Task<bool> Eliminar(int id);
    }
}
