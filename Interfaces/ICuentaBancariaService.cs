using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICuentaBancariaService
    {
        Task<List<CuentaBancaria>> ListarTodo();
        Task<bool> Insertar(CuentaBancaria modelo);
        Task<CuentaBancaria?> ObtenerPorId(int id);
        Task<bool> Actualizar(CuentaBancaria modelo);
        Task<bool> Eliminar(int id);
    }
}