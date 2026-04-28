using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("VUELOS")]
    public class VueloModel
    {
        [Key]
        [Column("ID_VUELO")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVuelo { get; set; }

        [Column("ID_PROGRAMA")]
        [Required]
        public int IdPrograma { get; set; }

        [Column("FECHA_VUELO")]
        public DateTime? FechaVuelo { get; set; }

        [Column("HORA_SALIDA_PROGRAMADA")]
        public DateTime? HoraSalidaProgramada { get; set; }

        [Column("HORA_LLEGADA_PROGRAMADA")]
        public DateTime? HoraLlegadaProgramada { get; set; }

        [Column("HORA_SALIDA_REAL")]
        public DateTime? HoraSalidaReal { get; set; }

        [Column("HORA_LLEGADA_REAL")]
        public DateTime? HoraLlegadaReal { get; set; }

        [Column("ID_MODELO_AVION")]
        [Required]
        public int IdModeloAvion { get; set; }

        [Column("MATRICULA_AVION")]
        [StringLength(20)]
        public string? MatriculaAvion { get; set; }

        [Column("PLAZAS_VACIAS")]
        public int PlazasVacias { get; set; } = 0;

        [Column("PLAZAS_OCUPADAS")]
        public int PlazasOcupadas { get; set; } = 0;

        [Column("CARGA_KG")]
        public decimal CargaKg { get; set; } = 0;

        [Column("COMBUSTIBLE_LITROS")]
        public decimal? CombustibleLitros { get; set; }

        [Column("ESTADO_VUELO")]
        [StringLength(20)]
        public string EstadoVuelo { get; set; } = "PROGRAMADO";
        // CHECK: PROGRAMADO|EN_VUELO|ATERRIZADO|CANCELADO|REPROGRAMADO|DEMORADO|DESVIADO

        [Column("MOTIVO_CANCELACION")]
        [StringLength(500)]
        public string? MotivoCancelacion { get; set; }

        [Column("FECHA_REPROGRAMADO")]
        public DateTime? FechaReprogramado { get; set; }

        [Column("ID_PUERTA_SALIDA")]
        public int? IdPuertaSalida { get; set; }

        [Column("ID_PUERTA_LLEGADA")]
        public int? IdPuertaLlegada { get; set; }

        [Column("OBSERVACIONES_OPERATIVAS")]
        [StringLength(1000)]
        public string? ObservacionesOperativas { get; set; }
    }

}
