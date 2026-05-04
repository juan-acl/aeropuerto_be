using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICuentaBancariaService
    {
        Task<List<CuentaBancaria>> ListarTodo();
        Task<CuentaBancaria ?> ObtenerPorId(int id);
        Task<bool> Insertar(CuentaBancaria m);
        Task<bool> Actualizar(int id, CuentaBancaria m);
        Task<bool> Eliminar(int id);
    }
}