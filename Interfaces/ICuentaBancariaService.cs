using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICuentaBancariaService
    {
        Task<List<CuentaBancaria>> ListarTodo();
        Task<bool> Insertar(CuentaBancaria modelo);
    }
}