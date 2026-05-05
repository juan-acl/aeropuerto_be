using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class TokensAutenticacionService : ITokensAutenticacionService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public TokensAutenticacionService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<TokensAutenticacion>> ListarTodo()
        {
            try { return await _replica.Tokens.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo TokensAutenticacion: {ex.Message}"); return new List<TokensAutenticacion>(); }
        }

        public async Task<TokensAutenticacion ?> ObtenerPorId(int id)
        {
            try { return await _replica.Tokens.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId TokensAutenticacion: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(TokensAutenticacion m)
        {
            _primary.Tokens.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, TokensAutenticacion m)
        {
            _primary.Tokens.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.Tokens.FindAsync(id);
            if (e == null) return false;
            _primary.Tokens.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
