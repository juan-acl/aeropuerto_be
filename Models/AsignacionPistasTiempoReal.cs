using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("ASIGNACION_PISTAS_TIEMPO_REAL")]
    public class AsignacionPistasTiempoReal
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_ASIGNACION_PISTA")]
        public decimal IdAsignacionPista { get; set; }

        [Column("ID_PISTA")]
        public decimal IdPista { get; set; }

        [Column("ID_VUELO")]
        public decimal IdVuelo { get; set; }

        [Column("TIPO_OPERACION")]
        public string? TipoOperacion { get; set; }

        [Column("FECHA_HORA_ASIGNACION")]
        public DateTime? FechaHoraAsignacion { get; set; }

        [Column("HORA_INICIO_ESTIMADA")]
        public DateTime HoraInicioEstimada { get; set; }

        [Column("HORA_FIN_ESTIMADA")]
        public DateTime HoraFinEstimada { get; set; }

        [Column("HORA_INICIO_REAL")]
        public DateTime? HoraInicioReal { get; set; }

        [Column("HORA_FIN_REAL")]
        public DateTime? HoraFinReal { get; set; }

        [Column("ESTADO_ASIGNACION")]
        public string? EstadoAsignacion { get; set; }

        [Column("ASIGNADO_POR")]
        public decimal? AsignadoPor { get; set; }

        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
        
}
