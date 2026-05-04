using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("ATENCION_ESPECIAL")]
    public class AtencionEspecialModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_ATENCION")]
        public int IdAtencion { get; set; }

        [Column("ID_PASAJERO")]
        public int? IdPasajero { get; set; }

        [Column("ID_RESERVA")]
        public int? IdReserva { get; set; }

        [Column("TIPO_ATENCION")]
        public string TipoAtencion { get; set; } = null!; // SILLA_RUEDAS, ASISTENCIA_VISUAL, ASISTENCIA_AUDITIVA

        [Column("FECHA_SOLICITUD")]
        public DateTime? FechaSolicitud { get; set; }

        [Column("FECHA_ATENCION")]
        public DateTime? FechaAtencion { get; set; }

        [Column("ASISTENTE_ASIGNADO")]
        public string? AsistenteAsignado { get; set; }

        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}
