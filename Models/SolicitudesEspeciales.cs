using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("SOLICITUDES_ESPECIALES")]
    public class SolicitudesEspecialesModel
    {
        [Key]
        [Column("ID_SOLICITUD")]
        public int IdSolicitud { get; set; }

        [Column("ID_RESERVA")]
        public int IdReserva { get; set; }

        [Column("TIPO_SOLICITUD")]
        public string TipoSolicitud { get; set; } = null!; // COMIDA_ESPECIAL, ASISTENCIA, etc.

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("FECHA_SOLICITUD")]
        public DateTime? FechaSolicitud { get; set; }

        [Column("ESTADO_SOLICITUD")]
        public string EstadoSolicitud { get; set; } = "PENDIENTE";

        [Column("FECHA_RESOLUCION")]
        public DateTime? FechaResolucion { get; set; }

        [Column("RESOLUCION")]
        public string? Resolucion { get; set; }
    }
}