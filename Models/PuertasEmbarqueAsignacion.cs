using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("PUERTAS_EMBARQUE_ASIGNACION")]
    public class PuertasEmbarqueAsignacionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_ASIGNACION_PUERTA")]
        public int IdAsignacionPuerta { get; set; }

        [Column("ID_PUERTA")]
        public int IdPuerta { get; set; }

        [Column("ID_VUELO")]
        public int IdVuelo { get; set; }

        [Column("FECHA_ASIGNACION")]
        public DateTime? FechaAsignacion { get; set; }

        [Column("HORA_INICIO")]
        public DateTime HoraInicio { get; set; }

        [Column("HORA_FIN")]
        public DateTime HoraFin { get; set; }

        [Column("ASIGNADO_POR")]
        public int AsignadoPor { get; set; }
    }
}
