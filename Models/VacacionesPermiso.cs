using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class VacacionesPermiso
    {
        [Key]
        public int IdSolicitud { get; set; }
        public int IdEmpleado { get; set; }
        public string TipoSolicitud { get; set; } = null!; // VACACIONES, PERMISO, etc.
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int DiasSolicitados { get; set; }
        public string Motivo { get; set; } = null!;
        public DateTime FechaSolicitud { get; set; }
        public string Estado { get; set; } = "PENDIENTE";
        public int? AutorizadoPor { get; set; }
        public DateTime? FechaAutorizacion { get; set; }
        public string? Observaciones { get; set; }
    }
}