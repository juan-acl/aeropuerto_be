using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IConcesionesComercialesService
    {
        Task<bool> RegistrarConcesion(ConcesionesComercialesModel modelo);
        Task<List<ConcesionesComercialesModel>> ListarPorAeropuerto(string codigoAeropuerto);
        Task<List<ConcesionesComercialesModel>> ListarActivas(string codigoAeropuerto);
        Task<bool> RenovarContrato(int idConcesion, DateTime nuevaFechaFin, decimal nuevoCanon);
        Task<bool> DesactivarConcesion(int id);
        Task<bool> EliminarFisico(int id);
    }
}