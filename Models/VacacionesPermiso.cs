using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("VACACIONES_PERMISO")]
    public class VacacionesPermiso
    {
        [Key]
        [Column("ID_SOLICITUD")]
        public int IdSolicitud { get; set; }
        [Column("ID_EMPLEADO")]
        public int IdEmpleado { get; set; }
        [Column("TIPO_SOLICITUD")]
        public string TipoSolicitud { get; set; } = null!; // VACACIONES, PERMISO, etc.
        [Column("FECHA_INICIO")]
        public DateTime FechaInicio { get; set; }
        [Column("FECHA_FIN")]
        public DateTime FechaFin { get; set; }
        [Column("DIAS_SOLICITADOS")]
        public int DiasSolicitados { get; set; }
        [Column("MOTIVO")]
        public string Motivo { get; set; } = null!;
        [Column("FECHA_SOLICITUD")]
        public DateTime FechaSolicitud { get; set; }
        [Column("ESTADO")]
        public string Estado { get; set; } = "PENDIENTE";
        [Column("AUTORIZADO_POR")]
        public int? AutorizadoPor { get; set; }
        [Column("FECHA_AUTORIZACION")]
        public DateTime? FechaAutorizacion { get; set; }
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}