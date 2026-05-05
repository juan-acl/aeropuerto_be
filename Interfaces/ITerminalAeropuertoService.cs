using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITerminalAeropuertoService
    {
        Task<List<TerminalAeropuertoModel>> ListarTodo();
        Task<TerminalAeropuertoModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(TerminalAeropuertoModel m);
        Task<bool> Actualizar(int id, TerminalAeropuertoModel m);
        Task<bool> Eliminar(int id);
    }
}