using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAlertasSeguridadService
    {
        Task<bool> EmitirAlerta(AlertasSeguridadModel modelo);
        Task<List<AlertasSeguridadModel>> ListarHistorial(string codigoAeropuerto);
        Task<AlertasSeguridadModel?> ObtenerAlertaActiva(string codigoAeropuerto);
        Task<bool> DesactivarAlerta(int id);
        Task<bool> EliminarFisico(int id);
    }
}