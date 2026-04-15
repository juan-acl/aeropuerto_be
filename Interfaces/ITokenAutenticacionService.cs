using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface ITokenAutenticacionService
    {
        Task<List<TokensAutenticacion>> ListarTodo();
        Task<TokensAutenticacion?> ObtenerPorId(int id);
        Task<bool> Insertar(TokensAutenticacion modelo);
        Task<bool> Actualizar(int id, TokensAutenticacion modelo);
        Task<bool> Eliminar(int id);
    }
}
