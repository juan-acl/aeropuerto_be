using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface IBitacoraCambiosDbService
    {
        Task<List<BitacoraCambiosDb>> ListarTodo();
        Task<BitacoraCambiosDb?> ObtenerPorId(int id);
        Task<bool> Insertar(BitacoraCambiosDb modelo);
        Task<bool> Actualizar(int id, BitacoraCambiosDb modelo);
        Task<bool> Eliminar(int id);
    }
}
