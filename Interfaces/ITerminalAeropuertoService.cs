using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface ITerminalAeropuertoService
    {
        Task<List<TerminalAeropuertoModel>> ListarTodo();
        Task<TerminalAeropuertoModel?> ObtenerPorId(int id);
        Task<bool> Insertar(TerminalAeropuertoModel modelo);
        Task<bool> Actualizar(int id, TerminalAeropuertoModel modelo);
        Task<bool> Eliminar(int id);
    }
}
