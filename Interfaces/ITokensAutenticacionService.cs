using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITokensAutenticacionService
    {
        Task<List<TokensAutenticacion>> ListarTodo();
        Task<TokensAutenticacion ?> ObtenerPorId(int id);
        Task<bool> Insertar(TokensAutenticacion m);
        Task<bool> Actualizar(int id, TokensAutenticacion m);
        Task<bool> Eliminar(int id);
    }
}